using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator.core.helpers
{
    public static class LessThanExtention
    {
        public static IEnumerable<int> LessThan(this IEnumerable<int> numbers, int max)
        {
            return numbers.Where(n => n <= max);
        }
    }
}
