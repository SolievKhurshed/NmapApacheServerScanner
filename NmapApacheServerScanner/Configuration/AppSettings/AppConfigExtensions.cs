using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NmapApacheServerScanner.Configuration.AppSettings;

public static class AppConfigExtensions
{
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<NmapSettings>(config.GetSection(NmapSettings.Settings));

        return services;
    }
}
