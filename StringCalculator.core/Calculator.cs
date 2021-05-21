using System;
using System.Linq;

namespace StringCalculator.core
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return default;

            return numbers
                .Split(',', '\n')
                .Select(int.Parse)
                .ToList()
                .Sum();
        }
    }
}
