using Refinity.Date;

[TestFixture]
public class DateUtilityTests
{
    [Test]
    public void Add_AddsCorrectly()
    {
        var date = new DateTime(2000, 1, 1);
        var result = date.Add(1, 2, 3, 4, 5, 6);
        Assert.That(result, Is.EqualTo(new DateTime(2001, 3, 4, 4, 5, 6)));
    }

    [Test]
    public void CalculateAge_ReturnsCorrectAge()
    {
        var birthDate = new DateTime(2000, 1, 1);
        var age = birthDate.CalculateAge();
        Assert.That(age, Is.EqualTo(DateTime.Today.Year - 2000));
    }

    [Test]
    public void CalculateAge_WithDate_ReturnsCorrectAge()
    {
        var birthDate = new DateTime(2000, 1, 1);
        var date = new DateTime(2020, 1, 1);
        var age = birthDate.CalculateAge(date);
        Assert.That(age, Is.EqualTo(20));
    }

    [Test]
    public void FirstDayOfMonth_ReturnsFirstDay()
    {
        var date = new DateTime(2000, 1, 15);
        var result = date.FirstDayOfMonth();
        Assert.That(result, Is.EqualTo(new DateTime(2000, 1, 1)));
    }

    [Test]
    public void GetDateRange_ReturnsCorrectRange()
    {
        var startDate = new DateTime(2000, 1, 15);
        var result = startDate.GetDateRange(2);
        Assert.That(result.dateStart, Is.EqualTo(new DateTime(2000, 1, 1)));
        Assert.That(result.dateEnd, Is.EqualTo(new DateTime(2000, 2, 29)));
    }
}