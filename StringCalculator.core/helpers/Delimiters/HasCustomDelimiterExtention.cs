namespace StringCalculator.core.helpers
{
    public static class HasCustomDelimiterExtention
    {
        public static bool HasCustomDelimiter(this string input) => 
            input.StartsWith("//");
    }
}
