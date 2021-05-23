using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.core
{
    internal class Delimiter
    {
        private const string DefaultDelimiter = ",";

        public static DelimiterSet ParseDelimiters(string input)
        {
            var delimiters = new List<string> { "\n" };

            if (!HasCustomDelimiter(input))
            {
                delimiters.Add(DefaultDelimiter);
                return new DelimiterSet(delimiters.ToArray());
            }

            var delimiterSection = input.Split('\n')[0];
            var delimiterValues = delimiterSection.Substring(2, delimiterSection.Length - 2);

            if (delimiterValues.Length == 1)
                return new DelimiterSet((new string[] { delimiterValues, "\n" }), true);

            delimiters.AddRange(ParseLongDelimiters(delimiterValues));

            return new DelimiterSet(
                delimiters
                    .Where(d => !string.IsNullOrEmpty(d))
                    .ToArray(), 
                true);
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static IEnumerable<string> ParseLongDelimiters(string delimiters)
        {
            return Regex.Matches(delimiters, @"\[(.*?)\]")
                .Select(d => d.Value.Substring(1, d.Length - 2));
        }
    }
}
