using System.Linq;

namespace StringCalculator.core
{
    public class Delimiter
    {
        private string[] InvalidDelimiters = new string[] { "[", "]" };
        public string Value { get; }

        public Delimiter(string value)
        {
            if(InvalidDelimiters.Contains(value))
                throw new InvalidDelimitersException("Invalid delimiter detected, " + string.Join(',', value));

            Value = value;
        }
    }
}
