namespace Refinity.Logging.Models;
using Refinity.Enums;

public class LogColorHelper
{
    public static ConsoleColor GetLogLevelColor(EnumLogLevel logLevel)
    {
        switch (logLevel)
        {
            case EnumLogLevel.TRACE:
                return ConsoleColor.Gray;
            case EnumLogLevel.DEBUG:
                return ConsoleColor.Blue;
            case EnumLogLevel.INFO:
                return ConsoleColor.Green;
            case EnumLogLevel.WARNING:
                return ConsoleColor.Yellow;
            case EnumLogLevel.ERROR:
                return ConsoleColor.Red;
            case EnumLogLevel.FATAL:
                return ConsoleColor.Magenta;
            default:
                return ConsoleColor.White;
        }
    }
}