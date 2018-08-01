using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public static class ArrayExtensions
    {
        public static IEnumerable<int> CheckForNegatives(this IEnumerable<int> input)
        {
            var negatives = input.Where(n => n < 0).Select(n => n.ToString());
            if (negatives.Any())
            {
                throw new Exception($"Negatives not allowed : {string.Join(",", negatives)}");
            }

            return input;
        }

        public static string AsString(this IEnumerable<char> input)
        {
            return new string(input.ToArray());
        }
    }
}