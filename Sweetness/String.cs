using System;

namespace Sweetness
{
    public static class String
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

        public static bool Matches(this string source, string comparison)
        {
            return string.Equals(source, comparison, StringComparison.OrdinalIgnoreCase);
        }

        public static bool MatchesWithTrimming(this string source, string comparison)
        {
            return string.Equals(source.Trim(), comparison.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}