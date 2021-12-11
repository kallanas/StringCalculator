using NUnit.Framework;
using System;

namespace StringCalculator.UnitTests
{
    public class StringCalculatorTests
    {
        [TestCase("", 0)]
        [TestCase(null, 0)]
        [TestCase("    ", 0)]
        [TestCase("3", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2, ,3", 6)]
        [TestCase("//;\n1;2;3", 6)]
        [TestCase("//;\n1;2\n3", 6)]
        public void Add_ReturnExpected(string input, int sum)
        {
            var result = StringCalculator.Add(input);
            Assert.That(result == sum);
        }

        [Test]
        public void Add_NegativeNumber_ReturnExceptionMessage()
        {            
            var ex = Assert.Throws<Exception>(() => StringCalculator.Add("-2"));
            Assert.That(ex.Message == "Negatives not allowed: -2");
        }

        [Test]
        public void Add_NegativeNumbers_ReturnExceptionMessage()
        {
            var ex = Assert.Throws<Exception>(() => StringCalculator.Add("-2,-5,7"));
            Assert.That(ex.Message == "Negatives not allowed - -2,-5");
        }
    }
}