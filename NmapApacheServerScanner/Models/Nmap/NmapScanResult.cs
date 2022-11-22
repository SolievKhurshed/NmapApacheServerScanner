namespace NmapApacheServerScanner.Models.Nmap;

public class NmapScanResult
{
    public DateTime Created { get; set; } = DateTime.Now;
    public string Host { get; set; }
    public string TomcatVersion { get; set; }
    public string FullResult { get; set; }
}
