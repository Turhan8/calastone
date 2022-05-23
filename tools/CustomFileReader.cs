using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace tools
{
    /// <summary>
    /// Custom File reader to enumerate the words in a batch
    /// </summary>
    public class CustomFileReader : IEnumerable<string>
    {
        private readonly char[] splitDelimiters = new Char[] { ' ', '.', '?' };
        private readonly HashSet<char> removeChars = new HashSet<char> { ',', '\'', ':', ';', '!', '(', ')', '`' };
        private int readBufferSize = 1024;

        List<Predicate<string>> wordFilters;

        private string filePath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="bufferSize">Size of the batch,should be greater than 0</param>
        public CustomFileReader(string path, int bufferSize, List<Predicate<string>> filters)
        {
            if (File.Exists(path))
                filePath = path;
            else
                throw new ArgumentException($"This file file does not exist: {path} ");

            if (bufferSize > 0)
                readBufferSize = bufferSize;
            else
                throw new ArgumentException("Batch size should be greater than Zero", "batchSize");

            wordFilters = filters;
        }

        // IEnumerable interface
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<string> GetEnumerator()
        {
            string[] words;
            string fragment = string.Empty;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8, true, readBufferSize))
            {
                while (reader.Peek() > 0)
                {
                    char[] block = new char[readBufferSize];
                    reader.ReadBlock(block, 0, readBufferSize);
                    //remove quotation marks
                    var charsWithoutQuotations = block.Where(c => !FilterFactory.CharIsPanctuationMark(c)).ToArray();
                    //make a sentence from chars
                    string blockString = fragment + new string((charsWithoutQuotations));
                    //split sentences into words 
                    words = blockString.Split(splitDelimiters);
                    //handle split words at the end
                    fragment = words[words.Length - 1];

                    var filteredWords = words.Take(words.Length - 1).Where(word => !wordFilters.Any(filter => filter(word)));

                    foreach (string word in filteredWords)
                        yield return word;
                }

                yield return fragment;
            }
        }
    }
}