using Android.App;
using Android.Content.PM;
using Rayo.Hosting.Android;
using Rayo.Hosting.Abstractions;

namespace RayoCrossPlatformApp.Android;

[Activity(
    Label = "@string/app_name",
    MainLauncher = true,
    Theme = "@style/Theme.RayoCrossPlatformApp",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : AndroidPlatformHost
{
    protected override void ConfigureApp(IPlatformApplicationContext context)
    {
        context.ConfigureServices(RayoCrossPlatformApp.AppSetup.ConfigureServices);
        context.SetUI<RayoCrossPlatformApp.MainView>();
    }

    protected override void ConfigureWindow(IPlatformWindowConfiguration config)
    {
        base.ConfigureWindow(config);

        config.Title = "Rayo Cross-Platform App";
        config.VSync = true;
        config.Samples = 4;
    }
}
