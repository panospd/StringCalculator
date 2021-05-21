﻿using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.core.helpers
{
    internal static class ValuesExtention
    {
        public static string[] Values(this IEnumerable<Delimiter> delimiters)
        {
            return delimiters.Select(d => d.Value).ToArray();
        }
    }
}