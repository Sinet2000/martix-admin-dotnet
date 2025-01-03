using System.Globalization;

namespace Dexlaris.Core.Common.Extensions
{
    public static class DateTimeExt
    {
        public static bool IsEmpty(this DateTime dateTime)
        {
            return dateTime == default;
        }

        public static bool HasValue(this DateTime dateTime)
        {
            return !dateTime.IsEmpty();
        }
        
        public static bool AreDatesEqual(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year &&
                   date1.Month == date2.Month &&
                   date1.Day == date2.Day &&
                   date1.Hour == date2.Hour &&
                   date1.Minute == date2.Minute;
        }

        public static string ToDateWithTime(this DateTime dateTime)
        {
            return dateTime.ToString("dd.MM.yyyy", CultureInfo.CurrentCulture) + " " + dateTime.ToString("HH:mm");
        }
        
        public static int? GetYearsPassedFromDate(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            DateTime currentDate = DateTime.Today;
            int yearsPassed = currentDate.Year - dateTime.Value.Year;

            if (currentDate < dateTime.Value.AddYears(yearsPassed))
            {
                yearsPassed--;
            }

            return yearsPassed;
        }
    }
}