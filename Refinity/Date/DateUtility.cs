using System.Globalization;
using Newtonsoft.Json;

namespace Refinity.Date
{
    public static class DateUtility
    {
        /// <summary>
        /// Convert string to DateTime
        /// </summary>
        /// <param name="value">value to convert to date</param>
        /// <returns>returns the value as the date of the string if the conversion was successful, otherwise null</returns>
        public static DateTime? ToDateTime(this string value)
        {
            DateTime result;
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

        /// <summary>
        /// Check which quarterly the month is in
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns>returns the quarterly number</returns>
        public static int QuarterlyFromMonth(this DateTime value)
        {
            return ((value.Month - 1) / 4) + 1;
        }

        /// <summary>
        /// Check which quarter the month is in
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns>returns the quarter number</returns>
        public static int QuarterFromMonth(this DateTime value)
        {
            return ((value.Month - 1) / 3) + 1;
        }

        /// <summary>
        /// Verify age from a date
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns>Returns true if the check was successful, false otherwise</returns>
        public static bool AdultAgeFromDate(this DateTime value)
        {
            int age = value.Year - DateTime.Now.Year;
            if (value.AddYears(age) < DateTime.Now) age--;

            return age > 18;
        }

        /// <summary>
        /// Calculate the age from a date
        /// </summary>
        /// <param name="birthDate">Birth date</param>
        /// <returns>Age</returns>
        public static int CalculateAge(this DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        /// <summary>
        /// Get the difference between two dates
        /// </summary>
        /// <param name="from">date to check from</param>
        /// <param name="to">date to check to</param>
        /// <returns>returns the difference between the two dates</returns>
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
        /// Add a value to a date
        /// </summary>
        /// <param name="value">value to add to</param>
        /// <param name="years">years to add</param>
        /// <param name="months">months to add</param>
        /// <param name="days">days to add</param>
        /// <param name="hours">hours to add</param>
        /// <param name="minutes">minutes to add</param>
        /// <param name="seconds">seconds to add</param>
        /// <returns>returns the value with the added values</returns>
        public static DateTime Add(this DateTime value, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0)
        {
            return value.AddYears(years).AddMonths(months).AddDays(days).AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
        }

        /// <summary>
        /// Subtract a value from a date
        /// </summary>
        /// <param name="value">value to subtract from</param>
        /// <param name="years">years to subtract</param>
        /// <param name="months">months to subtract</param>
        /// <param name="days">days to subtract</param>
        /// <param name="hours">hours to subtract</param>
        /// <param name="minutes">minutes to subtract</param>
        /// <param name="seconds">seconds to subtract</param>
        /// <returns>returns the value with the subtracted values</returns>
        public static DateTime Subtract(this DateTime value, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0)
        {
            return value.AddYears(-years).AddMonths(-months).AddDays(-days).AddHours(-hours).AddMinutes(-minutes).AddSeconds(-seconds);
        }

        /// <summary>
        /// Get the first day of the month
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns>returns the first day of the month</returns>
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        /// <summary>
        /// Get the last day of the month
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns>returns the last day of the month</returns>
        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
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
        /// Get date from week number
        /// </summary>
        /// <param name="weekNumber">week number to check</param>
        /// <returns>Returns the date range from the week number</returns>
        public static DateTime[] GetDateRangeFromWeekNumber(int weekNumber)
        {
            DateTime startOfWeek = new DateTime(DateTime.Now.Year, 1, 1);
            startOfWeek = startOfWeek.AddDays((weekNumber - 1) * 7);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            return new DateTime[] { startOfWeek, endOfWeek };
        }

        /// <summary>
        /// Serialize a DateTime object to a string format that includes time zone information.
        /// </summary>
        /// <param name="dateTime">The DateTime object to serialize.</param>
        /// <returns>A string representation of the DateTime object with time zone information.</returns>
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
        /// Deserialize a string representation of a DateTime object with time zone information.
        /// </summary>
        /// <param name="dateTimeString">The string representation of the DateTime object with time zone information.</param>
        /// <returns>A DateTime object.</returns>
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
    }
}

