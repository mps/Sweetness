using System;

namespace Sweetness
{
    public static class DateTimes
    {
        public static DateTime? ToDateTime(this string source, bool local = false)
        {
            DateTime date;

            var parsed = DateTime.TryParse(source, out date);
            if (!parsed)
                return null;

            DateTime.SpecifyKind(date, local ? DateTimeKind.Local : DateTimeKind.Utc);

            return date;
        }

        public static DateTime DaysAgo(this int days)
        {
            var span = new TimeSpan(days, 0, 0, 0);
            return DateTime.Now.Subtract(span);
        }

        public static DateTime DaysFromNow(this int days)
        {
            var span = new TimeSpan(days, 0, 0, 0);
            return DateTime.Now.Add(span);
        }

        public static DateTime HoursAgo(this int hours)
        {
            var span = new TimeSpan(hours, 0, 0);
            return DateTime.Now.Subtract(span);
        }

        public static DateTime HoursFromNow(this int hours)
        {
            var span = new TimeSpan(hours, 0, 0);
            return DateTime.Now.Add(span);
        }

        public static DateTime MinutesAgo(this int minutes)
        {
            var span = new TimeSpan(0, minutes, 0);
            return DateTime.Now.Subtract(span);
        }

        public static DateTime MinutesFromNow(this int minutes)
        {
            var span = new TimeSpan(0, minutes, 0);
            return DateTime.Now.Add(span);
        }

        public static DateTime SecondsAgo(this int seconds)
        {
            var span = new TimeSpan(0, 0, seconds);
            return DateTime.Now.Subtract(span);
        }

        public static DateTime SecondsFromNow(this int seconds)
        {
            var span = new TimeSpan(0, 0, seconds);
            return DateTime.Now.Add(span);
        }
    }
}