using NUnit.Framework;
using System;

namespace Business.Tests
{
    [TestFixture]
    public class SerialPortParserTests
    {
        [Test]
        public void ParsePort_COM1_Returns1()
        {
            int result = SerialPortParser.ParcePort("COM1");
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void ParsePort_InvalidFormat_ThrowsInvalidFormatException()
        {
            TestDelegate action = () => SerialPortParser.ParcePort("1");
            Assert.Throws<FormatException>(action);
        }
    }
}
