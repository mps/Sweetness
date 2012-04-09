using NUnit.Framework;
using Shouldly;

namespace Sweetness.Tests
{
    [TestFixture]
    public class StringsTests
    {
        [Test]
        public void Test_Matches()
        {
            "".Matches("").ShouldBe(true);
            "string".Matches("String").ShouldBe(true);
            "string".Matches("String ").ShouldBe(false);
            "123123adsfasdf".ToUpper().Matches("123123adsfasdf").ShouldBe(true);
        }

        [Test]
        public void Test_MatchesWithTrimming()
        {
            "      ".MatchesWithTrimming("").ShouldBe(true);
            "string".MatchesWithTrimming("String").ShouldBe(true);
            "string".MatchesWithTrimming("String ").ShouldBe(true);
            "123123adsfasdf   ".ToUpper().MatchesWithTrimming("123123adsfasdf").ShouldBe(true);
        }

        [Test]
        public void Test_Pluralize()
        {
            "goose".Pluralize().ShouldBe("geese");
            "goose".Pluralize(1).ShouldBe("goose");
            "geese".Pluralize(1).ShouldBe("goose");
        }
    }
}