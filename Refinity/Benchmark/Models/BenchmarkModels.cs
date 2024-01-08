using Refinity.Enums;

namespace Refinity.Benchmark.Models;

public class BenchmarkModels
{
    public BenchmarkModels()
    {
        Result = EnumBenchmarkResult.Success;
        Method = string.Empty;
    }

    public EnumBenchmarkResult Result { get; set; }
    public string Method { get; set; }
    public double ElapsedTimeMs { get; set; }
    public Exception? Exception { get; set; }
    public int Iterations { get; set; }
}
