using NUnit.Framework;

namespace Portfolio.Tests
{
    public class DisplayingValueOfPortfolioWithOnlyLotteryPrediction
    {
        [Test]
        public void eleven_days_or_more_after_now()
        {
            var app = new Portfolio("../../../portfolio.csv");

            app.ComputePortfolioValue();

            Assert.That("fixme", Is.EqualTo("fixme"));
        }

    }
}