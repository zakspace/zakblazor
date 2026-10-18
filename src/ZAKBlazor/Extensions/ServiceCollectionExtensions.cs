using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ZAKBlazor.Services;

namespace ZAKBlazor;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all foundational ZAKBlazor services into the application service collection.
    /// </summary>
    public static IServiceCollection AddZAKBlazor(this IServiceCollection services, Action<ZakOptions>? configure = null)
    {
        var options = new ZakOptions();
        configure?.Invoke(options);

        services.TryAddSingleton(options);
        services.TryAddScoped<IZakThemeService, ZakThemeService>();
        services.TryAddScoped<IZakLayoutService, ZakLayoutService>();
        services.TryAddScoped<IZakDialogService, ZakDialogService>();
        services.TryAddScoped<IZakSnackbarService, ZakSnackbarService>();

        return services;
    }
}
