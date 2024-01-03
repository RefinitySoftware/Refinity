using Refinity.Math;

[TestFixture]
public class MathUtilityTests
{
    [Test]
    public void Factorial_NegativeNumber_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => (-1).Factorial());
    }

    [TestCase(0, ExpectedResult = 1)]
    [TestCase(1, ExpectedResult = 1)]
    [TestCase(2, ExpectedResult = 2)]
    [TestCase(3, ExpectedResult = 6)]
    [TestCase(4, ExpectedResult = 24)]
    public int Factorial_PositiveNumber_ReturnsFactorial(int n)
    {
        return n.Factorial();
    }

    [TestCase(0, ExpectedResult = false)]
    [TestCase(1, ExpectedResult = false)]
    [TestCase(2, ExpectedResult = true)]
    [TestCase(3, ExpectedResult = true)]
    [TestCase(4, ExpectedResult = false)]
    [TestCase(5, ExpectedResult = true)]
    public bool IsPrime_Number_ReturnsIfPrime(int n)
    {
        return n.IsPrime();
    }
    
    [Test]
    [TestCase(0, ExpectedResult = 0)]
    [TestCase(1, ExpectedResult = 1)]
    [TestCase(2, ExpectedResult = 1)]
    [TestCase(3, ExpectedResult = 2)]
    [TestCase(4, ExpectedResult = 3)]
    [TestCase(5, ExpectedResult = 5)]
    [TestCase(6, ExpectedResult = 8)]
    [TestCase(7, ExpectedResult = 13)]
    [TestCase(8, ExpectedResult = 21)]
    [TestCase(9, ExpectedResult = 34)]
    public int Fibonacci_Number_ReturnsFibonacci(int n)
    {
        return n.Fibonacci();
    }
}