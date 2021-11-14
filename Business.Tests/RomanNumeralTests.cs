using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Tests
{
    [TestFixture]
    public class RomanNumeralTests
    {
        [Test]
        [TestCase(3, "III")]
        [TestCase(5, "V")]
        [TestCase(55, "LV")]
        [TestCase(290, "CCXC")]
        [TestCase(97, "XCVII")]
        public void RomanNumber_Parse_ReturnCorrectValue(int number, string roman)
        {
            Assert.That(RomanNumeral.ToRoman(number), Is.EqualTo(roman));
        }
    }
}
