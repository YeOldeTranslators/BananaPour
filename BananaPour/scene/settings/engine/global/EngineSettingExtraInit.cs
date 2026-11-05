using BananaPour.Project;

namespace BananaPour.Scene.Settings;

public static class EngineSettingExtraInit
{
    [StartupTask]
    public static void Init()
    {
        // Setup BananaPour.Project globals from EngineSettings
        Global.DebugFsFtpLogging = EngineSettings.GetSetting<bool>("bananapour/debug/ftp_logging", false);
    }
}