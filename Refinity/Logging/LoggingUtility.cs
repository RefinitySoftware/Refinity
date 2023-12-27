using System.Globalization;
using System.Text;
using Refinity.Logging.Models;

namespace Refinity.Logging
{
    public class LoggingUtility
    {
        private string PathToLogFile { get; set; }
        private LogFileType LogFileType { get; set; }

        /// <summary>
        /// Represents a utility class for logging.
        /// </summary>
        public LoggingUtility(string logFileName, LogFileType logFileType = LogFileType.TXT)
        {
            switch (logFileType)
            {
                case LogFileType.RTF:
                    logFileName += ".rtf";
                    break;
                case LogFileType.TXT:
                    logFileName += ".txt";
                    break;
                case LogFileType.LOG:
                    logFileName += ".log";
                    break;
            }
            LogFileType = logFileType;
            PathToLogFile = Path.Combine(Environment.CurrentDirectory, logFileName);
        }

        /// <summary>
        /// Saves the contents of a StringBuilder to a file.
        /// </summary>
        /// <param name="stringBuilder">The StringBuilder containing the contents to be saved.</param>
        /// <returns>True if the contents were successfully saved to the file; otherwise, false.</returns>
        private bool SaveToFile(StringBuilder stringBuilder)
        {
            try
            {
                using (var streamWriter = new StreamWriter(PathToLogFile, true))
                {
                    streamWriter.Write(stringBuilder.ToString());
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Logs a message with the specified log level.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="logLevel">The log level of the message.</param>
        private void Log(string message, LogLevel logLevel, int severity = 0)
        {
            DateTime timestamp = DateTime.Now;
            ConsoleColor logColors = LogColorHelper.GetLogLevelColor(logLevel);
            StringBuilder stringBuilder = new StringBuilder();
            string severityString = "";
            for (int i = 0; i < severity; i++)
            {
                severityString += "!";
            }
            stringBuilder.AppendLine($"[{timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}] | [{logLevel}] | {message} | {severityString}");

            switch (LogFileType)
            {
                case LogFileType.CONSOLE:
                    Console.ForegroundColor = logColors;
                    Console.WriteLine($"{stringBuilder}");
                    break;
                case LogFileType.RTF:
                case LogFileType.TXT:
                case LogFileType.LOG:
                    SaveToFile(stringBuilder);
                    break;
            }
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Info(string message)
        {
            Log(message, LogLevel.INFO);
        }

        /// <summary>
        /// Writes a debug message to the log.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Debug(string message)
        {
            Log(message, LogLevel.DEBUG);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Warn(string message)
        {
            Log(message, LogLevel.WARNING);
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Error(string message)
        {
            Log(message, LogLevel.ERROR);
        }

        /// <summary>
        /// Logs a fatal error message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Fatal(string message)
        {
            Log(message, LogLevel.FATAL);
        }
    }
}