using System.Linq;

namespace StringCalculator.core
{
    internal class DelimiterSet
    {
        private readonly string[] InvalidDelimiters = new string[] { "[", "]" };

        public DelimiterSet(string[] delimiters, bool hasCustom = false)
        {
            Delimiters = delimiters;
            HasCustom = hasCustom;

            Validate();
        }

        public string[] Delimiters { get; }
        public bool HasCustom { get; }

        private void Validate()
        {
            var invalidDelimiters = Delimiters.Where(d => InvalidDelimiters.Contains(d));

            if(invalidDelimiters.Any())
                throw new InvalidDelimitersException("Invalid delimiters detected, " + string.Join(',', invalidDelimiters));
        }
    }
}
