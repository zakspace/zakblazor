using System.Text;

namespace ZAKBlazor;

/// <summary>
/// Root Theme definition in ZAKBlazor encompassing Palette, Typography, Spacing, Shapes, Elevations, and Z-Indexes.
/// </summary>
public class ZakTheme
{
    public ZakPalette PaletteLight { get; set; } = new ZakPaletteLight();
    public ZakPalette PaletteDark { get; set; } = new ZakPaletteDark();
    public ZakTypography Typography { get; set; } = new();
    public ZakSpacingTokens Spacing { get; set; } = new();
    public ZakShapeTokens Shape { get; set; } = new();
    public ZakElevationTokens Elevation { get; set; } = new();
    public ZakZIndexTokens ZIndex { get; set; } = new();

    /// <summary>
    /// Generates CSS custom properties according to the active dark/light mode or default palette.
    /// </summary>
    public string BuildCss(bool isDarkMode)
    {
        var activePalette = isDarkMode ? PaletteDark : PaletteLight;
        var sb = new StringBuilder(4096);

        sb.AppendLine(":root {");
        sb.AppendLine(activePalette.ToCssVariables());
        sb.AppendLine(Typography.ToCssVariables());
        sb.AppendLine(Spacing.ToCssVariables());
        sb.AppendLine(Shape.ToCssVariables());
        sb.AppendLine(Elevation.ToCssVariables());
        sb.AppendLine(ZIndex.ToCssVariables());
        sb.AppendLine("}");

        sb.AppendLine("[data-theme=\"light\"], .zak-theme-light {");
        sb.AppendLine(PaletteLight.ToCssVariables());
        sb.AppendLine("}");

        sb.AppendLine("[data-theme=\"dark\"], .zak-theme-dark {");
        sb.AppendLine(PaletteDark.ToCssVariables());
        sb.AppendLine("}");

        return sb.ToString();
    }
}
