using Refinity.Date;
using System.Globalization;

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

    
    /// <summary>
    /// Calculates the compound interest based on the principal amount, interest rate, and time period.
    /// </summary>
    /// <param name="principal">The principal amount.</param>
    /// <param name="interestRate">The interest rate.</param>
    /// <param name="timePeriod">The time period in years.</param>
    /// <returns>The calculated compound interest.</returns>
    public static double CalculateCompoundInterest(double principal, double interestRate, double timePeriod)
    {
        double compoundInterest = principal * System.Math.Pow(1 + interestRate / 100, timePeriod);
        return compoundInterest - principal;
    }

    /// <summary>
    /// Converts a double value to a currency string representation.
    /// </summary>
    /// <param name="value">The double value to convert.</param>
    /// <returns>A string representation of the double value formatted as currency.</returns>
    public static string ToCurrency(this double value)
    {
        return value.ToString("C");
    }

    /// <summary>
    /// Converts the specified integer value to a currency string representation using the specified culture information.
    /// </summary>
    /// <param name="value">The integer value to convert.</param>
    /// <param name="cultureInfo">The culture information used for formatting the currency string.</param>
    /// <returns>A string representation of the specified integer value formatted as a currency.</returns>
    public static string ToCurrency(this double value, CultureInfo cultureInfo)
    {
        return value.ToString("C", cultureInfo);
    }

    /// <summary>
    /// Calculates the future value of a present value based on the interest rate and time period.
    /// </summary>
    /// <param name="presentValue">The present value.</param>
    /// <param name="interestRate">The interest rate.</param>
    /// <param name="timePeriod">The time period in years.</param>
    /// <returns>The future value of the present value.</returns>
    public static double PredictFutureValue(double presentValue, double interestRate, double timePeriod)
    {
        return presentValue * System.Math.Pow(1 + interestRate / 100, timePeriod);
    }

    /// <summary>
    /// Predicts the future value based on the present value, interest rate, start date, and end date.
    /// </summary>
    /// <param name="presentValue">The present value.</param>
    /// <param name="interestRate">The interest rate.</param>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>The predicted future value.</returns>
    public static double PredictFutureValue(double presentValue, double interestRate, DateTime startDate, DateTime endDate)
    {
        var timePeriod = startDate.GetDifference(endDate).Years;
        return PredictFutureValue(presentValue, interestRate, timePeriod);
    }

    /// <summary>
    /// Calculates the time required to recover the cost of an investment.
    /// </summary>
    /// <param name="initialInvestment">The initial investment cost.</param>
    /// <param name="cashFlows">The cash flows generated by the investment.</param>
    /// <returns>The payback period in years.</returns>
    public static double PaybackPeriod(double initialInvestment, List<double> cashFlows)
    {
        double cumulativeCashFlow = -initialInvestment;
        int paybackPeriod = 0;

        while (cumulativeCashFlow < 0 && paybackPeriod < cashFlows.Count)
        {
            cumulativeCashFlow += cashFlows[paybackPeriod];
            paybackPeriod++;
        }

        if (cumulativeCashFlow < 0)
        {
            return double.PositiveInfinity;
        }

        double fractionalPart = -cumulativeCashFlow / cashFlows[paybackPeriod - 1];
        double paybackPeriodYears = paybackPeriod + fractionalPart;

        return paybackPeriodYears;
    }

    /// <summary>
    /// Calculates the simple interest based on the principal amount, interest rate, and time period.
    /// </summary>
    /// <param name="principal">The principal amount.</param>
    /// <param name="interestRate">The interest rate.</param>
    /// <param name="timePeriod">The time period in years.</param>
    /// <returns>The calculated simple interest.</returns>
    public static double CalculateSimpleInterest(double principal, double interestRate, double timePeriod)
    {
        return principal * interestRate * timePeriod;
    }

    /// <summary>
    /// Calculates the net present value (NPV) of a series of cash flows based on a discount rate.
    /// </summary>
    /// <param name="discountRate">The discount rate.</param>
    /// <param name="cashFlows">The cash flows.</param>
    /// <returns>The calculated net present value.</returns>
    public static double CalculateNetPresentValue(double discountRate, List<double> cashFlows)
    {
        double npv = 0;

        for (int i = 0; i < cashFlows.Count; i++)
        {
            npv += cashFlows[i] / System.Math.Pow(1 + discountRate, i + 1);
        }

        return npv;
    }

    /// <summary>
    /// Calculates the internal rate of return (IRR) of a series of cash flows.
    /// </summary>
    /// <param name="cashFlows">The cash flows.</param>
    /// <returns>The calculated internal rate of return.</returns>
    public static double CalculateInternalRateOfReturn(List<double> cashFlows)
    {
        double irr = 0;
        double epsilon = 0.0001;
        double guess = 0.1;

        while (true)
        {
            double npv = 0;

            for (int i = 0; i < cashFlows.Count; i++)
            {
                npv += cashFlows[i] / System.Math.Pow(1 + irr, i + 1);
            }

            if (System.Math.Abs(npv) < epsilon)
            {
                break;
            }

            irr += guess;
        }

        return irr;
    }
}
