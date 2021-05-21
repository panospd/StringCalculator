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
        public int Add_WhenInputIsEmpty_ShouldReturn0(string input)
        {
            return sut.Add(input);
        }
    }
}