namespace NmapApacheServerScanner.Services.Nmap;

public interface INmapService
{
    Task<string> RunNmapScannerAsync();
}