using NUnit.Framework;
using static Portfolio.Tests.AssetsFileLinesBuilder;
using static Portfolio.Tests.TestingPortfolioBuilder;

namespace Portfolio.Tests;

public class PortfolioWithOnlyRegularAsset
{
    [Test]
    public void value_decreases_by_20_before_now()
    {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Some Regular Asset").
                FromDate("2024/01/15").WithValue(100))
            .OnDate("2025/01/01")
            .Build();

        portfolio.ComputePortfolioValue();
            
        Assert.That(portfolio._messages[0], Is.EqualTo("80"));
    }
    
    [Test]
    public void value_decreases_by_10_after_now()
    {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Some Regular Asset").
                FromDate("2024/01/15").WithValue(100))
            .OnDate("2023/01/01")
            .Build();

        portfolio.ComputePortfolioValue();
            
        Assert.That(portfolio._messages[0], Is.EqualTo("90"));
    }
}