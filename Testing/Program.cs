using Refinity.Conversion;

Stream stream = File.OpenRead("TestLog.csv");

ConvertUtility.ConvertCsvToObject<LogEntry>(stream, delimiter: ';');