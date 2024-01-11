using Refinity.Enums;

namespace Refinity.Benchmark.Tests
{
    [TestFixture]
    public class BenchmarkUtilityTests
    {
        [Test]
        public void RunCodeBenchmark_Action_Success()
        {
            // Arrange
            Action testAction = () => Console.WriteLine("Test Action");
            int iterations = 5;

            // Act
            var result = BenchmarkUtility.RunCodeBenchmark(testAction, iterations);

            // Assert
            Assert.That(result.Result, Is.EqualTo(EnumBenchmarkResult.Success));
            Assert.That(result.Iterations, Is.EqualTo(iterations));
            Assert.IsNotNull(result.ElapsedTimeMs);
        }

        [Test]
        public void RunCodeBenchmark_Action_Failure()
        {
            // Arrange
            Action testAction = () => throw new Exception("Test Exception");
            int iterations = 5;

            // Act
            var result = BenchmarkUtility.RunCodeBenchmark(testAction, iterations);

            // Assert
            Assert.That(result.Result, Is.EqualTo(EnumBenchmarkResult.Failure));
            Assert.That(result.Iterations, Is.EqualTo(iterations));
            Assert.IsNotNull(result.ElapsedTimeMs);
            Assert.IsNotNull(result.Exception);
        }

        [Test]
        public void RunCodeBenchmark_Func_Success()
        {
            // Arrange
            Func<int> testFunc = () => 1;
            int iterations = 5;

            // Act
            var result = BenchmarkUtility.RunCodeBenchmark(testFunc, iterations);

            // Assert
            Assert.That(result.Result, Is.EqualTo(EnumBenchmarkResult.Success));
            Assert.That(result.Iterations, Is.EqualTo(iterations));
            Assert.IsNotNull(result.ElapsedTimeMs);
        }

        [Test]
        public void RunCodeBenchmark_Func_Failure()
        {
            // Arrange
            Func<int> testFunc = () => throw new Exception("Test Exception");
            int iterations = 5;

            // Act
            var result = BenchmarkUtility.RunCodeBenchmark(testFunc, iterations);

            // Assert
            Assert.That(result.Result, Is.EqualTo(EnumBenchmarkResult.Failure));
            Assert.That(result.Iterations, Is.EqualTo(iterations));
            Assert.IsNotNull(result.ElapsedTimeMs);
            Assert.IsNotNull(result.Exception);
        }
    }
}