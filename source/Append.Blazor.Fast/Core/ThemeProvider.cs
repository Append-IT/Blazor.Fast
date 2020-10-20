using System;

namespace Append.Blazor.Fast.Core
{
    public class ThemeProvider
    {
        public ThemeType Theme { get; init; } = ThemeType.Fast;
        public string ThemeName => Enum.GetName(Theme).ToLower();
        public ThemeProvider(ThemeType theme = ThemeType.Fast)
        {
            Theme = theme;
        }
    }
}
