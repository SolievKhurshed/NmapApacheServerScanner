using Microsoft.Extensions.Options;
using NmapApacheServerScanner.Configuration.AppSettings;
using System.Diagnostics;
using System.Text;
using ILogger = Serilog.ILogger;

namespace NmapApacheServerScanner.Services.Nmap;

public class NmapService : INmapService
{
    private Process nmapProc;
    private TaskCompletionSource<bool> nmapProcTaskEventHandled;

    private StringBuilder output = new();

    private readonly NmapSettings _nmapSettings;
    private readonly ILogger _logger;

    public NmapService(IOptions<NmapSettings> nmapSettings, ILogger logger)
    {
        _nmapSettings = nmapSettings.Value;
        _logger = logger;
    }

    /// <summary>
    /// Запускает процесс nmap
    /// </summary>
    /// <returns>Возвращает xml в виде строки </returns>
    public async Task<string> RunNmapScannerAsync()
    {
        var scriptArguments = GetArguments();

        _logger.Debug("Попытка запуска {app} c аргументами {args}", _nmapSettings.ExeFilePath, scriptArguments);

        nmapProcTaskEventHandled = new TaskCompletionSource<bool>();

        using (nmapProc = new Process())
        {
            try
            {
                nmapProc.StartInfo.FileName = _nmapSettings.ExeFilePath;
                nmapProc.StartInfo.Arguments = scriptArguments;
                nmapProc.StartInfo.UseShellExecute = false;
                nmapProc.StartInfo.RedirectStandardError = true;
                nmapProc.StartInfo.RedirectStandardOutput = true;
                nmapProc.OutputDataReceived += CollectOutputDataHandler;
                nmapProc.EnableRaisingEvents = true;
                nmapProc.Exited += NmapProcessExitedHandler;
                nmapProc.Start();

                nmapProc.BeginOutputReadLine();

                StreamReader myStreamReader = nmapProc.StandardError;
                _logger.Error(myStreamReader.ReadLine());

                nmapProc.WaitForExit();
            }
            catch (Exception ex)
            {
                _logger.Error("В процессе запуска приложения nmap произошла ошибка: {errMsg}", ex.Message);
                throw;
            }

            await Task.WhenAny(nmapProcTaskEventHandled.Task, Task.Delay(TimeSpan.FromSeconds(_nmapSettings.TaskDelaySeconds)));

            return output.ToString();
        }
    }

    private string GetArguments()
    {
        return $"-sV -oX - --script {_nmapSettings.Arguments.ScriptPath} {_nmapSettings.Arguments.ScanningHost}";
    }

    private void NmapProcessExitedHandler(object sender, EventArgs e)
    {
        _logger.Debug("Завершение процесса nmap. Exit time: {exitTime}, Exit code: {exitCode}, Elapsed time in milliseconds: {elapsedTime}",
            nmapProc.ExitTime, nmapProc.ExitCode, Math.Round((nmapProc.ExitTime - nmapProc.StartTime).TotalMilliseconds));

        _logger.Debug(output.ToString());

        nmapProcTaskEventHandled.TrySetResult(true);
    }

    private void CollectOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        if (!string.IsNullOrEmpty(outLine.Data))
        {
            output.Append(Environment.NewLine + outLine.Data);
        }
    }
}
