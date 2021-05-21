using System;

namespace StringCalculator.core
{
    public class InvalidNumberArgumentException : Exception
    {
        public InvalidNumberArgumentException(string message)
            :base(message)
        {
        }
    }
}
