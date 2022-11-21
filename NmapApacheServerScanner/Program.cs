using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NmapApacheServerScanner.Configuration.AppSettings;
using NmapApacheServerScanner.Configuration.AutoMapperProfiles;
using NmapApacheServerScanner.Services.App;
using NmapApacheServerScanner.Services.Nmap;
using NmapApacheServerScanner.Services.Xml;
using Serilog;

namespace NmapApacheServerScanner;

public class Program
{
    public static IHost ProgramHost { get; set; }
    public static async Task<int> Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;

        var builder = new ConfigurationBuilder();
        BuildConfig(builder);

        ProgramHost = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                    .AddConfig(context.Configuration)
                    .AddTransient<IAppService, AppService>()
                    .AddTransient<INmapService, NmapService>()
                    .AddTransient<IXmlParserService, XmlParserService>()
                    .AddAutoMapper(typeof(AppMapperProfile).Assembly);
            })
            .UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            })
            .Build();

        var service = ActivatorUtilities.CreateInstance<AppService>(ProgramHost.Services);
        return await service.RunAsync(args);
    }

    static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
    }

    static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        var exception = e.ExceptionObject as Exception;
        var logger = ProgramHost.Services.GetService<ILogger>();

        logger.Error(exception, exception.Message);

        Environment.Exit(-1);
    }
}