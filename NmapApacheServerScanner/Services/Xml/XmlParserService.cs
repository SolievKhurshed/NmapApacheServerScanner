using NmapApacheServerScanner.Models.Nmap;
using System.Xml.Serialization;
using ILogger = Serilog.ILogger;

namespace NmapApacheServerScanner.Services.Xml;

public class XmlParserService : IXmlParserService
{
    private readonly ILogger _logger;

    public XmlParserService(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Десериализует xml в объект NmapRun
    /// </summary>
    /// <param name="xml"></param>
    /// <returns></returns>
    public NmapRun DeserializeXml(string xml)
    {
        _logger.Debug("Попытка десериализировать xml.");

        var xs = new XmlSerializer(typeof(NmapRun));

        NmapRun data;
        using (var reader = new StringReader(xml))
        {
            data = (NmapRun)xs.Deserialize(reader);
        }

        return data;
    }
}
