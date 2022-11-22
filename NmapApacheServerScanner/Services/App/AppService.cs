using NmapApacheServerScanner.DAL.Repositories;
using NmapApacheServerScanner.Models.Nmap;
using NmapApacheServerScanner.Services.Nmap;
using NmapApacheServerScanner.Services.Xml;
using System.Text.Encodings.Web;
using System.Text.Json;
using ILogger = Serilog.ILogger;

namespace NmapApacheServerScanner.Services.App;

public class AppService : IAppService
{
    private readonly INmapService _nmapService;
    private readonly IXmlParserService _xmlParserService;
    private readonly INmapRepository _nmapRepository;
    private readonly ILogger _logger;

    public AppService(INmapService nmapService, IXmlParserService xmlParserService,
        INmapRepository nmapRepository, ILogger logger)
    {
        _nmapService = nmapService;
        _xmlParserService = xmlParserService;
        _nmapRepository = nmapRepository;
        _logger = logger;
    }

    public async Task<int> RunAsync(string[] args)
    {
        _logger.Debug("Запуск обработчика...");

        var scanningResult = await _nmapService.RunNmapScannerAsync();

        PrepareScanningResultToSave(scanningResult);
        SaveResult(scanningResult);

        _logger.Debug("Выход из обработчика...");

        await Task.Delay(TimeSpan.FromSeconds(3));

        return 0;
    }

    private void PrepareScanningResultToSave(NmapScanResult nmapScanResult)
    {
        var nmapRunModel = _xmlParserService.DeserializeXml(nmapScanResult.FullResult);

        var nmapRunModelToJson = JsonSerializer.Serialize(nmapRunModel,
            new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

        nmapScanResult.TomcatVersion = GetTomcatVersion(nmapRunModel);
        nmapScanResult.FullResult = nmapRunModelToJson;
    }

    private string GetTomcatVersion(NmapRun mapRun)
    {
        _logger.Debug("Пытаемся извлечь версию Apache Tomcat.");

        return mapRun.Host?.Ports?.PortList
            .Where(c => c.Service.Product == "Apache Tomcat")
            .Select(x => x.Service.Version).FirstOrDefault();
    }

    private void SaveResult(NmapScanResult nmapScanResult)
    {
        _logger.Debug("Пытаемся сохранить результат в БД.");

        _nmapRepository.SaveScanResult(nmapScanResult);

        _logger.Debug("Результат успешно сохранен в БД.");
    }
}
