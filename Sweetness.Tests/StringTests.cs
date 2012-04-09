using System;
using NUnit.Framework;
using Shouldly;

namespace Sweetness.Tests
{
    [TestFixture]
    public class StringTests
    {
        [Test]
        public void Test_ToDateTime()
        {
            "2005-02-27 23:50".ToDateTime().ShouldBe(new DateTime(2005, 2, 27, 23, 50, 0, DateTimeKind.Utc));
            "2005-02-27 23:50".ToDateTime(true).ShouldBe(new DateTime(2005, 2, 27, 23, 50, 0, DateTimeKind.Local));
            "2005-02-27T23:50:19".ToDateTime().ShouldBe(new DateTime(2005, 2, 27, 23, 50, 19, DateTimeKind.Utc));
            "2005-02-27T23:50:19".ToDateTime(true).ShouldBe(new DateTime(2005, 2, 27, 23, 50, 19, DateTimeKind.Local));
            "".ToDateTime().ShouldBe(null);
        }

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
    }
}