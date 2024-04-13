using System.Globalization;
using static Portfolio.Tests.CultureInfoFactory;

namespace Portfolio.Tests;

public class TestingPortfolioBuilder
{
    private readonly List<string> _lines;
    private string _now;
    private CultureInfo _cultureInfo;

    public static TestingPortfolioBuilder APortFolio()
    {
        return new TestingPortfolioBuilder();
    }

    public static TestingPortfolioBuilder AnEmptyPortFolio()
    {
        var builder = APortFolio();
        builder._lines.Add("");
        return builder;
    }

    public TestingPortfolioBuilder With(AssetsFileLinesBuilder lineBuilder)
    {
        _lines.Add(lineBuilder.Build());
        return this;
    }

    public TestingPortfolioBuilder OnDate(string dateAsString)
    {
        _now = dateAsString;
        return this;
    }

    public TestingPortfolio Build()
    {
        return new TestingPortfolio(_lines.ToArray(), _now, _cultureInfo);
    }
    
    private TestingPortfolioBuilder()
    {
        _lines = new List<string>();
        _cultureInfo = CreateCultureInfo();
        _now = new DateTime().ToString(_cultureInfo);
    }
}