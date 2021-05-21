using StringCalculator.core.helpers;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.core
{
    public class NumbersArgs
    {
        private readonly int _maxNumber;

        public IEnumerable<Number> List { get; }

        private NumbersArgs(IEnumerable<string> numbers, int maxNumber)
        {
            List = numbers.Select(Number.FromString);
            _maxNumber = maxNumber;

            Validate();
        }

        public static NumbersArgs Parse(string[] delimiters, string input, int maxNumber = 1000)
        {
            string inputArgs = !input.HasCustomDelimiter()
                ? input
                : input.Split('\n')[1];

            var numbers = inputArgs.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);

            return new NumbersArgs(numbers, maxNumber);
        }

        public int Sum() => List
                .Where(n => n.Value <= _maxNumber)
                .Select(n => n.Value)
                .Sum();

        private void Validate()
        {
            var invalidArgs = List.Where(n => !n.IsValid);

            if(invalidArgs.Any())
                throw new NegativeNumbersNotAllowedException("Negatives not allowed, " + string.Join(", ", invalidArgs));
        }
    }
}
