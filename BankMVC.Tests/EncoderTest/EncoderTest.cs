using BankMVC.Auxiliary.Encode;
using FluentAssertions;
using NUnit.Framework;

namespace BankMVC.Tests.EncoderTest
{
    [TestFixture]
    public class EncoderTest
    {
        [Test]
        public void Encoder_Simple_Test()
        {
            var encoder = new Encoder();
            encoder.Encode(1234).Should().Be("BCDE");
        }
    }
}