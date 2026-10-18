namespace ZAKBlazor;

public class ZakTypography
{
    public string FontFamily { get; set; } = "'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif";
    public string FontFamilyMonospace { get; set; } = "'Fira Code', 'JetBrains Mono', Consolas, Monaco, monospace";

    public ZakTypographyScale H1 { get; set; } = new("2.5rem", "700", "1.2", "-0.025em");
    public ZakTypographyScale H2 { get; set; } = new("2rem", "700", "1.25", "-0.02em");
    public ZakTypographyScale H3 { get; set; } = new("1.625rem", "600", "1.3", "-0.015em");
    public ZakTypographyScale H4 { get; set; } = new("1.375rem", "600", "1.35", "-0.01em");
    public ZakTypographyScale H5 { get; set; } = new("1.125rem", "600", "1.4", "0");
    public ZakTypographyScale H6 { get; set; } = new("1rem", "600", "1.45", "0");

    public ZakTypographyScale Subtitle1 { get; set; } = new("1rem", "500", "1.5", "0");
    public ZakTypographyScale Subtitle2 { get; set; } = new("0.875rem", "500", "1.5", "0");

    public ZakTypographyScale Body1 { get; set; } = new("1rem", "400", "1.5", "0");
    public ZakTypographyScale Body2 { get; set; } = new("0.875rem", "400", "1.5", "0");

    public ZakTypographyScale Caption { get; set; } = new("0.75rem", "400", "1.4", "0");
    public ZakTypographyScale Overline { get; set; } = new("0.75rem", "600", "1.4", "0.08em", "uppercase");
    public ZakTypographyScale Button { get; set; } = new("0.875rem", "500", "1.5", "0.01em");

    public virtual string ToCssVariables()
    {
        return $@"
        --zak-font-family: {FontFamily};
        --zak-font-family-mono: {FontFamilyMonospace};

        --zak-typo-h1-size: {H1.FontSize};
        --zak-typo-h1-weight: {H1.FontWeight};
        --zak-typo-h1-line-height: {H1.LineHeight};
        --zak-typo-h1-letter-spacing: {H1.LetterSpacing};

        --zak-typo-h2-size: {H2.FontSize};
        --zak-typo-h2-weight: {H2.FontWeight};
        --zak-typo-h2-line-height: {H2.LineHeight};
        --zak-typo-h2-letter-spacing: {H2.LetterSpacing};

        --zak-typo-h3-size: {H3.FontSize};
        --zak-typo-h3-weight: {H3.FontWeight};
        --zak-typo-h3-line-height: {H3.LineHeight};
        --zak-typo-h3-letter-spacing: {H3.LetterSpacing};

        --zak-typo-h4-size: {H4.FontSize};
        --zak-typo-h4-weight: {H4.FontWeight};
        --zak-typo-h4-line-height: {H4.LineHeight};
        --zak-typo-h4-letter-spacing: {H4.LetterSpacing};

        --zak-typo-h5-size: {H5.FontSize};
        --zak-typo-h5-weight: {H5.FontWeight};
        --zak-typo-h5-line-height: {H5.LineHeight};

        --zak-typo-h6-size: {H6.FontSize};
        --zak-typo-h6-weight: {H6.FontWeight};
        --zak-typo-h6-line-height: {H6.LineHeight};

        --zak-typo-sub1-size: {Subtitle1.FontSize};
        --zak-typo-sub1-weight: {Subtitle1.FontWeight};
        --zak-typo-sub1-line-height: {Subtitle1.LineHeight};

        --zak-typo-sub2-size: {Subtitle2.FontSize};
        --zak-typo-sub2-weight: {Subtitle2.FontWeight};
        --zak-typo-sub2-line-height: {Subtitle2.LineHeight};

        --zak-typo-body1-size: {Body1.FontSize};
        --zak-typo-body1-weight: {Body1.FontWeight};
        --zak-typo-body1-line-height: {Body1.LineHeight};

        --zak-typo-body2-size: {Body2.FontSize};
        --zak-typo-body2-weight: {Body2.FontWeight};
        --zak-typo-body2-line-height: {Body2.LineHeight};

        --zak-typo-caption-size: {Caption.FontSize};
        --zak-typo-caption-weight: {Caption.FontWeight};
        --zak-typo-caption-line-height: {Caption.LineHeight};

        --zak-typo-overline-size: {Overline.FontSize};
        --zak-typo-overline-weight: {Overline.FontWeight};
        --zak-typo-overline-transform: {Overline.TextTransform};

        --zak-typo-button-size: {Button.FontSize};
        --zak-typo-button-weight: {Button.FontWeight};";
    }
}

public class ZakTypographyScale
{
    public string FontSize { get; set; }
    public string FontWeight { get; set; }
    public string LineHeight { get; set; }
    public string LetterSpacing { get; set; }
    public string TextTransform { get; set; }

    public ZakTypographyScale(
        string fontSize,
        string fontWeight = "400",
        string lineHeight = "1.5",
        string letterSpacing = "0",
        string textTransform = "none")
    {
        FontSize = fontSize;
        FontWeight = fontWeight;
        LineHeight = lineHeight;
        LetterSpacing = letterSpacing;
        TextTransform = textTransform;
    }
}
