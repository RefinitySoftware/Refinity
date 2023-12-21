namespace Refinity.Math;

public static class MathUtility
{
    /// <summary>
    /// Calculates the factorial of a non-negative integer.
    /// </summary>
    /// <param name="n">The non-negative integer.</param>
    /// <returns>The factorial of the input integer.</returns>
    public static int Factorial(this int n)
    {
        if (n < 0)
            throw new ArgumentException("Factorial is not defined for negative numbers.");

        int result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    /// <summary>
    /// Determines whether the specified number is a prime number.
    /// </summary>
    /// <param name="n">The number to check.</param>
    /// <returns><c>true</c> if the number is prime; otherwise, <c>false</c>.</returns>
    public static bool IsPrime(this int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified integer is even.
    /// </summary>
    /// <param name="n">The integer to check.</param>
    /// <returns>true if the integer is even; otherwise, false.</returns>
    public static bool IsEven(this int n)
    {
        return n % 2 == 0;
    }

    /// <summary>
    /// Determines whether the specified integer is odd.
    /// </summary>
    /// <param name="n">The integer to check.</param>
    /// <returns>true if the specified integer is odd; otherwise, false.</returns>
    public static bool IsOdd(this int n)
    {
        return n % 2 != 0;
    }

    /// <summary>
    /// Determines whether an integer is divisible by a given divisor.
    /// </summary>
    /// <param name="n">The integer to check for divisibility.</param>
    /// <param name="divisor">The divisor to check against.</param>
    /// <returns>True if the integer is divisible by the divisor, otherwise false.</returns>
    public static bool IsDivisibleBy(this int n, int divisor)
    {
        return n % divisor == 0;
    }

    /// <summary>
    /// Determines whether an integer is divisible by a given divisor and calculates the quotient.
    /// </summary>
    /// <param name="n">The integer to check for divisibility.</param>
    /// <param name="divisor">The divisor to check against.</param>
    /// <param name="quotient">The calculated quotient if the integer is divisible by the divisor.</param>
    /// <returns>True if the integer is divisible by the divisor, false otherwise.</returns>
    public static bool IsDivisibleBy(this int n, int divisor, out int quotient)
    {
        quotient = n / divisor;
        return n % divisor == 0;
    }

    /// <summary>
    /// Calculates the greatest common divisor (GCD) of two integers.
    /// </summary>
    /// <param name="a">The first integer.</param>
    /// <param name="b">The second integer.</param>
    /// <returns>The greatest common divisor of the two integers.</returns>
    public static int GreatestCommonDivisor(this int a, int b)
    {
        int remainder;
        while (b != 0)
        {
            remainder = a % b;
            a = b;
            b = remainder;
        }

        return a;
    }

    /// <summary>
    /// Calculates the least common multiple (LCM) of two integers.
    /// </summary>
    /// <param name="a">The first integer.</param>
    /// <param name="b">The second integer.</param>
    /// <returns>The least common multiple of the two integers.</returns>
    public static int LeastCommonMultiple(this int a, int b)
    {
        return a * b / a.GreatestCommonDivisor(b);
    }

    /// <summary>
    /// Converts an integer to its binary representation in base 2.
    /// </summary>
    /// <param name="n">The integer to convert.</param>
    /// <returns>The binary representation of the input integer.</returns>
    public static int ConvertToBaseBinary(this int n)
    {
        int binary = 0;
        int baseValue = 1;

        while (n > 0)
        {
            int remainder = n % 2;
            n = n / 2;
            binary += remainder * baseValue;
            baseValue *= 10;
        }

        return binary;
    }

    /// <summary>
    /// Converts an integer to its octal representation.
    /// </summary>
    /// <param name="n">The integer to be converted.</param>
    /// <returns>The octal representation of the input integer.</returns>
    public static int ConvertToBaseOctal(this int n)
    {
        int octal = 0;
        int baseValue = 1;

        while (n > 0)
        {
            int remainder = n % 8;
            n = n / 8;
            octal += remainder * baseValue;
            baseValue *= 10;
        }

        return octal;
    }

    /// <summary>
    /// Converts an integer to its hexadecimal representation.
    /// </summary>
    /// <param name="n">The integer to convert.</param>
    /// <returns>The hexadecimal representation of the input integer.</returns>
    public static int ConvertToBaseHexadecimal(this int n)
    {
        int hexadecimal = 0;
        int baseValue = 1;

        while (n > 0)
        {
            int remainder = n % 16;
            n = n / 16;

            if (remainder < 10)
            {
                hexadecimal += remainder * baseValue;
            }
            else
            {
                char hexChar = (char)('A' + (remainder - 10));
                hexadecimal += (int)hexChar * baseValue;
            }

            baseValue *= 10;
        }

        return hexadecimal;
    }

    /// <summary>
    /// Calculates the Fibonacci number for a given integer.
    /// </summary>
    /// <param name="n">The input integer.</param>
    /// <returns>The Fibonacci number.</returns>
    public static int Fibonacci(this int n)
    {
        if (n < 0)
            throw new ArgumentException("Fibonacci is not defined for negative numbers.");

        if (n == 0)
            return 0;

        if (n == 1)
            return 1;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    /// <summary>
    /// Calculates the mean and standard deviation of an array of integers.
    /// </summary>
    /// <param name="values">The array of integers.</param>
    /// <returns>A tuple containing the mean and standard deviation.</returns>
    public static (double mean, double standardDeviation) GetStandardDeviation(this int[] values)
    {
        double mean = values.Average();
        double sumOfSquaresOfDifferences = values.Select(val => (val - mean) * (val - mean)).Sum();
        double standardDeviation = System.Math.Sqrt(sumOfSquaresOfDifferences / (values.Length - 1));
        return (mean, standardDeviation);
    }

    /// <summary>
    /// Calculates the mean and standard deviation of an array of doubles.
    /// </summary>
    /// <param name="values">The array of doubles.</param>
    /// <returns>A tuple containing the mean and standard deviation.</returns>
    public static (double mean, double standardDeviation) GetStandardDeviation(this double[] values)
    {
        double mean = values.Average();
        double sumOfSquaresOfDifferences = values.Select(val => (val - mean) * (val - mean)).Sum();
        double standardDeviation = System.Math.Sqrt(sumOfSquaresOfDifferences / (values.Length - 1));
        return (mean, standardDeviation);
    }
}
