namespace Refinity.Logging.Models;
using Refinity.Logging.Enums;

public class LogColorHelper
{
    public static ConsoleColor GetLogLevelColor(LogLevel logLevel)
    {
        switch (logLevel)
        {
            case LogLevel.TRACE:
                return ConsoleColor.Gray;
            case LogLevel.DEBUG:
                return ConsoleColor.Blue;
            case LogLevel.INFO:
                return ConsoleColor.Green;
            case LogLevel.WARNING:
                return ConsoleColor.Yellow;
            case LogLevel.ERROR:
                return ConsoleColor.Red;
            case LogLevel.FATAL:
                return ConsoleColor.Magenta;
            default:
                return ConsoleColor.White;
        }
    }
}