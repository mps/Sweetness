using System;
using System.Text.RegularExpressions;

namespace Sweetness
{
    public static class Strings
    {
        public static bool Matches(this string source, string comparison)
        {
            return string.Equals(source, comparison, StringComparison.OrdinalIgnoreCase);
        }

        public static bool MatchesWithTrimming(this string source, string comparison)
        {
            return string.Equals(source.Trim(), comparison.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsAlpha(this string source)
        {
            return !Regex.IsMatch(source, RegexPatterns.ALPHA);
        }

        public static bool IsAlphaNumeric(this string source)
        {
            return !Regex.IsMatch(source, RegexPatterns.ALPHA_NUMERIC);
        }

        public static bool IsAlphaNumeric(this string source, bool allowSpaces)
        {
            if (allowSpaces)
                return !Regex.IsMatch(source, RegexPatterns.ALPHA_NUMERIC_SPACE);
            return IsAlphaNumeric(source);
        }

        public static bool IsNumeric(this string source)
        {
            return !Regex.IsMatch(source, RegexPatterns.NUMERIC);
        }

        public static bool IsEmail(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.EMAIL);
        }

        public static bool IsLowerCase(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.LOWER_CASE);
        }

        public static bool IsUpperCase(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.UPPER_CASE);
        }

        public static bool IsGuid(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.GUID);
        }

        public static bool IsZipCode(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.US_ZIPCODE_PLUS_FOUR_OPTIONAL);
        }

        public static bool IsZipCodeFive(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.US_ZIPCODE);
        }

        public static bool IsZipCodeFivePlusFour(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.US_ZIPCODE_PLUS_FOUR);
        }

        public static bool IsSocialSecurityNumber(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.SOCIAL_SECURITY);
        }

        public static bool IsIPAddress(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.IP_ADDRESS);
        }

        public static bool IsUSTelephoneNumber(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.US_TELEPHONE);
        }

        public static bool IsUSCurrency(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.US_CURRENCY);
        }

        public static bool IsUrl(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.URL);
        }

        public static bool IsStrongPassword(this string source)
        {
            return Regex.IsMatch(source, RegexPatterns.STRONG_PASSWORD);
        }
    }
}