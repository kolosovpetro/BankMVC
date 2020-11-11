using BankMVC.Auxiliary.Decode;
using FluentAssertions;
using NUnit.Framework;

namespace BankMVC.Tests.DecoderTest
{
    [TestFixture]
    public class DecoderTest
    {
        [Test]
        public void Decoder_Simple_Test()
        {
            var decoder = new Decoder();
            decoder.Decode("BCDE").Should().Be(1234);
        }
    }
}