using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.core.helpers
{
    internal static class InvalidDelimitersExtention
    {
        public static IEnumerable<string> InvalidDelimiters(this IEnumerable<string> delimiters, params string[] invalidDelimiters) 
            => delimiters.Where(d => invalidDelimiters.Contains(d));
    }
}
