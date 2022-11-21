using NmapApacheServerScanner.Services.Nmap;
using ILogger = Serilog.ILogger;

namespace NmapApacheServerScanner.Services.App;

public class AppService : IAppService
{
    private readonly INmapService _nmapService;
    private readonly ILogger _logger;

    public AppService(INmapService nmapService, ILogger logger)
    {
        _nmapService = nmapService;
        _logger = logger;
    }

    public async Task<int> RunAsync(string[] args)
    {
        _logger.Debug("Запуск обработчика...");

        var scanningResult = await _nmapService.RunNmapScannerAsync();

        _logger.Debug("Выход из обработчика...");

        return 0;
    }
}
