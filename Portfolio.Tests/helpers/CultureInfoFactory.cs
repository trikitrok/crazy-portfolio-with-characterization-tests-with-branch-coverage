using System.Globalization;

namespace Portfolio.Tests;

public class CultureInfoFactory
{
    public static CultureInfo CreateCultureInfo()
    {
        return new CultureInfo("es-ES");
    }
}