using Godot;
using BananaPour.Project;
using BananaPour.Project.FTP;
using System;
using System.Threading.Tasks;

namespace BananaPour.Scene.Main;

public partial class ToolMenu : Popup
{
    private async void OnPressButtonUploadProjectRomfs()
    {
        Hide();

        if (!await ProjectFtpClient.IsConnectedStill())
            return;

        if (!ProjectManager.IsProjectExist())
            return;

        ProjectFtpClient.UploadProjectAll(ProjectManager.GetPath());
    }

    private async void OnPressButtonDeleteRemoteRomfs()
    {
        Hide();

        if (!await ProjectFtpClient.IsConnectedStill())
            return;

        ProjectFtpClient.Delete(ProjectFtpClient.CredentialStore.WorkingDirectory, true, true);
    }

    private async void OnPressButtonDeleteRemoteExefs()
    {
        Hide();

        if (!await ProjectFtpClient.IsConnectedStill())
            return;

        ProjectFtpClient.Delete(ProjectFtpClient.GetAtmosphereExefsPath(), true, true);
        ProjectFtpClient.Delete(ProjectFtpClient.GetAtmosphereExefsPatchesPath(), true, true);
    }
}
