using NUnit.Framework;
using StringCalculator.core;

namespace StringCalculator.tests
{
    public class CalculatorTests
    {
        [TestCase("", ExpectedResult = 0)]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("1,2", ExpectedResult = 3)]
        [TestCase("1,2,", ExpectedResult = 3)]
        [TestCase("1,2,3,6,4,2,9", ExpectedResult = 27)]
        [TestCase("1\n2,3", ExpectedResult = 6)]
        [TestCase("//;\n1;3", ExpectedResult = 4)]
        [TestCase("2,1003", ExpectedResult = 2)]
        [TestCase("//[***]\n1***3", ExpectedResult = 4)]
        [TestCase("//[***][&&&]\n1***3&&&6", ExpectedResult = 10)]
        [TestCase("//[***][&]\n1***3&6", ExpectedResult = 10)]
        public int Add_WhenInputIsEmpty_ShouldReturn0(string input)
        {
            return Calculator.Add(input);
        }

        [Test]
        public void Add_WhenNegativeNumberPassed_ShouldThrowException()
        {
            const string input = "-1,2,3";
            Assert.Throws<NegativeNumbersNotAllowedException>(() => Calculator.Add(input), "Negatives not allowed, -1");
        }

        [Test]
        public void Add_WhenMultipleNegativesPassed_ShouldThrowException()
        {
            const string input = "-1,2,3,-4,-9";
            Assert.Throws<NegativeNumbersNotAllowedException>(() => Calculator.Add(input), "Negatives not allowed, -1, -4, -9");
        }

        [Test]
        public void Add_WhenInvalidDelimiterPassed_ShouldThrowException()
        {
            const string input = "//[\n1[2";
            Assert.Throws<InvalidDelimitersException>(() => Calculator.Add(input), "Invalid delimiter detected, [");
        }

        [Test]
        public void Add_WhenInvalidArgumentPassed_ShouldThrowException()
        {
            const string input = "//;\n1;2;a";
            Assert.Throws<InvalidNumberArgumentException>(() => Calculator.Add(input), "Invalid number passed, a");
        }

        [Test]
        public void Add_WhenCalled_IgnoresEmptyStringDelimiters()
        {
            var input = "//[***][]\n1***36";

            var result = Calculator.Add(input);

            Assert.AreEqual(37, result);
        }

        [Test]
        public void AddWhenCalled_ShouldRespectWhiteSpaceDelimiters()
        {
            var input = "//[***][ ]\n1***3 6";

            var result = Calculator.Add(input);

            Assert.AreEqual(10, result);
        }
    }
}