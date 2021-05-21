using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.core.Numbers.Extentions
{
    public static class ValidateExtention
    {
        public static void Validate(this IEnumerable<Number> numbers)
        {
            var invalidNumbers = numbers.Where(n => !n.IsValid);

            if(invalidNumbers.Any())
                throw new NegativeNumbersNotAllowedException("Negatives not allowed, " + string.Join(", ", invalidNumbers));
        }
    }
}
