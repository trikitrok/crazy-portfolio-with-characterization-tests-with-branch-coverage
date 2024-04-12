using System.Globalization;

namespace Portfolio.Tests;

public class TestingPortfolio : Portfolio
{
    public TestingPortfolio(string portfolioCsvPath) : base(portfolioCsvPath)
    {
    }

    protected override DateTime GetNow()
    {
        return base.GetNow();
    }

    protected override string[] ReadAssetsFileLines()
    {
        return base.ReadAssetsFileLines();
    }

    protected override void DisplayMessage(string message)
    {
        base.DisplayMessage(message);
    }

    protected override string FormatDate(DateTime assetDate, CultureInfo provider)
    {
        return base.FormatDate(assetDate, provider);
    }

    protected override DateTime CreateAssetDateTime(string dateAsString, CultureInfo cultureInfo)
    {
        return base.CreateAssetDateTime(dateAsString, cultureInfo);
    }
}