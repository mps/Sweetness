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
    }
}