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

            var fileReader = new CustomFileReader(filePath, bufferSize, filters);

            foreach (string word in fileReader)
                Console.Write(word + " ");
            Console.WriteLine();
        }
    }
}
