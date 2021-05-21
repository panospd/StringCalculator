using NUnit.Framework;
using StringCalculator.core;

namespace StringCalculator.tests
{
    public class CalculatorTests
    {
        Calculator sut;

        [SetUp]
        public void Setup()
        {
            sut = new Calculator();
        }

        [TestCase("", ExpectedResult = 0)]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("1,2", ExpectedResult = 3)]
        [TestCase("1,2,3,6,4,2,9", ExpectedResult = 27)]
        [TestCase("1\n2,3", ExpectedResult = 6)]
        [TestCase("//;\n1;3", ExpectedResult = 4)]
        [TestCase("2,1003", ExpectedResult = 2)]
        [TestCase("//[***]\n1***3", ExpectedResult = 4)]
        [TestCase("//[***][&&&]\n1***3&&&6", ExpectedResult = 10)]
        public int Add_WhenInputIsEmpty_ShouldReturn0(string input)
        {
            return sut.Add(input);
        }

        [Test]
        public void Add_WhenNegativeNumberPassed_ShouldThrowException()
        {
            const string input = "-1,2,3";
            Assert.Throws<NegativeNumbersNotAllowedException>(() => sut.Add(input), "Negatives not allowed, -1");
        }

        [Test]
        public void Add_WhenMultipleNegativesPassed_ShouldThrowException()
        {
            const string input = "-1,2,3,-4,-9";
            Assert.Throws<NegativeNumbersNotAllowedException>(() => sut.Add(input), "Negatives not allowed, -1, -4, -9");
        }

        [Test]
        public void Add_WhenInvalidDelimiterPassed_ShouldThrowException()
        {
            const string input = "//[\n1[2";
            Assert.Throws<InvalidDelimitersException>(() => sut.Add(input), "Invalid delimiter(s) detected, [");
        }
    }
}