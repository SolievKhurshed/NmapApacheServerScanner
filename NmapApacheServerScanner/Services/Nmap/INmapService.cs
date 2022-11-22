using NmapApacheServerScanner.Models.Nmap;

namespace NmapApacheServerScanner.Services.Nmap;

public interface INmapService
{
    Task<NmapScanResult> RunNmapScannerAsync();
}