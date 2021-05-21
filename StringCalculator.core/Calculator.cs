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

            var delimiters = GetDelimiters(numbers);
            ValidateDelimiters(delimiters);

            string input = !numbers.HasCustomDelimiter()
                ? numbers
                : numbers.Split('\n')[1];

            var numbersArray = input
                .Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries)
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

        private void ValidateDelimiters(IEnumerable<string> delimiters)
        {
            var invalidDelimiters = delimiters.InvalidDelimiters("[", "]");
            if (invalidDelimiters.Any())
                throw new InvalidDelimitersException("Invalid delimiter(s) detected, " + string.Join(',', delimiters));
        }

        private IEnumerable<string> GetLongDelimiters(string delimiters)
        {
            return Regex.Matches(delimiters, @"\[(.*?)\]")
                .Select(d => d.Value.Substring(1, d.Length - 2));
        }

        private string[] GetDelimiters(string input)
        {
            var delimiters = new List<string> { "\n" };

            if (!input.HasCustomDelimiter())
            {
                delimiters.Add(DefaultDelimiter);
                return delimiters.ToArray();
            }

            var delimiterSection = input.Split('\n')[0];
            var delimiter = delimiterSection.Substring(2, delimiterSection.Length - 2);

            if (delimiter.Length == 1)
                return new string[] { delimiter, "\n" };

            delimiters.AddRange(GetLongDelimiters(delimiter));
            
            return delimiters.ToArray();
        }
    }
}
