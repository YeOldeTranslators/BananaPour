using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Godot;

namespace BananaPour.Project;

public class GraphMetaBucketEntryPoint : GraphMetaBucketNode
{
    public GraphMetaBucketEntryPoint() { }

    [JsonInclude]
    public string Uid = null;
    [JsonInclude]
    public string Name = "";

    public string TryAssignUid()
    {
        Uid ??= Guid.NewGuid().ToString();
        return Uid;
    }
}