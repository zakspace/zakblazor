namespace ZAKBlazor;

/// <summary>
/// Default light theme palette for ZAKBlazor.
/// Auto-generates Darken, Lighten, and Rgb variants for base colors.
/// </summary>
public class ZakPaletteLight : ZakPalette
{
    public ZakPaletteLight()
    {
        // Base Colors (Auto-calculates Darken, Lighten, and RGB)
        Primary = "#5E43F3";
        PrimaryContrastText = "#FFFFFF";

        Secondary = "#00D2B4";
        SecondaryContrastText = "#FFFFFF";

        Tertiary = "#8B5CF6";
        TertiaryContrastText = "#FFFFFF";

        Success = "#10B981";
        SuccessContrastText = "#FFFFFF";

        Warning = "#F59E0B";
        WarningContrastText = "#0B0F19";

        Danger = "#EF4444";
        DangerContrastText = "#FFFFFF";

        Info = "#0EA5E9";
        InfoContrastText = "#FFFFFF";

        // Neutral & Background Colors
        Dark = "#0B0F19";
        Light = "#F8FAFC";

        Background = "#F8FAFC";
        BackgroundSecondary = "#F1F5F9";
        Surface = "#FFFFFF";
        SurfaceVariant = "#F8FAFC";
        SurfaceHover = "rgba(15, 23, 42, 0.04)";
        SurfaceActive = "rgba(15, 23, 42, 0.08)";

        // Typography
        TextPrimary = "#0F172A";
        TextSecondary = "#475569";
        TextMuted = "#94A3B8";

        // Borders & Structure
        Border = "#E2E8F0";
        BorderSubtle = "#F1F5F9";
        Divider = "#E2E8F0";

        FocusRing = "rgba(94, 67, 243, 0.35)";
        Overlay = "rgba(15, 23, 42, 0.50)";

        // Surface Elements
        AppBarBackground = "#FFFFFF";
        AppBarText = "#0F172A";

        DrawerBackground = "#FFFFFF";
        DrawerText = "#0F172A";
        DrawerBorder = "#E2E8F0";

        CardBackground = "#FFFFFF";
        CardBorder = "#E2E8F0";
    }
}