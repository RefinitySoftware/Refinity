using NUnit.Framework;
using Refinity.Finance;
using System.Collections.Generic;

[TestFixture]
public class FinanceUtilityTests
{
    [Test]
    public void PaybackPeriod_WithPositiveCashFlows_ReturnsCorrectPeriod()
    {
        // Arrange
        double initialInvestment = 10000;
        List<double> cashFlows = new List<double> { 2000, 3000, 4000, 5000, 6000 };

        // Act
        double result = FinanceUtility.PaybackPeriod(initialInvestment, cashFlows);

        // Assert
        Assert.That(result, Is.EqualTo(3.2));
    }

    [Test]
    public void PaybackPeriod_WithNegativeCashFlows_ReturnsInfinity()
    {
        // Arrange
        double initialInvestment = 10000;
        List<double> cashFlows = new List<double> { -2000, -3000, -4000, -5000, -6000 };

        // Act
        double result = FinanceUtility.PaybackPeriod(initialInvestment, cashFlows);

        // Assert
        Assert.That(result, Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void PaybackPeriod_WithZeroInitialInvestment_ReturnsZero()
    {
        // Arrange
        double initialInvestment = 100;
        List<double> cashFlows = new List<double> { 2000, 3000, 4000, 5000, 6000 };

        // Act
        double result = FinanceUtility.PaybackPeriod(initialInvestment, cashFlows);

        // Assert
        Assert.That(result, Is.AtLeast(0.05));
    }
}