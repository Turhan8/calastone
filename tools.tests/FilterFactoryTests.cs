using Microsoft.VisualStudio.TestTools.UnitTesting;
using tools;

namespace tools.tests
{
    [TestClass]
    public class FilterFactoryTests
    {
        [TestMethod]
        public void LessThanThreeLetters_ReturnsTrue_WhenWordShorterThan3()
        {
            Assert.IsTrue(FilterFactory.LessThanThreeLetters("aa"));
        }

        [TestMethod]
        public void LessThanThreeLetters_ReturnsFalse_WhenWordLongerThan3()
        {
            Assert.IsFalse(FilterFactory.LessThanThreeLetters("aaaa"));
        }

        [TestMethod]
        public void LessThanThreeLetters_ReturnsTrue_WhenWordEmpty()
        {
            Assert.IsTrue(FilterFactory.LessThanThreeLetters(""));
        }

        [TestMethod]
        public void HasCharSmallT_ReturnsTrue_WhenWordHasSmallT()
        {
            Assert.IsTrue(FilterFactory.HasCharSmallT("ata"));
        }

        [TestMethod]
        public void HasCharSmallT_ReturnsFalse_WhenWordHasNoT()
        {
            Assert.IsFalse(FilterFactory.HasCharSmallT("aa"));
        }

    }
}
