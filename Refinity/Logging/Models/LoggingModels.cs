namespace Refinity.Logging.Models;

public class LogEntry
{
    public required string Message { get; set; }
    public LogLevel Level { get; set; } = LogLevel.Info;
    public string? Exception { get; set; }
    public DateTime Timestamp { get; set; }
}

public enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warn,
    Error,
    Fatal
}