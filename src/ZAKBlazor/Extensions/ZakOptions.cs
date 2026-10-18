namespace ZAKBlazor;

/// <summary>
/// Configuration options for ZAKBlazor services and default settings.
/// </summary>
public class ZakOptions
{
    /// <summary>
    /// Default theme to initialize if none is specified.
    /// </summary>
    public ZakTheme DefaultTheme { get; set; } = new();

    /// <summary>
    /// Initial dark mode preference. Defaults to false.
    /// </summary>
    public bool DefaultDarkMode { get; set; } = false;
}
