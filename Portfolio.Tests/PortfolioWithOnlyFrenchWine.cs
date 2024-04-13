using NUnit.Framework;

namespace Portfolio.Tests;

public class PortfolioWithOnlyFrenchWine
{
    [Test]
    public void before_now_value_grows_by_20()
    {
        var portfolio = TestingPortfolioBuilder.APortFolio()
            .With(AssetsFileLinesBuilder.AnAsset().DescribedAs("French Wine").
                FromDate("2024/01/15").WithValue(100))
            .OnDate("2025/01/01")
            .Build();

        portfolio.ComputePortfolioValue();
            
        Assert.That(portfolio._messages[0], Is.EqualTo("120"));
    }
    
    [Test]
    public void after_now_value_grows_by_10()
    {
        var portfolio = TestingPortfolioBuilder.APortFolio()
            .With(AssetsFileLinesBuilder.AnAsset().DescribedAs("French Wine").
                FromDate("2024/01/15").WithValue(100))
            .OnDate("2024/01/01")
            .Build();

        portfolio.ComputePortfolioValue();
            
        Assert.That(portfolio._messages[0], Is.EqualTo("110"));
    }
}