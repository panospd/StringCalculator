using StringCalculator.core.helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.core
{
    public class Calculator
    {
        private const string DefaultDelimiter = ",";
        private const int Max_Number = 1000;

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return default;

            var delimiters = ParseDelimiters(numbers);

            string input = !numbers.HasCustomDelimiter()
                ? numbers
                : numbers.Split('\n')[1];

            var numbersArray = input
                .Split(delimiters.Values(), System.StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            Validate(numbersArray);

            return numbersArray
                .LessThan(Max_Number)
                .Sum();
        }

        private static void Validate(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0);

            if (negatives.Any())
                throw new NegativeNumbersNotAllowedException("Negatives not allowed, " + string.Join(", ", negatives));
        }

        private Delimiter[] ParseDelimiters(string input)
        {
            var delimiters = new List<string> { "\n" };

            if (!input.HasCustomDelimiter())
            {
                delimiters.Add(DefaultDelimiter);
                return delimiters.ToDelimiters();
            }

            var delimiterSection = input.Split('\n')[0];
            var delimiter = delimiterSection.Substring(2, delimiterSection.Length - 2);

            if (delimiter.Length == 1)
                return (new string[] { delimiter, "\n" }).ToDelimiters();

            delimiters.AddRange(ParseLongDelimiters(delimiter));

            return delimiters.ToDelimiters();
        }

        private IEnumerable<string> ParseLongDelimiters(string delimiters)
        {
            return Regex.Matches(delimiters, @"\[(.*?)\]")
                .Select(d => d.Value.Substring(1, d.Length - 2));
        }
    }
}
