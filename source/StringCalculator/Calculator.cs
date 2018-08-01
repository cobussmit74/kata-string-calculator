using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            var separators = new List<string> { ",", "\n" };

            if (HasCustomSeparators(input))
            {
                separators.AddRange(GetCustomSeparators(input));

                input = GetNumbersToSum(input);
            }

            return input
                .Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .CheckForNegatives()
                .Where(n => n <= SumInclusionUpperLimit)
                .Sum();
        }

        private const int SumInclusionUpperLimit = 1000;

        private static bool HasCustomSeparators(string input)
        {
            return input.StartsWith("//");
        }

        private static IEnumerable<string> GetCustomSeparators(string input)
        {
            return input
                .Skip(2)
                .TakeWhile(c => c != '\n')
                .AsString()
                .TrimStart('[')
                .TrimEnd(']')
                .Split(new[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string GetNumbersToSum(string input)
        {
            return input
                .SkipWhile(c => c != '\n')
                .Skip(1)
                .AsString();
        }
    }
}