namespace StringCalculator.core.helpers
{
    internal static class HasCustomDelimiterExtention
    {
        public static bool HasCustomDelimiter(this string input) => 
            input.StartsWith("//");
    }
}
