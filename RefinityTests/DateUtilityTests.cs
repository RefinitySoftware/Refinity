namespace RefinityTests;

// FILEPATH: /Users/francesco/Desktop/Progetti/Refinity/Refinity/Date/DateUtilityTests.cs
using System;
using Newtonsoft.Json;
using Refinity.Date;

public class DateUtilityTests
{
    [Fact]
    public void TestAdd()
    {
        DateTime date = new DateTime(2022, 1, 1);
        DateTime result = date.Add(years: 1, months: 2, days: 3, hours: 4, minutes: 5, seconds: 6);
        Assert.Equal(new DateTime(2023, 3, 4, 4, 5, 6), result);
    }

    [Fact]
    public void TestCalculateAge()
    {
        DateTime birthDate = new DateTime(1990, 1, 1);
        int age = birthDate.CalculateAge();
        Assert.Equal(DateTime.Today.Year - 1990, age);
    }

    [Fact]
    public void TestDeserializeDateTime()
    {
        string dateTimeString = JsonConvert.SerializeObject(new { year = 2022, month = 1, day = 1, hour = 0, minute = 0, second = 0, millisecond = 0, timeZone = "UTC" });
        DateTime result = dateTimeString.DeserializeDateTime();
        Assert.Equal(new DateTime(2022, 1, 1, 0, 0, 0), result);
    }

    [Fact]
    public void TestFirstDayOfMonth()
    {
        DateTime date = new DateTime(2022, 1, 15);
        DateTime result = date.FirstDayOfMonth();
        Assert.Equal(new DateTime(2022, 1, 1), result);
    }

    [Fact]
    public void TestGetDateRange()
    {
        DateTime startDate = new DateTime(2022, 1, 1);
        var result = startDate.GetDateRange(2);
        Assert.Equal(new DateTime(2022, 1, 1), result.dateStart);
        Assert.Equal(new DateTime(2022, 2, 28), result.dateEnd);
    }

    [Fact]
    public void TestGetWeekNumber()
    {
        DateTime date = new DateTime(2022, 1, 1);
        int weekNumber = date.GetWeekNumber();
        Assert.Equal(1, weekNumber);
    }

    [Fact]
    public void TestGetDateRangeFromWeekNumber()
    {
        var result = DateUtility.GetDateRangeFromWeekNumber(1);
        Assert.Equal(new DateTime(DateTime.Now.Year, 1, 1), result[0]);
        Assert.Equal(new DateTime(DateTime.Now.Year, 1, 7), result[1]);
    }

    [Fact]
    public void TestGetDifference()
    {
        DateTime from = new DateTime(2022, 1, 1);
        DateTime to = new DateTime(2023, 1, 1);
        var result = from.GetDifference(to);
        Assert.Equal(1, result.Years);
        Assert.Equal(12, result.Months);
        Assert.Equal(365, result.Days);
        Assert.Equal(0, result.Hours);
        Assert.Equal(0, result.Minutes);
        Assert.Equal(0, result.Seconds);
    }
}