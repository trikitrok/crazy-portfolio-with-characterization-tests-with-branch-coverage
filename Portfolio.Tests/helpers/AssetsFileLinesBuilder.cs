using System.Globalization;
using static Portfolio.Tests.CultureInfoFactory;

namespace Portfolio.Tests;

public class AssetsFileLinesBuilder
{
    private string _dateAsString;
    private string _description;
    private float? _value;
    private string _valueAsString;

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
        _valueAsString = value.ToString(CreateCultureInfo());
        return this;
    }
    
    public AssetsFileLinesBuilder WithValue(string value)
    {
        _valueAsString = value;
        return this;
    }

    public string Build()
    {
        var assetValue = _valueAsString;
        var assetFileLine = $"{_description},{_dateAsString},{assetValue}";
        Console.WriteLine("assetFileLine: " + assetFileLine);
        return assetFileLine;
    }
}