using System.Globalization;
using System.Text;
using Refinity.Logging.Models;
namespace Refinity.Logging;

public class LoggingUtility
{
    private string PathToLogFile { get; set; }
    /// <summary>
    /// Represents a utility class for logging.
    /// </summary>
    public LoggingUtility(string pathToLogFile)
    {
        PathToLogFile = pathToLogFile;
    }

    /// <summary>
    /// Logs the specified log entry to the log file.
    /// </summary>
    /// <param name="logEntry">The log entry to be logged.</param>
    public void Log(LogEntry logEntry)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"[{logEntry.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}] [{logEntry.Level}] {logEntry.Message}");

        using (var streamWriter = new StreamWriter(PathToLogFile, true))
        {
            streamWriter.Write(stringBuilder.ToString());
        }
    }
}