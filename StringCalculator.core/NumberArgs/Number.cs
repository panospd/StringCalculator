namespace StringCalculator.core
{
    public class Number
    {
        private Number(string value)
        {
            var success = int.TryParse(value, out int result);

            if (!success)
                throw new InvalidNumberArgumentException("Invalid number passed, " + value);

            Value = result;
        }

        public int Value { get; }

        public static Number FromString(string value) => new Number(value);
    }
}
