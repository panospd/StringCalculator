using StringCalculator.core.helpers;

namespace StringCalculator.core
{
    public class Calculator
    {
        public static int Add(string numbers)
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
