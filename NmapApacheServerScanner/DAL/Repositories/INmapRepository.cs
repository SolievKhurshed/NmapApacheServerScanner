using NmapApacheServerScanner.Models.Nmap;

namespace NmapApacheServerScanner.DAL.Repositories;

public interface INmapRepository
{
    void SaveScanResult(NmapScanResult nmapScanResult);
}