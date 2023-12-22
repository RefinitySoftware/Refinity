using System.Globalization;
using Refinity.Benchmark;
using Refinity.Benchmark.Models;
using Refinity.Math;

public static partial class Program
{
    public static void Main()
    {
        try
        {
            BenchmarkModels result = BenchmarkUtility.RunCodeBenchmark(testMethod);
            Console.WriteLine($"Method: {result.Method} - Result: {result.Result} - Elapsed Time: {result.ElapsedTimeMs.ToString(CultureInfo.InvariantCulture)}ms");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static int testMethod()
    {
        return 10.Factorial();
    }
}
