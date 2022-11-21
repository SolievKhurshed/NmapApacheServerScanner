namespace NmapApacheServerScanner.Services.App;

public interface IAppService
{
    Task<int> RunAsync(string[] args);
}