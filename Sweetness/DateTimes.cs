using System;

namespace Sweetness
{
    public static class DateTimes
    {
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