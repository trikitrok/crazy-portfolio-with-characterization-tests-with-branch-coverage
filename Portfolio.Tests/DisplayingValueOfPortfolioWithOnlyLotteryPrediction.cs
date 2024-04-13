using NUnit.Framework;

namespace Portfolio.Tests
{
    public class DisplayingValueOfPortfolioWithOnlyLotteryPrediction
    {
        [Test]
        public void before_now()
        {
            var portfolio = TestingPortfolioBuilder.APortFolio()
                .With(AssetsFileLinesBuilder.AnAsset().DescribedAs("Lottery Prediction").
                    FromDate("2024/04/15").WithValue(50))
                .OnDate("2025/01/01")
                .Build();

            portfolio.ComputePortfolioValue();
            
            Assert.That(portfolio._messages[0], Is.EqualTo("0"));
        }
        
        [Test]
        public void eleven_days_or_more_after_now()
        {
            var portfolio = TestingPortfolioBuilder.APortFolio()
                .With(AssetsFileLinesBuilder.AnAsset().DescribedAs("Lottery Prediction").
                    FromDate("2024/04/15").WithValue(50))
                .OnDate("2024/01/01")
                .Build();

            portfolio.ComputePortfolioValue();
            
            Assert.That(portfolio._messages[0], Is.EqualTo("55"));
        }
        
        [Test]
        public void less_than_11_days_after_now()
        {
            var portfolio = TestingPortfolioBuilder.APortFolio()
                .With(AssetsFileLinesBuilder.AnAsset().DescribedAs("Lottery Prediction").
                    FromDate("2024/04/14").WithValue(50))
                .OnDate("2024/04/04")
                .Build();

            portfolio.ComputePortfolioValue();
            
            Assert.That(portfolio._messages[0], Is.EqualTo("75"));
        }
        
        [Test]
        public void less_than_6_days_after_now()
        {
            var portfolio = TestingPortfolioBuilder.APortFolio()
                .With(AssetsFileLinesBuilder.AnAsset().DescribedAs("Lottery Prediction").
                    FromDate("2024/04/09").WithValue(50))
                .OnDate("2024/04/04")
                .Build();

            portfolio.ComputePortfolioValue();
            
            Assert.That(portfolio._messages[0], Is.EqualTo("175"));
        }
        
        [Test]
        public void value_can_not_be_more_than_800()
        {
            var portfolio = TestingPortfolioBuilder.APortFolio()
                .With(AssetsFileLinesBuilder.AnAsset().DescribedAs("Lottery Prediction").
                    FromDate("2024/04/15").WithValue(800))
                .OnDate("2024/04/09")
                .Build();

            portfolio.ComputePortfolioValue();
            
            Assert.That(portfolio._messages[0], Is.EqualTo("800"));
        }

    }
}