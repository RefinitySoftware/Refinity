using Refinity.Math;
using Refinity.Date;

namespace Refinity.Finance;

public static class FinanceUtility
{
    /// <summary>
    /// Calculates the difference between two values as a percentage.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="otherValue">The second value.</param>
    /// <returns>The difference between the two values as a percentage.</returns>
    public static double DifferencePercentage(this double value, double otherValue)
    {
        return (value - otherValue) / otherValue * 100;
    }

    /// <summary>
    /// Calculates the difference between two integers as a percentage.
    /// </summary>
    /// <param name="value">The first integer value.</param>
    /// <param name="otherValue">The second integer value.</param>
    /// <returns>The difference between the two integers as a percentage.</returns>
    public static double DifferencePercentage(this int value, int otherValue)
    {
        return (value - otherValue) / otherValue * 100;
    }
    
    /// <summary>
    /// Calculates the interest based on the principal amount, interest rate, and time period.
    /// </summary>
    /// <param name="principal">The principal amount.</param>
    /// <param name="interestRate">The interest rate.</param>
    /// <param name="timePeriod">The time period in years.</param>
    /// <returns>The calculated interest.</returns>
    public static double CalculateInterest(double principal, double interestRate, double timePeriod)
    {
        return principal * interestRate * timePeriod;
    }

    /// <summary>
    /// Applies tax to the given amount.
    /// </summary>
    /// <param name="amount">The amount to apply tax to.</param>
    /// <param name="taxRate">The tax rate in percentage.</param>
    /// <returns>The amount with tax applied.</returns>
    public static double ApplyTax(double amount, double taxRate)
    {
        return amount + amount * taxRate / 100;
    }

    /// <summary>
    /// Calculates the number of days until the specified due date.
    /// </summary>
    /// <param name="dueDate">The due date to calculate the days until.</param>
    /// <returns>The number of days until the due date.</returns>
    public static int DaysUntilDue(DateTime dueDate)
    {
        return dueDate.Subtract(DateTime.Now).Days;
    }

    /// <summary>
    /// Calculates the break-even point based on fixed costs, variable costs, and selling price per unit.
    /// </summary>
    /// <param name="fixedCosts">The total fixed costs.</param>
    /// <param name="variableCosts">The variable costs per unit.</param>
    /// <param name="sellingPrice">The selling price per unit.</param>
    /// <returns>The break-even point in units.</returns>
    public static double BreakEvenPoint(double fixedCosts, double variableCosts, double sellingPrice)
    {
        if (variableCosts == 0)
        {
            throw new ArgumentException("Variable costs cannot be zero.");
        }

        return fixedCosts / (sellingPrice - variableCosts);
    }
}
