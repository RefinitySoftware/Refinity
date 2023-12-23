using System.Diagnostics;
using Refinity.Benchmark.Models;

namespace Refinity.Benchmark;
public static class BenchmarkUtility
{
    /// <summary>
    /// Run a benchmark on a method.
    /// </summary>
    /// <typeparam name="T">The type of the method's return value.</typeparam>
    /// <param name="testMethod">The method to test.</param>
    /// <param name="iterations">The number of iterations to run.</param>
    /// <returns>A BenchmarkModels object containing the benchmark results.</returns>
    public static BenchmarkModels RunCodeBenchmark<T>(Func<T> testMethod, int iterations = 1)
    {
        BenchmarkModels result = new()
        {
            Method = nameof(testMethod),
            Iterations = iterations
        };
        Stopwatch stopwatch = new Stopwatch();
        try
        {
            double timeElapsed = 0;
            for (int i = 0; i < iterations; i++)
            {
                stopwatch.Start();
                testMethod();
                stopwatch.Stop();
                timeElapsed += stopwatch.Elapsed.TotalMilliseconds;
            }
            result.ElapsedTimeMs = timeElapsed / iterations;
            result.Result = BenchmarkResult.Success;
        }
        catch (Exception ex)
        {
            result.Result = BenchmarkResult.Failure;
            result.ElapsedTimeMs = stopwatch.Elapsed.TotalMilliseconds;
            result.Exception = ex;
        }
        return result;
    }

    /// <summary>
    /// Run a benchmark on an action.
    /// </summary>
    /// <param name="testMethod">The method to test.</param>
    /// <param name="iterations">The number of iterations to run.</param>
    /// <returns>A BenchmarkModels object containing the benchmark results.</returns>
    public static BenchmarkModels RunCodeBenchmark(Action testMethod, int iterations = 1)
    {
        BenchmarkModels result = new()
        {
            Method = nameof(testMethod),
            Iterations = iterations
        };
        Stopwatch stopwatch = new Stopwatch();
        try
        {
            double timeElapsed = 0;
            for (int i = 0; i < iterations; i++)
            {
                stopwatch.Start();
                testMethod();
                stopwatch.Stop();
                timeElapsed += stopwatch.Elapsed.TotalMilliseconds;
            }
            result.ElapsedTimeMs = timeElapsed / iterations;
            result.Result = BenchmarkResult.Success;
        }
        catch (Exception ex)
        {
            result.Result = BenchmarkResult.Failure;
            result.ElapsedTimeMs = stopwatch.Elapsed.TotalMilliseconds;
            result.Exception = ex;
        }
        return result;
    }
}
