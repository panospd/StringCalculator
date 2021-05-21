using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.core.helpers
{
    public static class LessThanExtention
    {
        public static IEnumerable<int> LessThan(this IEnumerable<int> numbers, int max) 
            => numbers.Where(n => n <= max);
    }
}
