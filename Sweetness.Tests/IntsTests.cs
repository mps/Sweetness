using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Sweetness.Tests
{
    [TestFixture]
    public class IntsTests
    {
        [Test]
        public void Test_To()
        {
            3.To(3).Count().ShouldBe(1);
            3.To(5).Count().ShouldBe(3);
            3.To(1).Count().ShouldBe(3);
            0.To(-10).Count().ShouldBe(11);
        }
    }
}