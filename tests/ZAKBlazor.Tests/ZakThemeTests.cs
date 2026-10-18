using Xunit;
using ZAKBlazor;
using ZAKBlazor.Services;

namespace ZAKBlazor.Tests;

public class ZakThemeTests
{
    [Fact]
    public void BuildCss_GeneratesRootVariables_ForLightAndDark()
    {
        var theme = new ZakTheme();

        var lightCss = theme.BuildCss(isDarkMode: false);
        Assert.Contains(":root {", lightCss);
        Assert.Contains("--zak-primary: #5E43F3;", lightCss);
        Assert.Contains("--zak-background: #F8FAFC;", lightCss);

        var darkCss = theme.BuildCss(isDarkMode: true);
        Assert.Contains(":root {", darkCss);
        Assert.Contains("--zak-background: #0B0F19;", darkCss);
    }

    [Fact]
    public async Task ThemeService_ToggleDarkMode_NotifiesSubscriber()
    {
        var service = new ZakThemeService();
        var eventTriggered = false;
        var darkModeState = false;

        service.OnThemeChanged += isDark =>
        {
            eventTriggered = true;
            darkModeState = isDark;
        };

        await service.ToggleDarkModeAsync();

        Assert.True(eventTriggered);
        Assert.True(darkModeState);
        Assert.True(service.IsDarkMode);

        await service.ToggleDarkModeAsync();
        Assert.False(service.IsDarkMode);
    }
}
