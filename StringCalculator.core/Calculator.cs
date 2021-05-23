namespace StringCalculator.core
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return default;

            var delimiterSet = Delimiter.ParseDelimiters(numbers);

            string inputArgs = !delimiterSet.HasCustom
               ? numbers
               : numbers.Split('\n')[1];

            return NumberSet
                .Parse(delimiterSet.Delimiters, inputArgs)
                .Sum();
        }
    }
}
