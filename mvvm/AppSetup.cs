using Microsoft.Extensions.DependencyInjection;

namespace RayoMvvmApp;

public static class AppSetup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<MainViewModel>();
    }
}
