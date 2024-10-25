using System.Text;

namespace QUWordFinder.Models
{
    public class WordFinder
    {
        private readonly List<string> matrix;  // Store the matrix
        private readonly int rows;
        private readonly int cols;

        public WordFinder(IEnumerable<string> matrix)
        {
            this.matrix = matrix.ToList();
            this.rows = this.matrix.Count;
            this.cols = this.matrix[0].Length;
        }
        // Find the most frequent words in the matrix

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var wordSet = new HashSet<string>(wordstream); // Remove duplicate words from the stream
            var wordFrequency = new Dictionary<string, int>();

            // Search for words in the matrix
            foreach (var word in wordSet)
            {
                if (word.Length > this.rows && word.Length > this.cols)
                    continue;  // Skip words that are too large to fit in the matrix

                int count = SearchWordInMatrix(word);
                if (count > 0)
                {
                    wordFrequency[word] = count;
                }
            }

            // Return the top 10 most frequent words
            return wordFrequency
                .OrderByDescending(kv => kv.Value)
                .Take(10)
                .Select(kv => kv.Key);
        }

        // Search for a word in both horizontal and vertical directions
        private int SearchWordInMatrix(string word)
        {
            int count = 0;

            // Search horizontally (left to right)
            for (int i = 0; i < rows; i++)
            {
                string row = matrix[i];
                if (row.Contains(word))
                {
                    count++;
                }
            }

            // Search vertically (top to bottom)
            for (int col = 0; col < cols; col++)
            {
                StringBuilder bld = new StringBuilder();
                string verticalWord = "";
                for (int row = 0; row < rows; row++)
                {
                   bld.Append( matrix[row][col]);
                }
                verticalWord = bld.ToString();
                if (verticalWord.Contains(word))
                {
                    count++;
                }
            }

            return count;
        }
    }
}