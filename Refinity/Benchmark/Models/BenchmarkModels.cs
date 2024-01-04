using Refinity.Benchmark.Enums;

namespace Refinity.Benchmark.Models;

public class BenchmarkModels
{
    public BenchmarkModels()
    {
        Result = BenchmarkResult.Success;
        Method = string.Empty;
    }

    public BenchmarkResult Result { get; set; }
    public string Method { get; set; }
    public double ElapsedTimeMs { get; set; }
    public Exception? Exception { get; set; }
    public int Iterations { get; set; }
}
