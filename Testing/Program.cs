using Refinity.Benchmark;
using Refinity.Strings;
using Refinity.Conversion;
using Refinity.Date;
using Refinity.Math;
using Refinity.Geometry;
using Refinity.Finance;
using Refinity.Logging;
using Refinity.Enums;
// Aggiungi i tuoi metodi di estensione qui per provare il codice
// var stream = File.OpenRead("TestLog.csv");
// var lista = ConvertUtility.ConvertCsvToObject<LogEntry>(stream, ';', true);
// Console.WriteLine(lista.Count);

DateTime date = new DateTime(2023, (int)EnumMonths.June, 10);
Console.WriteLine(date.GetWeekNumber());

int value1 = 50;
int value2 = 30;

double differencePercentage = value1.DifferencePercentage(value2);

Console.WriteLine($"The percentage difference between {value1} and {value2} is: {differencePercentage}%");
differencePercentage.ToStringPercentage();