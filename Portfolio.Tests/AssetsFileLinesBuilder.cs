namespace Portfolio.Tests;

public class AssetsFileLinesBuilder
{
    private string _dateAsString;
    private string _description;
    private float? _value;

    private AssetsFileLinesBuilder()
    {
        _dateAsString = "";
        _description = "description";
        _value = null;
    }

    public static AssetsFileLinesBuilder AnAsset()
    {
        return new AssetsFileLinesBuilder();
    }

    public AssetsFileLinesBuilder FromDate(string date)
    {
        _dateAsString = date;
        return this;
    }

    public AssetsFileLinesBuilder DescribedAs(string description)
    {
        _description = description;
        return this;
    }

    public AssetsFileLinesBuilder WithValue(float value)
    {
        _value = value;
        return this;
    }

    public string Build()
    {
        var assetValue = _value?.ToString();
        return $"{_description},{_dateAsString},{assetValue}";
    }
}