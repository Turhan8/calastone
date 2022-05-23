using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using tools;

namespace textFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];
            int bufferSize = 5;

            List<Predicate<string>> filters = new List<Predicate<string>>
            {
                FilterFactory.MiddleLetterIsWowel,
                FilterFactory.LessThanThreeLetters,
                FilterFactory.HasCharSmallT
            };

            var fileReader = new CustomFileReader(filePath, bufferSize);

            var words = fileReader.ToList();

            var filteredWords = words.Where(word => !filters.Any(filter => filter(word)));

            foreach (string word in filteredWords)
                Console.Write(word + " ");
            Console.WriteLine();
        }
    }
}
