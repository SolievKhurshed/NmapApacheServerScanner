namespace NmapApacheServerScanner.Configuration.AppSettings;

public class NmapSettings
{
    public const string Settings = "AppSettings:Nmap";

    public string ExeFilePath { get; set; }
    public double TaskDelaySeconds { get; set; }

    public NmapSettingsArguments Arguments { get; set; }
}

public class NmapSettingsArguments
{
    public const string Settings = "AppSettings:Nmap:Arguments";

    public string ScriptPath { get; set; }
    public string ScanningHost { get; set; }
}