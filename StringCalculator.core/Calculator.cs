using StringCalculator.core.helpers;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.core
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return default;

            var delimiters = Delimiter
                .ParseDelimiters(numbers)
                .Values();

            return NumbersArgs
                .Parse(delimiters, numbers)
                .Sum();
        }
    }
}
