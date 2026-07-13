using Android.Content.PM;
using Rayo.Hosting.Abstractions;
using Rayo.Hosting.Android;

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
        context.ConfigureServices(AppSetup.ConfigureServices);
        context.SetUI<MainView>();
    }

    protected override void ConfigureWindow(IPlatformWindowConfiguration config)
    {
        base.ConfigureWindow(config);

        config.Title = "Rayo Cross-Platform App";
        config.VSync = true;
        config.Samples = 4;
    }
}
