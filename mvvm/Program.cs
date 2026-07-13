using Microsoft.Extensions.DependencyInjection;
using Rayo.Core.Platform;
using Rayo.Hosting.Desktop;

namespace RayoMvvmApp;

public static class Program
{
    public static void Main(string[] args)
    {
        var host = new DesktopPlatformHost();

        host.Run(
            configureApp: context =>
            {
#if DEBUG
                context.EnableDevTools = true;
#endif
                context.ConfigureServices(services =>
                {
                    services.AddTransient<MainViewModel>();
                });
                context.SetUI<MainView>();
            },
            configureWindow: config =>
            {
                config.Title = "Rayo MVVM App";
                config.Width = 960;
                config.Height = 640;
                config.CanResize = true;
                config.VSync = true;
                config.Samples = 4;
                config.SetIconFromFile(Path.Combine(AppContext.BaseDirectory, "Assets/AppIcon", "AppIcon.png"));

                if (host.GetNativeWindowConfiguration(config) is { } nativeConfig)
                {
                    nativeConfig.StartupLocation = WindowStartupLocation.CenterScreen;
                }
            });
    }
}
