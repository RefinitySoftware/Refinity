using System.Globalization;
using Refinity.Logging.Models;
using Refinity.Logging;

public static partial class Program
{
    static LoggingUtility loggingUtility = new("test", LogFileType.CONSOLE);
    public static void Main()
    {
        try
        {
            loggingUtility.Debug("This is a debug message.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
