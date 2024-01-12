using Refinity.Collections;
using Refinity.Collections.Models;

var array = new string[] { "a", "b", "c" };

CollectionsAnalysisResult result = CollectionsUtility.AnalyzeArray(array);
Console.WriteLine($"Max: {result.Max}");
