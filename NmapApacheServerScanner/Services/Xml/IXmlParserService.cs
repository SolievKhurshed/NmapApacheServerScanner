using NmapApacheServerScanner.Models.Nmap;

namespace NmapApacheServerScanner.Services.Xml;

public interface IXmlParserService
{
    NmapRun DeserializeXml(string xml);
}