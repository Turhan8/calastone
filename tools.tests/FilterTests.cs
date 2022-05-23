using Microsoft.VisualStudio.TestTools.UnitTesting;
using tools;

namespace tools.tests
{
    [TestClass]
    public class FilterTests
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
        public void LessThanThreeLetters_ReturnsFalse_WhenWordLengthIs3()
        {
            Assert.IsFalse(FilterFactory.LessThanThreeLetters("aaa"));
        }

        [TestMethod]
        public void LessThanThreeLetters_ReturnsTrue_WhenWordEmpty()
        {
            Assert.IsTrue(FilterFactory.LessThanThreeLetters(""));
        }

        [TestMethod]
        public void HasCharSmallT_ReturnsTrue_WhenWordHasJustSmallT()
        {
            Assert.IsTrue(FilterFactory.HasCharSmallT("t"));
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

        [TestMethod]
        public void HasCharSmallT_ReturnsFalse_WhenWordIsEmpty()
        {
            Assert.IsTrue(FilterFactory.HasCharSmallT(" "));
        }

        [TestMethod]
        public void MiddleLetterIsWowel_ReturnsTrue_WhenWordIsEmpty()
        {
            Assert.IsTrue(FilterFactory.MiddleLetterIsWowel(" "));
        }

        [TestMethod]
        public void MiddleLetterIsWowel_ReturnsTrue_WhenWordIsSingleWovel()
        {
            Assert.IsTrue(FilterFactory.MiddleLetterIsWowel("a"));
        }

        [TestMethod]
        public void MiddleLetterIsWowel_ReturnsTrue_WhenWordIsDoubleWovel()
        {
            Assert.IsTrue(FilterFactory.MiddleLetterIsWowel("aa"));
        }

        [TestMethod]
        public void MiddleLetterIsWowel_ReturnsFalse_WhenWordIsNotWovelMillde()
        {
            Assert.IsFalse(FilterFactory.MiddleLetterIsWowel("ab"));
        }
    }
}
