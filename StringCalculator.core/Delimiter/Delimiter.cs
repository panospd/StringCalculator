using StringCalculator.core.helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.core
{
    internal class Delimiter
    {
        private string[] InvalidDelimiters = new string[] { "[", "]" };
        public string Value { get; }

        public Delimiter(string value)
        {
            if(InvalidDelimiters.Contains(value))
                throw new InvalidDelimitersException("Invalid delimiter detected, " + string.Join(',', value));

            Value = value;
        }

        public static Delimiter[] ParseDelimiters(string input, string defaultDelimiter = ",")
        {
            var delimiters = new List<string> { "\n" };

            if (!input.HasCustomDelimiter())
            {
                delimiters.Add(defaultDelimiter);
                return delimiters.ToDelimiters();
            }

            var delimiterSection = input.Split('\n')[0];
            var delimiter = delimiterSection.Substring(2, delimiterSection.Length - 2);

            if (delimiter.Length == 1)
                return (new string[] { delimiter, "\n" }).ToDelimiters();

            delimiters.AddRange(ParseLongDelimiters(delimiter));

            return delimiters.ToDelimiters();
        }

        private static IEnumerable<string> ParseLongDelimiters(string delimiters)
        {
            return Regex.Matches(delimiters, @"\[(.*?)\]")
                .Select(d => d.Value.Substring(1, d.Length - 2));
        }
    }
}
