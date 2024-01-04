using System.Globalization;
using Newtonsoft.Json;

namespace Refinity.Date;
public static class DateUtility
{

    /// <summary>
    /// Adds a specified number of years, months, days, hours, minutes, and seconds to the given DateTime value. TEST TEST TEST
    /// </summary>
    /// <param name="value">The DateTime value to which the specified time interval should be added.</param>
    /// <param name="years">The number of years to add. The default value is 0.</param>
    /// <param name="months">The number of months to add. The default value is 0.</param>
    /// <param name="days">The number of days to add. The default value is 0.</param>
    /// <param name="hours">The number of hours to add. The default value is 0.</param>
    /// <param name="minutes">The number of minutes to add. The default value is 0.</param>
    /// <param name="seconds">The number of seconds to add. The default value is 0.</param>
    /// <returns>A new DateTime value that is the result of adding the specified time interval to the original DateTime value.</returns>
    public static DateTime Add(this DateTime value, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0)
    {
        return value.AddYears(years).AddMonths(months).AddDays(days).AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
    }

    /// <summary>
    /// Calculates the age based on the provided birth date.
    /// </summary>
    /// <param name="birthDate">The birth date.</param>
    /// <returns>The calculated age.</returns>
    public static int CalculateAge(this DateTime birthDate)
    {
        var today = DateTime.Today;
        if (birthDate > today)
        {
            throw new ArgumentException("Birth date cannot be in the future.");
        }
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }

    /// <summary>
    /// Deserializes a string representation of a DateTime object.
    /// </summary>
    /// <param name="dateTimeString">The string representation of the DateTime object.</param>
    /// <returns>The deserialized DateTime object.</returns>
    public static DateTime DeserializeDateTime(this string dateTimeString)
    {
        var complexObject = JsonConvert.DeserializeObject<dynamic>(dateTimeString);
        if (complexObject == null)
        {
            throw new Exception("Invalid JSON string format.");
        }
        return new DateTime(
            complexObject.year,
            complexObject.month,
            complexObject.day,
            complexObject.hour,
            complexObject.minute,
            complexObject.second,
            complexObject.millisecond,
            complexObject.timeZone
        );
    }

    /// <summary>
    /// Returns the first day of the month for the specified DateTime value.
    /// </summary>
    /// <param name="value">The DateTime value.</param>
    /// <returns>The first day of the month.</returns>
    public static DateTime FirstDayOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, 1);
    }

    public static DateRangeModel GetDateRange(this DateTime startDate, int numberOfMonths, bool startToFirst = false)
    {
        if (numberOfMonths <= 0)
        {
            throw new ArgumentException("Number of months must be greater than zero.");
        }

        var start = startToFirst ? startDate : startDate.FirstDayOfMonth();
        var end = startDate.FirstDayOfMonth().AddMonths(numberOfMonths).AddDays(-1);

        if (end < start)
        {
            throw new ArgumentException("Invalid date range. End date is before start date.");
        }

        DateRangeModel dateRange = new DateRangeModel
        {
            dateStart = start,
            dateEnd = end,
            dateRange = new List<DateTime>() {
                start,
                end
            }
        };

        return dateRange;
    }

    /// <summary>
    /// Gets the week number of the specified date.
    /// </summary>
    /// <param name="value">The date value.</param>
    /// <returns>The week number of the specified date.</returns>
    public static int GetWeekNumber(this DateTime value)
    {
        return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    }

    /// <summary>
    /// Gets the date range (start and end dates) for a given week number.
    /// </summary>
    /// <param name="weekNumber">The week number.</param>
    /// <returns>An array of DateTime objects representing the start and end dates of the week.</returns>
    public static DateTime[] GetDateRangeFromWeekNumber(int weekNumber)
    {
        if (weekNumber < 1 || weekNumber > 52)
        {
            throw new Exception("Invalid week number.");
        }
        DateTime startOfWeek = new DateTime(DateTime.Now.Year, 1, 1);
        startOfWeek = startOfWeek.AddDays((weekNumber - 1) * 7);
        DateTime endOfWeek = startOfWeek.AddDays(6);

        return new DateTime[] { startOfWeek, endOfWeek };
    }

    public static DateDifference GetDifference(this DateTime from, DateTime to)
    {
        DateDifference difference = new();

        TimeSpan ts = from - to;

        difference.Years = ts.Days / 365;
        difference.Months = ts.Days / 30;
        difference.Days = ts.Days;
        difference.Hours = ts.Hours;
        difference.Minutes = ts.Minutes;
        difference.Seconds = ts.Seconds;

        return difference;
    }

    /// <summary>
    /// Returns the last day of the month for the specified DateTime value.
    /// </summary>
    /// <param name="value">The DateTime value.</param>
    /// <returns>The last day of the month.</returns>
    public static DateTime LastDayOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
    }

    /// <summary>
    /// Calculates the quarterly value from the given month.
    /// </summary>
    /// <param name="value">The month value.</param>
    /// <returns>The quarterly value.</returns>
    public static int QuarterlyFromMonth(this DateTime value)
    {
        return ((value.Month - 1) / 4) + 1;
    }

    /// <summary>
    /// Calculates the quarterly value from a given month.
    /// </summary>
    /// <param name="value">The month value.</param>
    /// <returns>The quarterly value.</returns>
    public static int QuarterlyFromMonth(Months value)
    {
        return (((int)value - 1) / 4) + 1;
    }

    /// <summary>
    /// Calculates the quarterly value from a given month.
    /// </summary>
    /// <param name="value">The month value.</param>
    /// <returns>The quarterly value.</returns>
    public static int QuarterlyFromMonth(this int value)
    {
        if (value < 1 || value > 12)
        {
            throw new Exception("Invalid month value.");
        }
        return ((value - 1) / 4) + 1;
    }

    /// <summary>
    /// Calculates the quarter from the given month.
    /// </summary>
    /// <param name="value">The month value.</param>
    /// <returns>The quarter corresponding to the given month.</returns>
    public static int QuarterFromMonth(this DateTime value)
    {
        return ((value.Month - 1) / 3) + 1;
    }

    /// <summary>
    /// Calculates the quarter from a given month.
    /// </summary>
    /// <param name="value">The month value.</param>
    /// <returns>The quarter corresponding to the given month.</returns>
    public static int QuarterFromMonth(Months value)
    {
        return (((int)value - 1) / 3) + 1;
    }

    /// <summary>
    /// Calculates the quarter from a given month value.
    /// </summary>
    /// <param name="value">The month value.</param>
    /// <returns>The quarter corresponding to the month value.</returns>
    public static int QuarterFromMonth(this int value)
    {
        if (value < 1 || value > 12)
        {
            throw new Exception("Invalid month value.");
        }
        return ((value - 1) / 3) + 1;
    }

    /// <summary>
    /// Subtracts a specified number of years, months, days, hours, minutes, and seconds from the given DateTime value.
    /// </summary>
    /// <param name="value">The DateTime value to subtract from.</param>
    /// <param name="years">The number of years to subtract. Default is 0.</param>
    /// <param name="months">The number of months to subtract. Default is 0.</param>
    /// <param name="days">The number of days to subtract. Default is 0.</param>
    /// <param name="hours">The number of hours to subtract. Default is 0.</param>
    /// <param name="minutes">The number of minutes to subtract. Default is 0.</param>
    /// <param name="seconds">The number of seconds to subtract. Default is 0.</param>
    /// <returns>A new DateTime value that is the result of subtracting the specified years, months, days, hours, minutes, and seconds from the given DateTime value.</returns>
    public static DateTime Subtract(this DateTime value, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0)
    {
        return value.AddYears(-years).AddMonths(-months).AddDays(-days).AddHours(-hours).AddMinutes(-minutes).AddSeconds(-seconds);
    }

    /// <summary>
    /// Serializes a DateTime object into a JSON string representation.
    /// </summary>
    /// <param name="dateTime">The DateTime object to be serialized.</param>
    /// <returns>A JSON string representation of the DateTime object.</returns>
    public static string SerializeDateTime(this DateTime dateTime)
    {
        var complexObject = new
        {
            year = dateTime.Year,
            month = dateTime.Month,
            day = dateTime.Day,
            hour = dateTime.Hour,
            minute = dateTime.Minute,
            second = dateTime.Second,
            millisecond = dateTime.Millisecond,
            dayOfWeek = dateTime.DayOfWeek,
            dayOfYear = dateTime.DayOfYear,
            timeOfDay = dateTime.TimeOfDay,
            timeZone = dateTime.Kind
        };

        return JsonConvert.SerializeObject(complexObject);
    }

    /// <summary>
    /// Converts a string value to a nullable DateTime object.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>A nullable DateTime object representing the converted value, or null if the conversion fails.</returns>
    public static DateTime? ToDateTime(this string value)
    {
        DateTime result;
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value), "The value cannot be null or empty.");
        }

        try
        {
            if (!DateTime.TryParse(value, out result))
            {
                return null;
            }
        }
        catch (Exception)
        {
            throw;
        }

        return result;
    }
}
