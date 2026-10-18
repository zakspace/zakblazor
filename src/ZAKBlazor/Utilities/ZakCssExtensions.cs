namespace ZAKBlazor.Utilities;

public static class ZakCssExtensions
{
    private static string NormalizePrefix(string prefix) =>
        string.IsNullOrEmpty(prefix) ? string.Empty : (prefix.EndsWith('-') ? prefix : prefix + "-");

    public static string ToCssClass(this ZakColor color, string prefix = "zak-color-")
    {
        prefix = NormalizePrefix(prefix);
        return color switch
        {
            ZakColor.Default => $"{prefix}default",
            ZakColor.Primary => $"{prefix}primary",
            ZakColor.Secondary => $"{prefix}secondary",
            ZakColor.Tertiary => $"{prefix}tertiary",
            ZakColor.Success => $"{prefix}success",
            ZakColor.Warning => $"{prefix}warning",
            ZakColor.Danger => $"{prefix}danger",
            ZakColor.Info => $"{prefix}info",
            ZakColor.Dark => $"{prefix}dark",
            ZakColor.Light => $"{prefix}light",
            ZakColor.Transparent => $"{prefix}transparent",
            ZakColor.Inherit => $"{prefix}inherit",
            _ => $"{prefix}default"
        };
    }

    public static string ToCssClass(this ZakVariant variant, string prefix = "zak-variant-")
    {
        prefix = NormalizePrefix(prefix);
        return variant switch
        {
            ZakVariant.Filled => $"{prefix}filled",
            ZakVariant.Outlined => $"{prefix}outlined",
            ZakVariant.Text => $"{prefix}text",
            ZakVariant.Soft => $"{prefix}soft",
            ZakVariant.Tonal => $"{prefix}tonal",
            ZakVariant.Underline => $"{prefix}underline",
            ZakVariant.Ghost => $"{prefix}ghost",
            _ => $"{prefix}filled"
        };
    }

    public static string ToCssClass(this ZakFormFieldVariant variant, string prefix = "zak-form-field-")
    {
        prefix = NormalizePrefix(prefix);
        return variant switch
        {
            ZakFormFieldVariant.Filled => $"{prefix}filled",
            ZakFormFieldVariant.Outlined => $"{prefix}outlined",
            ZakFormFieldVariant.Underline => $"{prefix}underline",
            ZakFormFieldVariant.Ghost => $"{prefix}ghost",
            _ => $"{prefix}outlined"
        };
    }

    public static string ToCssClass(this ZakSize size, string prefix = "zak-size-")
    {
        prefix = NormalizePrefix(prefix);
        return size switch
        {
            ZakSize.ExtraSmall => $"{prefix}xs",
            ZakSize.Small => $"{prefix}sm",
            ZakSize.Medium => $"{prefix}md",
            ZakSize.Large => $"{prefix}lg",
            ZakSize.ExtraLarge => $"{prefix}xl",
            _ => $"{prefix}md"
        };
    }

    public static string ToCssClass(this ZakShape shape, string prefix = "zak-shape-")
    {
        prefix = NormalizePrefix(prefix);
        return shape switch
        {
            ZakShape.Default => $"{prefix}default",
            ZakShape.Square => $"{prefix}square",
            ZakShape.Rounded => $"{prefix}rounded",
            ZakShape.Pill => $"{prefix}pill",
            ZakShape.Circle => $"{prefix}circle",
            _ => $"{prefix}default"
        };
    }

    public static string ToCssClass(this ZakOrientation orientation, string prefix = "zak-orientation-")
    {
        prefix = NormalizePrefix(prefix);
        return orientation switch
        {
            ZakOrientation.Horizontal => $"{prefix}horizontal",
            ZakOrientation.Vertical => $"{prefix}vertical",
            _ => $"{prefix}horizontal"
        };
    }

    public static string ToCssClass(this int elevation) => elevation switch
    {
        0 => "zak-elevation-0",
        1 => "zak-elevation-1",
        2 => "zak-elevation-2",
        3 => "zak-elevation-3",
        4 => "zak-elevation-4",
        5 => "zak-elevation-5",
        6 => "zak-elevation-6",
        8 => "zak-elevation-8",
        12 => "zak-elevation-12",
        16 => "zak-elevation-16",
        24 => "zak-elevation-24",
        _ => "zak-elevation-0"
    };

    public static string ToCssClass(this Typo typo) => typo switch
    {
        Typo.h1 => "zak-typo-h1",
        Typo.h2 => "zak-typo-h2",
        Typo.h3 => "zak-typo-h3",
        Typo.h4 => "zak-typo-h4",
        Typo.h5 => "zak-typo-h5",
        Typo.h6 => "zak-typo-h6",
        Typo.subtitle1 => "zak-typo-subtitle1",
        Typo.subtitle2 => "zak-typo-subtitle2",
        Typo.body1 => "zak-typo-body1",
        Typo.body2 => "zak-typo-body2",
        Typo.caption => "zak-typo-caption",
        Typo.overline => "zak-typo-overline",
        Typo.button => "zak-typo-button",
        _ => "zak-typo-body1"
    };

    public static string ToHtmlTag(this Typo typo) => typo switch
    {
        Typo.h1 => "h1",
        Typo.h2 => "h2",
        Typo.h3 => "h3",
        Typo.h4 => "h4",
        Typo.h5 => "h5",
        Typo.h6 => "h6",
        Typo.subtitle1 => "h6",
        Typo.subtitle2 => "h6",
        Typo.body1 => "p",
        Typo.body2 => "p",
        Typo.caption => "span",
        Typo.overline => "span",
        Typo.button => "span",
        _ => "p"
    };

    public static string ToCssClass(this ZakAlignment align) => align switch
    {
        ZakAlignment.Start => "zak-align-start",
        ZakAlignment.Center => "zak-align-center",
        ZakAlignment.End => "zak-align-end",
        ZakAlignment.Stretch => "zak-align-stretch",
        ZakAlignment.Baseline => "zak-align-baseline",
        _ => "zak-align-start"
    };

    public static string ToCssClass(this ZakJustify justify) => justify switch
    {
        ZakJustify.Start => "zak-justify-start",
        ZakJustify.Center => "zak-justify-center",
        ZakJustify.End => "zak-justify-end",
        ZakJustify.SpaceBetween => "zak-justify-between",
        ZakJustify.SpaceAround => "zak-justify-around",
        ZakJustify.SpaceEvenly => "zak-justify-evenly",
        _ => "zak-justify-start"
    };
}
