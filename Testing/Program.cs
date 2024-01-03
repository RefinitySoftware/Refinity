using Refinity.Benchmark;
using Refinity.Strings;
using Refinity.Conversion;
using Refinity.Date;
using Refinity.Math;
using Refinity.Geometry;
using Refinity.Finance;
using Refinity.Logging;

// Aggiungi i tuoi metodi di estensione qui per provare il codice
var stream = File.OpenRead("TestLog.csv");
var lista = ConvertUtility.ConvertCsvToObject<LogEntry>(stream, ';');