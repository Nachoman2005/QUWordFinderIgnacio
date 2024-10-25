using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUWordFinder.Models;

namespace QUWordFinder.Tests
{
    [TestClass]
    public class WordFinderTests
    {
        [TestMethod]
        public void Find_ShouldReturnTop10MostFrequentWords()
        {
            // Arrange
            var matrix = new List<string>
            {
                "abcd",
                "efgh",
                "ijkl",
                "mnop"
            };
            var wordFinder = new WordFinder(matrix);
            var wordstream = new List<string> { "abc", "efg", "ijk", "mnop", "abcd", "mnop", "mnop" };

            // Act
            var result = wordFinder.Find(wordstream);

            // Assert
            var expected = new List<string> { "mnop", "abc", "efg", "ijk", "abcd" };
            CollectionAssert.AreEqual(expected, new List<string>(result));
        }

        [TestMethod]
        public void Find_ShouldSkipWordsTooLargeToFitInMatrix()
        {
            // Arrange
            var matrix = new List<string>
            {
                "abcd",
                "efgh",
                "ijkl",
                "mnop"
            };
            var wordFinder = new WordFinder(matrix);
            var wordstream = new List<string> { "abcdefgh", "ijklmnop", "mnop" };

            // Act
            var result = wordFinder.Find(wordstream);

            // Assert
            var expected = new List<string> { "mnop" };
            CollectionAssert.AreEqual(expected, new List<string>(result));
        }

        [TestMethod]
        public void Find_ShouldReturnEmptyIfNoWordsFound()
        {
            // Arrange
            var matrix = new List<string>
            {
                "abcd",
                "efgh",
                "ijkl",
                "mnop"
            };
            var wordFinder = new WordFinder(matrix);
            var wordstream = new List<string> { "xyz", "uvw" };

            // Act
            var result = wordFinder.Find(wordstream);

            // Assert
            Assert.AreEqual(0, new List<string>(result).Count);
        }
    }
}