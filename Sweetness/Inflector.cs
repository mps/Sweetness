using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sweetness
{
    public static class Inflector
    {
        private static readonly List<InflectorRule> Plurals = new List<InflectorRule>();
        private static readonly List<InflectorRule> Singulars = new List<InflectorRule>();
        private static readonly List<string> Uncountables = new List<string>();

        static Inflector()
        {
            AddPluralRule("$", "s");
            AddPluralRule("s$", "s");
            AddPluralRule("(ax|test)is$", "$1es");
            AddPluralRule("(octop|vir|alumn|nucle|foc|radi|syllab|fung|hippopotam|uter)us$", "$1i");
            AddPluralRule("(alias|status)$", "$1es");
            AddPluralRule("(bu)s$", "$1ses");
            AddPluralRule("(buffal|tomat|her|potat)o$", "$1oes");
            AddPluralRule("([ti])um$", "$1a");
            AddPluralRule("sis$", "ses");
            AddPluralRule("(?:([^f])fe|([lr])f)$", "$1$2ves");
            AddPluralRule("(hive)$", "$1s");
            AddPluralRule("([^aeiouy]|qu)y$", "$1ies");
            AddPluralRule("(x|ch|ss|sh)$", "$1es");
            AddPluralRule("(matr|vert|ind)ix|ex$", "$1ices");
            AddPluralRule("([m|l])ouse$", "$1ice");
            AddPluralRule("^(ox)$", "$1en");
            AddPluralRule("(quiz)$", "$1zes");
            AddPluralRule("(criteri|automat|phenomen|polyhedr)on$", "$1a");
            AddPluralRule("^(di)e$", "$1ce");

            AddSingularRule("s$", string.Empty);
            AddSingularRule("ss$", "ss");
            AddSingularRule("(n)ews$", "$1ews");
            AddSingularRule("([ti])a$", "$1um");
            AddSingularRule("((a)naly|(b)a|(d)iagno|(p)arenthe|(p)rogno|(s)ynop|(t)he)ses$", "$1$2sis");
            AddSingularRule("(^analy)ses$", "$1sis");
            AddSingularRule("([^f])ves$", "$1fe");
            AddSingularRule("(hive)s$", "$1");
            AddSingularRule("(tive)s$", "$1");
            AddSingularRule("([lr])ves$", "$1f");
            AddSingularRule("([^aeiouy]|qu)ies$", "$1y");
            AddSingularRule("(s)eries$", "$1eries");
            AddSingularRule("(m)ovies$", "$1ovie");
            AddSingularRule("(x|ch|ss|sh)es$", "$1");
            AddSingularRule("([m|l])ice$", "$1ouse");
            AddSingularRule("(bus)es$", "$1");
            AddSingularRule("(o)es$", "$1");
            AddSingularRule("(shoe)s$", "$1");
            AddSingularRule("(cris|ax|test)es$", "$1is");
            AddSingularRule("(octop|vir)i$", "$1us");
            AddSingularRule("(alias|status)$", "$1");
            AddSingularRule("(alias|status)es$", "$1");
            AddSingularRule("^(ox)en", "$1");
            AddSingularRule("(vert|ind)ices$", "$1ex");
            AddSingularRule("(matr)ices$", "$1ix");
            AddSingularRule("(quiz)zes$", "$1");
            AddSingularRule("^(pen)ce$", "$1ny");

            AddIrregularRule("person", "people");
            AddIrregularRule("man", "men");
            AddIrregularRule("child", "children");
            AddIrregularRule("sex", "sexes");
            AddIrregularRule("tax", "taxes");
            AddIrregularRule("move", "moves");
            AddIrregularRule("goose", "geese");
            AddIrregularRule("leaf", "leaves");
            AddIrregularRule("foot", "feet");
            AddIrregularRule("tooth", "teeth");

            AddUnknownCountRule("equipment");
            AddUnknownCountRule("information");
            AddUnknownCountRule("rice");
            AddUnknownCountRule("money");
            AddUnknownCountRule("species");
            AddUnknownCountRule("series");
            AddUnknownCountRule("fish");
            AddUnknownCountRule("sheep");
            AddUnknownCountRule("moose");
            AddUnknownCountRule("deer");
            AddUnknownCountRule("aircraft");
            AddUnknownCountRule("shrimp");
            AddUnknownCountRule("you");
            AddUnknownCountRule("pants");
            AddUnknownCountRule("shorts");
            AddUnknownCountRule("eyeglasses");
            AddUnknownCountRule("scissors");
            AddUnknownCountRule("offspring");
            AddUnknownCountRule("species");
            AddUnknownCountRule("elk");
            AddUnknownCountRule("kudos");
            AddUnknownCountRule("corps");
            AddUnknownCountRule("salmon");
            AddUnknownCountRule("bison");
            AddUnknownCountRule("swine");
        }

        private static void AddIrregularRule(string singular, string plural)
        {
            AddPluralRule(string.Concat("(", singular[0], ")", singular.Substring(1), "$"), string.Concat("$1", plural.Substring(1)));
            AddSingularRule(string.Concat("(", plural[0], ")", plural.Substring(1), "$"), string.Concat("$1", singular.Substring(1)));
        }

        private static void AddUnknownCountRule(string word)
        {
            Uncountables.Add(word.ToLower());
        }

        private static void AddPluralRule(string rule, string replacement)
        {
            Plurals.Add(new InflectorRule(rule, replacement));
        }

        private static void AddSingularRule(string rule, string replacement)
        {
            Singulars.Add(new InflectorRule(rule, replacement));
        }

        public static string MakePlural(this string word)
        {
            return ApplyRules(Plurals, word);
        }

        public static string MakeSingular(this string word)
        {
            return ApplyRules(Singulars, word);
        }

        private static string ApplyRules(IList<InflectorRule> rules, string word)
        {
            var result = word;
            if (!Uncountables.Contains(word.ToLower()))
            {
                for (var i = rules.Count - 1; i >= 0; i--)
                {
                    var currentPass = rules[i].Apply(word);
                    if (currentPass == null) continue;

                    result = currentPass;
                    break;
                }
            }

            return result;
        }

        public static string ToTitleCase(this string word)
        {
            return Regex.Replace(Humanize(AddUnderscores(word)), @"\b([a-z])", match => match.Captures[0].Value.ToUpper());
        }

        public static string Humanize(this string lowercaseAndUnderscoredWord)
        {
            return MakeInitialCaps(Regex.Replace(lowercaseAndUnderscoredWord, @"_", " "));
        }

        public static string ToProper(this string source)
        {
            return source.ToPascalCase();
        }

        public static string ToPascalCase(this string lowercaseAndUnderscoredWord)
        {
            return ToPascalCase(lowercaseAndUnderscoredWord, true);
        }

        public static string ToPascalCase(this string text, bool removeUnderscores)
        {
            if (string.IsNullOrEmpty(text)) return text;

            text = text.Replace("_", " ");
            var joinString = removeUnderscores ? string.Empty : "_";
            var words = text.Split(' ');
            if (words.Length > 1 || words[0].IsUpperCase())
            {
                for (var i = 0; i < words.Length; i++)
                {
                    if (words[i].Length <= 0) continue;

                    var word = words[i];
                    var restOfWord = word.Substring(1);

                    if (restOfWord.IsUpperCase())
                        restOfWord = restOfWord.ToLower(CultureInfo.CurrentUICulture);

                    var firstChar = char.ToUpper(word[0], CultureInfo.CurrentUICulture);
                    words[i] = string.Concat(firstChar, restOfWord);
                }
                return string.Join(joinString, words);
            }
            return string.Concat(words[0].Substring(0, 1).ToUpper(CultureInfo.CurrentUICulture), words[0].Substring(1));
        }

        public static string ToCamelCase(this string lowercaseAndUnderscoredWord)
        {
            return MakeInitialLowerCase(ToPascalCase(lowercaseAndUnderscoredWord));
        }

        public static string AddUnderscores(this string pascalCasedWord)
        {
            return Regex.Replace(Regex.Replace(Regex.Replace(pascalCasedWord, @"([A-Z]+)([A-Z][a-z])", "$1_$2"), @"([a-z\d])([A-Z])", "$1_$2"), @"[-\s]", "_").ToLower();
        }

        public static string MakeInitialCaps(this string word)
        {
            return string.Concat(word.Substring(0, 1).ToUpper(), word.Substring(1).ToLower());
        }

        public static string MakeInitialLowerCase(this string word)
        {
            return string.Concat(word.Substring(0, 1).ToLower(), word.Substring(1));
        }

        public static string AddOrdinalSuffix(this string number)
        {
            if (number.IsNumeric())
            {
                var n = int.Parse(number);
                var nMod100 = n % 100;

                if (nMod100 >= 11 && nMod100 <= 13)
                    return string.Concat(number, "th");

                switch (n % 10)
                {
                    case 1:
                        return string.Concat(number, "st");
                    case 2:
                        return string.Concat(number, "nd");
                    case 3:
                        return string.Concat(number, "rd");
                    default:
                        return string.Concat(number, "th");
                }
            }

            return number;
        }

        public static string ConvertUnderscoresToDashes(this string underscoredWord)
        {
            if (!string.IsNullOrWhiteSpace(underscoredWord))
            {
                underscoredWord = underscoredWord.Replace('_', '-');
            }

            return underscoredWord;
        }

        #region Nested type: InflectorRule

        private class InflectorRule
        {
            private readonly Regex _regex;
            private readonly string _replacement;

            public InflectorRule(string regexPattern, string replacementText)
            {
                _regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
                _replacement = replacementText;
            }

            public string Apply(string word)
            {
                if (!_regex.IsMatch(word))
                    return null;

                var replace = _regex.Replace(word, _replacement);
                if (word == word.ToUpper())
                    replace = replace.ToUpper();

                return replace;
            }
        }

        #endregion
    }
}