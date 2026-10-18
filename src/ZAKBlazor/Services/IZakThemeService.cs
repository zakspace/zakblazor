namespace ZAKBlazor.Services;

/// <summary>
/// Service managing runtime theme state, dark/light mode toggling, and theme notifications.
/// </summary>
public interface IZakThemeService
{
    event Action<bool>? OnThemeChanged;
    event Action<ZakTheme>? OnCustomThemeChanged;

    bool IsDarkMode { get; }
    ZakTheme CurrentTheme { get; }

    Task SetDarkModeAsync(bool isDark);
    Task ToggleDarkModeAsync();
    void SetTheme(ZakTheme theme);
}
