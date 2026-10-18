using Microsoft.JSInterop;

namespace ZAKBlazor.Services;

public class ZakThemeService : IZakThemeService
{
    private readonly IJSRuntime? _js;
    private const string StorageKey = "zak_dark_mode";

    public event Action<bool>? OnThemeChanged;
    public event Action<ZakTheme>? OnCustomThemeChanged;

    public bool IsDarkMode { get; private set; }
    public ZakTheme CurrentTheme { get; private set; }

    public ZakThemeService(IJSRuntime? js = null, ZakTheme? initialTheme = null)
    {
        _js = js;
        CurrentTheme = initialTheme ?? new ZakTheme();
    }

    public async Task SetDarkModeAsync(bool isDark)
    {
        if (IsDarkMode == isDark) return;

        IsDarkMode = isDark;
        OnThemeChanged?.Invoke(IsDarkMode);

        if (_js != null)
        {
            try
            {
                await _js.InvokeVoidAsync("zakBlazor.setTheme", isDark ? "dark" : "light");
                await _js.InvokeVoidAsync("zakBlazor.setStorageItem", StorageKey, isDark.ToString().ToLowerInvariant());
            }
            catch
            {
                // Gracefully ignore during SSR or when JS is restricted
            }
        }
    }

    public Task ToggleDarkModeAsync() => SetDarkModeAsync(!IsDarkMode);

    public void SetTheme(ZakTheme theme)
    {
        CurrentTheme = theme ?? throw new ArgumentNullException(nameof(theme));
        OnCustomThemeChanged?.Invoke(CurrentTheme);
    }
}
