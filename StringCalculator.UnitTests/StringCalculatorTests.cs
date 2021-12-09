using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace StringCalculator.UnitTests
{
    public class StringCalculatorTests
    {
        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("");
            Assert.That(result == 0);
        }

        [Test]
        public void Add_OneNumber_ReturnNumber()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("3");
            Assert.That(result == 3);
        }

        [Test]
        public void Add_TwoNumbers_ReturnSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1001,3");
            Assert.That(result == 3);
        }

        [Test]
        public void Add_NegativeNumber_ReturnExceptionMessage()
        {
            var calculator = new StringCalculator();
            
            var ex = Assert.Throws<Exception>(() => calculator.Add("-2"));
            Assert.That(ex.Message == "negatives not allowed - -2");
        }

        [Test]
        public void Add_NegativeNumbers_ReturnExceptionMessage()
        {
            var calculator = new StringCalculator();

            var ex = Assert.Throws<Exception>(() => calculator.Add("-2,-5,7"));
            Assert.That(ex.Message == "negatives not allowed - -2,-5");
        }

        [Test]
        public void Add_NumbersInNewLines_ReturnSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("3\n2,3");
            Assert.That(result == 8);
        }

        [Test]
        public void Add_CustomDelimiter_ReturnSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//;\n1;2");
            Assert.That(result == 3);
        }
    }
}