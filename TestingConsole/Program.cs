using Refinity.Http;
using Refinity.Enums;
using Refinity.Conversion;


var prova = ConvertUtility.ConvertMeasurement(100, MeasurementUnit.Mile, MeasurementUnit.Millimeters);
Console.WriteLine(prova);