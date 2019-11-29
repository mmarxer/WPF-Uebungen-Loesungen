using System.Windows.Media;

namespace ColorSliders
{
    /// <summary>
    /// Class that attaches methods (currently only the method
    /// "ToHexColor") to objects of type Color (WPF class).
    /// Extension methods are a C# concept.
    /// See https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    ///
    /// Using method syntax, you can use the method as follows:
    ///
    /// <code>
    /// var c = Colors.Blue;
    /// var rgbString = ColorExtensions.ToHexColor(c);
    /// </code>
    ///
    /// Using the more compact extension method syntax, this
    /// transforms to just calling the ToHexColor-method on
    /// the Color object directly:
    ///
    /// <code>
    /// var c = Colors.Blue;
    /// var rgbString = c.ToHexColor();
    /// </code>
    /// </summary>
    public static class ColorExtensions
    {
        public static string ToHexColor(this Color color, bool alpha = false)
        {
            var rgbString = $"{color.R:X2}{color.G:X2}{color.B:X2}";
            if (alpha) rgbString = $"{color.A:X2}{rgbString}";
            return $"#{rgbString}";
        }
    }
}
