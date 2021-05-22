using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.core
{
    public class NumberSet
    {
        private readonly int _maxNumber;

        private NumberSet(IEnumerable<string> numbers, int maxNumber)
        {
            List = numbers
                .Select(Number.FromString)
                .ToList();

            _maxNumber = maxNumber;

            Validate();
        }

        public IReadOnlyCollection<Number> List { get; }

        public static NumberSet Parse(string[] delimiters, string input, int maxNumber = 1000)
        {
            var numbers = input.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
            return new NumberSet(numbers, maxNumber);
        }

        public int Sum() => List
                .Where(n => n.Value <= _maxNumber)
                .Select(n => n.Value)
                .Sum();

        private void Validate()
        {
            var invalidArgs = List.Where(n => n.Value < 0);

            if(invalidArgs.Any())
                throw new NegativeNumbersNotAllowedException("Negatives not allowed, " + string.Join(", ", invalidArgs));
        }
    }
}
