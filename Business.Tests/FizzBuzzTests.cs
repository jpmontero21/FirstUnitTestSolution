using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(7,"")]
        [TestCase(83,"")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(50, "Buzz")]
        public void Ask_ReturnCorrectValue(int number, string fizzBuzz) 
        {
            Assert.That(FizzBuzz.Ask(number), Is.EqualTo(fizzBuzz));
        }
    }
}
