using System;
using System.Drawing;

namespace ZAKBlazor;

/// <summary>
/// Defines color tokens for a ZAKBlazor theme.
/// Automatically derives Lighten, Darken, and RGB variants for all palette colors.
/// ContrastText properties remain independent.
/// </summary>
public class ZakPalette
{
    private string _primary = "#5E43F3";
    private string _secondary = "#00D2B4";
    private string _tertiary = "#8B5CF6";
    private string _warning = "#F59E0B";
    private string _success = "#10B981";
    private string _danger = "#EF4444";
    private string _info = "#0EA5E9";

    // Primary
    public string Primary { get => _primary; set { _primary = value; RecalculateColorVariants(value, out var d, out var l, out var rgb); PrimaryDarken = d; PrimaryLighten = l; PrimaryRgb = rgb; } }
    public string PrimaryDarken { get; set; } = string.Empty;
    public string PrimaryLighten { get; set; } = string.Empty;
    public string PrimaryContrastText { get; set; } = "#FFFFFF";
    public string PrimaryRgb { get; set; } = string.Empty;

    // Secondary
    public string Secondary { get => _secondary; set { _secondary = value; RecalculateColorVariants(value, out var d, out var l, out var rgb); SecondaryDarken = d; SecondaryLighten = l; SecondaryRgb = rgb; } }
    public string SecondaryDarken { get; set; } = string.Empty;
    public string SecondaryLighten { get; set; } = string.Empty;
    public string SecondaryContrastText { get; set; } = "#0F172A";
    public string SecondaryRgb { get; set; } = string.Empty;

    // Tertiary
    public string Tertiary { get => _tertiary; set { _tertiary = value; RecalculateColorVariants(value, out var d, out var l, out var rgb); TertiaryDarken = d; TertiaryLighten = l; TertiaryRgb = rgb; } }
    public string TertiaryDarken { get; set; } = string.Empty;
    public string TertiaryLighten { get; set; } = string.Empty;
    public string TertiaryContrastText { get; set; } = "#FFFFFF";
    public string TertiaryRgb { get; set; } = string.Empty;

    // Warning
    public string Warning { get => _warning; set { _warning = value; RecalculateColorVariants(value, out var d, out var l, out var rgb); WarningDarken = d; WarningLighten = l; WarningRgb = rgb; } }
    public string WarningDarken { get; set; } = string.Empty;
    public string WarningLighten { get; set; } = string.Empty;
    public string WarningContrastText { get; set; } = "#0F172A";
    public string WarningRgb { get; set; } = string.Empty;

    // Success
    public string Success { get => _success; set { _success = value; RecalculateColorVariants(value, out var d, out var l, out var rgb); SuccessDarken = d; SuccessLighten = l; SuccessRgb = rgb; } }
    public string SuccessDarken { get; set; } = string.Empty;
    public string SuccessLighten { get; set; } = string.Empty;
    public string SuccessContrastText { get; set; } = "#FFFFFF";
    public string SuccessRgb { get; set; } = string.Empty;

    // Danger
    public string Danger { get => _danger; set { _danger = value; RecalculateColorVariants(value, out var d, out var l, out var rgb); DangerDarken = d; DangerLighten = l; DangerRgb = rgb; } }
    public string DangerDarken { get; set; } = string.Empty;
    public string DangerLighten { get; set; } = string.Empty;
    public string DangerContrastText { get; set; } = "#FFFFFF";
    public string DangerRgb { get; set; } = string.Empty;

    // Info
    public string Info { get => _info; set { _info = value; RecalculateColorVariants(value, out var d, out var l, out var rgb); InfoDarken = d; InfoLighten = l; InfoRgb = rgb; } }
    public string InfoDarken { get; set; } = string.Empty;
    public string InfoLighten { get; set; } = string.Empty;
    public string InfoContrastText { get; set; } = "#FFFFFF";
    public string InfoRgb { get; set; } = string.Empty;

    // Neutral Colors
    public string Dark { get; set; } = "#0F172A";
    public string Light { get; set; } = "#F8FAFC";

    public string Background { get; set; } = "#F8FAFC";
    public string BackgroundSecondary { get; set; } = "#F1F5F9";
    public string Surface { get; set; } = "#FFFFFF";
    public string SurfaceVariant { get; set; } = "#F8FAFC";
    public string SurfaceHover { get; set; } = "rgba(15, 23, 42, 0.04)";
    public string SurfaceActive { get; set; } = "rgba(15, 23, 42, 0.08)";

    public string TextPrimary { get; set; } = "#0F172A";
    public string TextSecondary { get; set; } = "#64748B";
    public string TextMuted { get; set; } = "#94A3B8";

    public string Border { get; set; } = "#E2E8F0";
    public string BorderSubtle { get; set; } = "#F1F5F9";
    public string Divider { get; set; } = "#E2E8F0";

    public string FocusRing { get; set; } = "rgba(94, 67, 243, 0.35)";
    public string Overlay { get; set; } = "rgba(15, 23, 42, 0.55)";

    public string AppBarBackground { get; set; } = "#FFFFFF";
    public string AppBarText { get; set; } = "#0F172A";

    public string DrawerBackground { get; set; } = "#FFFFFF";
    public string DrawerText { get; set; } = "#0F172A";
    public string DrawerBorder { get; set; } = "#E2E8F0";

    public string CardBackground { get; set; } = "#FFFFFF";
    public string CardBorder { get; set; } = "#E2E8F0";

    public ZakPalette()
    {
        // Initial recalculation for default base colors
        Primary = _primary;
        Secondary = _secondary;
        Tertiary = _tertiary;
        Warning = _warning;
        Success = _success;
        Danger = _danger;
        Info = _info;
    }

    private static void RecalculateColorVariants(string hexColor, out string darken, out string lighten, out string rgb)
    {
        if (TryParseColor(hexColor, out Color color))
        {
            rgb = $"{color.R}, {color.G}, {color.B}";
            lighten = ColorToHex(AdjustLightness(color, 0.12f));
            darken = ColorToHex(AdjustLightness(color, -0.12f));
        }
        else
        {
            darken = lighten = hexColor;
            rgb = "0, 0, 0";
        }
    }

    public virtual string ToCssVariables()
    {
        return $@"
        --zak-primary: {Primary};
        --zak-primary-rgb: {PrimaryRgb};
        --zak-primary-darken: {PrimaryDarken};
        --zak-primary-lighten: {PrimaryLighten};
        --zak-primary-contrast: {PrimaryContrastText};

        --zak-secondary: {Secondary};
        --zak-secondary-rgb: {SecondaryRgb};
        --zak-secondary-darken: {SecondaryDarken};
        --zak-secondary-lighten: {SecondaryLighten};
        --zak-secondary-contrast: {SecondaryContrastText};

        --zak-tertiary: {Tertiary};
        --zak-tertiary-rgb: {TertiaryRgb};
        --zak-tertiary-darken: {TertiaryDarken};
        --zak-tertiary-lighten: {TertiaryLighten};
        --zak-tertiary-contrast: {TertiaryContrastText};

        --zak-success: {Success};
        --zak-success-rgb: {SuccessRgb};
        --zak-success-darken: {SuccessDarken};
        --zak-success-lighten: {SuccessLighten};
        --zak-success-contrast: {SuccessContrastText};

        --zak-warning: {Warning};
        --zak-warning-rgb: {WarningRgb};
        --zak-warning-darken: {WarningDarken};
        --zak-warning-lighten: {WarningLighten};
        --zak-warning-contrast: {WarningContrastText};

        --zak-danger: {Danger};
        --zak-danger-rgb: {DangerRgb};
        --zak-danger-darken: {DangerDarken};
        --zak-danger-lighten: {DangerLighten};
        --zak-danger-contrast: {DangerContrastText};

        --zak-info: {Info};
        --zak-info-rgb: {InfoRgb};
        --zak-info-darken: {InfoDarken};
        --zak-info-lighten: {InfoLighten};
        --zak-info-contrast: {InfoContrastText};

        --zak-dark: {Dark};
        --zak-light: {Light};
        --zak-background: {Background};
        --zak-background-secondary: {BackgroundSecondary};
        --zak-surface: {Surface};
        --zak-surface-variant: {SurfaceVariant};
        --zak-surface-hover: {SurfaceHover};
        --zak-surface-active: {SurfaceActive};
        --zak-text-primary: {TextPrimary};
        --zak-text-secondary: {TextSecondary};
        --zak-text-muted: {TextMuted};
        --zak-border: {Border};
        --zak-border-subtle: {BorderSubtle};
        --zak-divider: {Divider};
        --zak-focus-ring: {FocusRing};
        --zak-overlay: {Overlay};
        --zak-appbar-bg: {AppBarBackground};
        --zak-appbar-text: {AppBarText};
        --zak-drawer-bg: {DrawerBackground};
        --zak-drawer-text: {DrawerText};
        --zak-drawer-border: {DrawerBorder};
        --zak-card-bg: {CardBackground};
        --zak-card-border: {CardBorder};

        /* Backward Compatibility & Convenience Aliases */
        --zak-bg-surface: {Surface};
        --zak-border-default: {Border};
        --zak-border-color: {Border};
        --zak-color-primary: {Primary};
        --zak-color-secondary: {Secondary};
        --zak-color-danger: {Danger};
        --zak-color-success: {Success};
        --zak-color-warning: {Warning};
        --zak-color-info: {Info};";
    }

    #region Color Utilities

    private static bool TryParseColor(string hex, out Color color)
    {
        color = Color.Empty;
        if (string.IsNullOrWhiteSpace(hex)) return false;

        hex = hex.TrimStart('#');
        if (hex.Length == 6)
        {
            if (byte.TryParse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, null, out var r) &&
                byte.TryParse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, null, out var g) &&
                byte.TryParse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, null, out var b))
            {
                color = Color.FromArgb(r, g, b);
                return true;
            }
        }
        return false;
    }

    private static Color AdjustLightness(Color color, float amount)
    {
        float h = color.GetHue();
        float s = color.GetSaturation();
        float l = color.GetBrightness();

        l = Math.Clamp(l + amount, 0f, 1f);

        return HslToRgb(h, s, l);
    }

    private static string ColorToHex(Color color) =>
        $"#{color.R:X2}{color.G:X2}{color.B:X2}";

    private static Color HslToRgb(float hue, float saturation, float lightness)
    {
        if (saturation == 0)
        {
            byte val = (byte)(lightness * 255);
            return Color.FromArgb(val, val, val);
        }

        float q = lightness < 0.5f ? lightness * (1 + saturation) : lightness + saturation - (lightness * saturation);
        float p = 2 * lightness - q;
        float hk = hue / 360f;

        float[] tc = [hk + (1f / 3f), hk, hk - (1f / 3f)];
        float[] rgb = new float[3];

        for (int i = 0; i < 3; i++)
        {
            if (tc[i] < 0) tc[i] += 1f;
            if (tc[i] > 1) tc[i] -= 1f;

            if (tc[i] < 1f / 6f)
                rgb[i] = p + ((q - p) * 6f * tc[i]);
            else if (tc[i] < 1f / 2f)
                rgb[i] = q;
            else if (tc[i] < 2f / 3f)
                rgb[i] = p + ((q - p) * ((2f / 3f) - tc[i]) * 6f);
            else
                rgb[i] = p;
        }

        return Color.FromArgb((byte)(rgb[0] * 255), (byte)(rgb[1] * 255), (byte)(rgb[2] * 255));
    }

    #endregion
}