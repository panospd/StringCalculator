using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.core.helpers
{
    public static class ToDelimitersExtention
    {
        public static Delimiter[] ToDelimiters(this IEnumerable<string> delimiters)
        {
            return delimiters.Select(d => new Delimiter(d)).ToArray();
        }
    }
}
