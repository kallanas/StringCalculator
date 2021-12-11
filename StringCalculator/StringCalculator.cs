using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private static int MaxNumberAllowed = 1000;

        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return default;
            }

            var delimiterResult = DelimiterParser.Parse(numbers);

            var parsedNumbers = delimiterResult.Numbers
                .Split(delimiterResult.Delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Select(n => int.Parse(n))
                .ToList();

            ValidateForNegativeNumbers(parsedNumbers);

            var filteredNumbers = FilterLessThanMaxAllowed(parsedNumbers);

            return filteredNumbers.Sum();
        }

        private static List<int> FilterLessThanMaxAllowed(List<int> numbers)
        {
            return numbers
                .Where(n => n <= MaxNumberAllowed)
                .ToList();
        }

        private static void ValidateForNegativeNumbers (List<int> numbers)
        {
            var negativeNumbers = numbers
                .Where(n => n < 0)
                .ToArray();

            if (negativeNumbers.Any())
            {
                throw new NegativesNotAllowedException($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
            }
        }
    }
}
