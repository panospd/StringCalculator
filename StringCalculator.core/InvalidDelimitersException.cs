using System;

namespace StringCalculator.core
{
    public class InvalidDelimitersException : Exception
    {
        public InvalidDelimitersException(string message)
            : base(message)
        {
        }
    }
}
