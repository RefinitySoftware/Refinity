using System;
using RefinityEnums;

namespace RefinityBenchmark;
/// <summary>
/// Represents a benchmark model that stores information about a benchmark result.
/// </summary>
public class BenchmarkModels
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BenchmarkModels"/> class.
    /// </summary>
    public BenchmarkModels()
    {
        Result = EnumBenchmarkResult.Success;
        Method = string.Empty;
    }

    /// <summary>
    /// Gets or sets the benchmark result.
    /// </summary>
    public EnumBenchmarkResult Result { get; set; }

    /// <summary>
    /// Gets or sets the benchmark method.
    /// </summary>
    public string Method { get; set; }

    /// <summary>
    /// Gets or sets the elapsed time in milliseconds.
    /// </summary>
    public double ElapsedTimeMs { get; set; }

    /// <summary>
    /// Gets or sets the exception that occurred during the benchmark.
    /// </summary>
    public Exception? Exception { get; set; }

    /// <summary>
    /// Gets or sets the number of iterations performed during the benchmark.
    /// </summary>
    public int Iterations { get; set; }
}
