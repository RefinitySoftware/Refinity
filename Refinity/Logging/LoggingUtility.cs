using System.Globalization;
using System.Text;
using Refinity.Conversion;
using Refinity.Enums;

namespace Refinity.Logging
{
    /// <summary>
    /// Represents a utility class for logging.
    /// </summary>
    public class LoggingUtility
    {
        private string PathToLogFile { get; set; }
        private EnumFileTypes EnumFileTypes { get; set; }

        private string checkFileExtension(string fileName)
        {
            if (fileName.Contains('.'))
            {
                fileName = fileName[..fileName.LastIndexOf('.')];
            }
            return fileName;
        }

        /// <summary>
        /// Represents a utility class for logging operations.
        /// </summary>
        /// <param name="logFileName">The name of the log file.</param>
        /// <param name="EnumFileTypes">The file type for the log file.</param>
        public LoggingUtility(string logFileName, EnumFileTypes EnumFileTypes = EnumFileTypes.TXT)
        {
            logFileName = checkFileExtension(logFileName);
            switch (EnumFileTypes)
            {
                case EnumFileTypes.RTF:
                    logFileName += EnumFileTypes.RTF.GetDescription();
                    break;
                case EnumFileTypes.TXT:
                    logFileName += EnumFileTypes.TXT.GetDescription();
                    break;
                case EnumFileTypes.LOG:
                    logFileName += EnumFileTypes.LOG.GetDescription();
                    break;
            }
            this.EnumFileTypes = EnumFileTypes;
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
        /// <param name="severity">The severity of the error.</param>
        private void Log(string message, EnumLogLevel logLevel, int severity = 0)
        {
            if (severity < 0 || severity > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(severity), "The severity must be between 0 and 10.");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message), "The message cannot be null or empty.");
            }

            DateTime timestamp = DateTime.Now;
            ConsoleColor logColors = GetLogLevelColor(logLevel);
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} | {logLevel} | {message} | {severity}");

            switch (EnumFileTypes)
            {
                case EnumFileTypes.CONSOLE:
                    Console.ForegroundColor = logColors;
                    Console.WriteLine($"{stringBuilder}");
                    break;
                case EnumFileTypes.RTF:
                case EnumFileTypes.TXT:
                case EnumFileTypes.LOG:
                    SaveToFile(stringBuilder);
                    break;
            }
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="severity">The severity of the error.</param>
        public void Info(string message, int severity = 0)
        {
            Log(message, EnumLogLevel.INFO, severity);
        }

        /// <summary>
        /// Writes a debug message to the log.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="severity">The severity of the error.</param>
        public void Debug(string message, int severity = 0)
        {
            Log(message, EnumLogLevel.DEBUG, severity);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="severity">The severity of the error.</param>
        public void Warn(string message, int severity = 0)
        {
            Log(message, EnumLogLevel.WARNING, severity);
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="severity">The severity of the error.</param>
        public void Error(string message, int severity = 0)
        {
            Log(message, EnumLogLevel.ERROR, severity);
        }

        /// <summary>
        /// Logs a fatal error message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="severity">The severity of the error.</param>
        public void Fatal(string message, int severity = 0)
        {
            Log(message, EnumLogLevel.FATAL, severity);
        }

        /// <summary>
        /// Converts the log data to a CSV format.
        /// </summary>
        /// <param name="csvDelimiter">The delimiter character used in the CSV file. Default is ';'.</param>
        /// <returns>An array of bytes representing the CSV data.</returns>
        public byte[] ConvertLogToCSV(char csvDelimiter = ';')
        {
            char delimiter = '|';
            string[] csvHeaders = { "Time", "LogLevel", "Message", "Severity" };
            return ConvertUtility.ConvertTextToCSV(PathToLogFile, delimiter, csvDelimiter, csvHeaders);
        }

        private static ConsoleColor GetLogLevelColor(EnumLogLevel logLevel)
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
}

