using System;

namespace StringCalculator.core
{
    public class NegativeNumbersNotAllowedException : Exception
    {
        public NegativeNumbersNotAllowedException(string message)
            :base(message)
        {

        }
    }
}
