using System;
using System.Collections.Generic;

namespace tools
{
    public class FilterFactory
    {
        public static Predicate<string> LessThanThreeLetters = word => word.Length < 3;

        public static Predicate<string> HasCharSmallT = word => word.Contains('t');

        public static Predicate<string> MiddleLetterIsWowel = word =>
        {
            HashSet<char> wovelLetters = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            int n = word.Length;
            if (n % 2 == 0)
            {
                char middleChar1 = word[n / 2 - 1];
                char middleChar2 = word[n / 2];
                return wovelLetters.Contains(middleChar1) && wovelLetters.Contains(middleChar2);
            }
            else
            {
                char middleChar = word[n / 2];
                return wovelLetters.Contains(middleChar);
            }
        };

        public static Predicate<char> CharIsPanctuationMark = c =>
        {
            HashSet<char> panctuationMarks = new HashSet<char> { ',', '\'', ':', ';', '!', '(', ')', '`' };
            return panctuationMarks.Contains(c);
        };
    }
}