using System;
using System.Collections.Generic;
using System.Linq;

namespace tools
{
    public class FilterFactory
    {
        public static Predicate<string> LessThanThreeLetters = word => word.Trim().Length < 3;

        public static Predicate<string> HasCharSmallT = word => word.Trim().Contains('t') || word.Trim() == string.Empty;

        public static Predicate<string> MiddleLetterIsWowel = word =>
        {
            HashSet<char> wovelLetters = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            string plainWord = new string((from c in word
                                           where char.IsLetterOrDigit(c)
                                           select c).ToArray());

            int n = plainWord.Length;
            if (n >= 1)
            {
                if (n % 2 == 0)
                {
                    char middleChar1 = plainWord[n / 2 - 1];
                    char middleChar2 = plainWord[n / 2];
                    return wovelLetters.Contains(middleChar1) && wovelLetters.Contains(middleChar2);
                }
                else
                {
                    char middleChar = plainWord[n / 2];
                    return wovelLetters.Contains(middleChar);
                }
            }
            else
                return true; // remove empty words
        };
    }
}