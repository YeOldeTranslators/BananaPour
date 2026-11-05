using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Nindot;

public static class RomfsPathUtility
{
    public static bool ValidateAndUpdatePath(ref string path, out RomfsVersion version)
    {
        // Setup default version value
        version = RomfsVersion.INVALID_VERSION;

        // Attempt to update the path to ensure validity
        path = ModifyPath(path);
        if (path == null) return false;

        // Get the game version from the romfs path using the hash table
        version = GetVersion(path);
        if (version == RomfsVersion.INVALID_VERSION) return false;

        return true;
    }

    private static string ModifyPath(string path)
    {
        // Replace all backslashes with forward slashes
        path = path.Replace('\\', '/');

        // Make sure the path ends with a slash
        if (!path.EndsWith('/') && !path.EndsWith('\\')) path += '/';

        // Check if the current path is valid
        if (!Directory.Exists(path)) return null;

        // If this directory contains a directory called romfs, enter that
        var dirList = Directory.GetDirectories(path);
        if (dirList.Any(s => s.EndsWith("romfs")))
        {
            path += "romfs/";
            dirList = Directory.GetDirectories(path);
        }

        // Ensure this directory contains the standard folders an SMO romfs should have
        foreach (var dir in RequiredRomfsDirectories)
        {
            if (!dirList.Contains(path + dir)) return null;
        }

        return path;
    }

    private static RomfsVersion GetVersion(string path)
    {
        GetHash(path, out string hash);
        if (hash == null || hash == string.Empty)
            return RomfsVersion.INVALID_VERSION;

        if (HashTable.TryGetValue(hash, out RomfsVersion version))
            return version;

        return RomfsVersion.INVALID_VERSION;
    }

    private static void GetHash(string path, out string hash)
    {
        hash = null;

        var filePath = path + "Mals/USen.Product.100.sarc.zs";
        if (!File.Exists(filePath))
            return;

        FileStream filestream;
        SHA256 mySHA256 = SHA256.Create();

        filestream = new FileStream(filePath, FileMode.Open, FileAccess.Read)
        {
            Position = 0
        };

        byte[] hashValue = mySHA256.ComputeHash(filestream);
        hash = BitConverter.ToString(hashValue).Replace("-", string.Empty).ToLower();
        Debug.WriteLine(hash);
        filestream.Close();
    }

    public enum RomfsVersion : int
    {
        INVALID_VERSION = -1,
        v100 = 100,
        v101 = 101,
    };

    private static readonly Dictionary<string, RomfsVersion> HashTable = new() {
        { "21c5a849ca0fd61e26aabef2b3813abdca1591c994088faa06272723ac10c809", RomfsVersion.v100 },
        { "aa", RomfsVersion.v101 },
    };

    private static readonly string[] RequiredRomfsDirectories = [
        "Mals",
    ];
}
