using System.Globalization;

namespace Portfolio.Tests;

public class TestingPortfolio : Portfolio
{
    private readonly string[] _assetsFileLines;
    private readonly DateTime _now;
    private readonly CultureInfo _cultureInfo;
    public List<string> _messages;

    public TestingPortfolio(string[] assetsFileLines, string nowAsString, CultureInfo cultureInfo) : 
        base("")
    {
        _assetsFileLines = assetsFileLines;
        _now = DateTime.Parse(nowAsString, cultureInfo);
        _cultureInfo = cultureInfo;
        _messages = new List<string>();
    }

    protected override DateTime GetNow()
    {
        return _now;
    }

    protected override string[] ReadAssetsFileLines()
    {
        return _assetsFileLines;
    }

    protected override void DisplayMessage(string message)
    {
        _messages.Add(message);
    }

    protected override string FormatDate(DateTime assetDate, CultureInfo notUsed)
    {
        return assetDate.ToString(_cultureInfo);
    }

    protected override DateTime CreateAssetDateTime(string dateAsString, CultureInfo notUsed)
    {
        return  DateTime.Parse(dateAsString, _cultureInfo);
    }
}