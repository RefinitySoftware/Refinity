using Refinity.Collections;

var array = new string[] { "a", "b", "c" };

CollectionsAnalysisResult result = CollectionsUtility.AnalyzeArray(array);
Console.WriteLine($"Max: {result.Max}");
