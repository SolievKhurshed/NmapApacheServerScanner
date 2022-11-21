using NmapApacheServerScanner.Services.Nmap;
using NmapApacheServerScanner.Services.Xml;
using System.Xml;
using ILogger = Serilog.ILogger;

namespace NmapApacheServerScanner.Services.App;

public class AppService : IAppService
{
    private readonly INmapService _nmapService;
    private readonly IXmlParserService _xmlParserService;
    private readonly ILogger _logger;

    public AppService(INmapService nmapService, IXmlParserService xmlParserService, ILogger logger)
    {
        _nmapService = nmapService;
        _xmlParserService = xmlParserService;
        _logger = logger;
    }

    public async Task<int> RunAsync(string[] args)
    {
        _logger.Debug("Запуск обработчика...");

        var scanningResult = await _nmapService.RunNmapScannerAsync();

        var nmapRunModel = _xmlParserService.DeserializeXml(scanningResult);

        _logger.Debug("Выход из обработчика...");

        return 0;
    }
}
