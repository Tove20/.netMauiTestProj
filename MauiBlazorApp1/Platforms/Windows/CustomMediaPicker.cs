
using Microsoft.Maui.Platform;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.System;
using WinRT.Interop;


public partial class CustomMediaPicker 
{
    private LauncherOptions _launcherOptions;

    public CustomMediaPicker()
    {
        var hndl = WindowStateManager.Default.GetActiveWindow().GetWindowHandle();

        _launcherOptions = new LauncherOptions();
        InitializeWithWindow.Initialize(_launcherOptions, hndl);

        _launcherOptions.TreatAsUntrusted = false;
        _launcherOptions.DisplayApplicationPicker = false;
        _launcherOptions.TargetApplicationPackageFamilyName = "Microsoft.WindowsCamera_8wekyb3d8bbwe";
    }

    public async Task<StorageFile> CaptureFileAsync()
    {

        var currentAppData = ApplicationData.Current;
        var tempLocation = currentAppData.TemporaryFolder;
        var tempFileName = "CCapture.jpg";
        var tempFile = await tempLocation.CreateFileAsync(tempFileName, CreationCollisionOption.GenerateUniqueName);
        var token = Windows.ApplicationModel.DataTransfer.SharedStorageAccessManager.AddFile(tempFile);

        var set = new ValueSet
        {
            { "MediaType", "photo"},
            { "PhotoFileToken", token }
        };

        var uri = new Uri("microsoft.windows.camera.picker:");
        var result = await Windows.System.Launcher.LaunchUriForResultsAsync(uri, _launcherOptions, set);
        if (result.Status == LaunchUriStatus.Success)
        {
            return tempFile;

        }

        return null;
    }
}