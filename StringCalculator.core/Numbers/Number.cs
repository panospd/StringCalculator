namespace StringCalculator.core
{
    public class Number
    {
        public int Value { get; }
        public bool IsValid => Value > 0;

        private Number(string value)
        {
            var success = int.TryParse(value, out int result);

            if (!success)
                throw new InvalidNumberArgumentException("Invalid number passed, " + value);

            Value = result;
        }
        public static Number FromString(string value) => new Number(value);
    }
}
