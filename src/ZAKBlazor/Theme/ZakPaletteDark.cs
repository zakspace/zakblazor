namespace ZAKBlazor;

/// <summary>
/// Default dark theme palette for ZAKBlazor.
/// Auto-generates Darken, Lighten, and Rgb variants for base colors.
/// </summary>
public class ZakPaletteDark : ZakPalette
{
    public ZakPaletteDark()
    {
        // Base Colors (Auto-calculates Darken, Lighten, and RGB)
        Primary = "#7B66FF";
        PrimaryContrastText = "#FFFFFF";

        Secondary = "#00E5C5";
        SecondaryContrastText = "#060A12";

        Tertiary = "#A78BFA";
        TertiaryContrastText = "#FFFFFF";

        Success = "#22C55E";
        SuccessContrastText = "#FFFFFF";

        Warning = "#FBBF24";
        WarningContrastText = "#060A12";

        Danger = "#F87171";
        DangerContrastText = "#FFFFFF";

        Info = "#38BDF8";
        InfoContrastText = "#FFFFFF";

        // Neutral & Background Colors
        Dark = "#060A12";
        Light = "#F1F5F9";

        Background = "#0B0F19";
        BackgroundSecondary = "#111726";
        Surface = "#131B2E";
        SurfaceVariant = "#1C2740";
        SurfaceHover = "rgba(255, 255, 255, 0.06)";
        SurfaceActive = "rgba(255, 255, 255, 0.12)";

        // Typography
        TextPrimary = "#F8FAFC";
        TextSecondary = "#94A3B8";
        TextMuted = "#64748B";

        // Borders & Structure
        Border = "#1E293B";
        BorderSubtle = "#151F33";
        Divider = "#1E293B";

        FocusRing = "rgba(123, 102, 255, 0.45)";
        Overlay = "rgba(6, 10, 18, 0.75)";

        // Surface Elements
        AppBarBackground = "#101626";
        AppBarText = "#F8FAFC";

        DrawerBackground = "#101626";
        DrawerText = "#F8FAFC";
        DrawerBorder = "#1E293B";

        CardBackground = "#131B2E";
        CardBorder = "#1E293B";
    }
}