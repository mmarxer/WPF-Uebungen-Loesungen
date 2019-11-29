using System;

namespace IconButtons
{
    public class Themes
    {
        public const string Folder = "Styles/Themes";

        public static Uri GetThemeUri(ThemeTypeEnum theme)
        {
            return new Uri($"{Folder}/{theme}.xaml", UriKind.Relative);
        }

    }
}
