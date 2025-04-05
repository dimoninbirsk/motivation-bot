using MotivationBot.Features.GetQuote;

namespace MotivationBot.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetQuote()
        {
            GetQuote quoteGen = new GetQuote();
            var result = quoteGen.Get();
            Assert.NotNull(result);
        }
    }
}