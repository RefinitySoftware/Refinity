namespace Refinity.Date
{
	public static class DateUtility
	{
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

        public static int QuarterlyFromMonth(this DateTime value)
        {
            return ((value.Month - 1) / 4) + 1;
        }

        public static int QuarterFromMonth(this DateTime value)
        {
            return ((value.Month - 1) / 3) + 1;
        }
    }
}

