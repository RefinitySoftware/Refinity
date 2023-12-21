namespace Refinity.Date
{
    public static class DateUtility
    {
        /// <summary>
        /// Convert string to datetime
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
    }
}

