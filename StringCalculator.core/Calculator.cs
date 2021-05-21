using StringCalculator.core.helpers;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.core
{
    public class Calculator
    {
        private const char DefaultDelimiter = ',';
        private const int Max_Number = 1000;

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return default;

            var delimiter = GetDelimiter(numbers);

            string input = delimiter == DefaultDelimiter
                ? numbers
                : numbers.Split('\n')[1];

            var numbersArray = input
                .Split(delimiter, '\n')
                .Select(int.Parse);

            Validate(numbersArray);

            return numbersArray
                .LessThan(Max_Number)
                .Sum();
        }

        private IEnumerable<int> FilterGreaterThanMax(IEnumerable<int> numbers)
        {
            return numbers.Where(n => n <= Max_Number);
        }

        private static void Validate(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0);

            if (negatives.Any())
                throw new NegativeNumbersNotAllowedException("Negatives not allowed, " + string.Join(", ", negatives));
        }

        private char GetDelimiter(string input)
        {
            if (!input.StartsWith("//"))
                return DefaultDelimiter;

            return input
                .Split('\n')[0]
                .ToCharArray()[2];
        }
    }
}
