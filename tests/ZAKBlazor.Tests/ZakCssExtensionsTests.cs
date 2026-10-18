using Xunit;
using ZAKBlazor;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Tests;

public class ZakCssExtensionsTests
{
    [Theory]
    [InlineData(ZakColor.Primary, "zak-color-primary")]
    [InlineData(ZakColor.Secondary, "zak-color-secondary")]
    [InlineData(ZakColor.Success, "zak-color-success")]
    [InlineData(ZakColor.Danger, "zak-color-danger")]
    public void ToCssClass_ZakColor_ReturnsExpectedClass(ZakColor color, string expected)
    {
        Assert.Equal(expected, color.ToCssClass());
    }

    [Theory]
    [InlineData(ZakVariant.Filled, "zak-variant-filled")]
    [InlineData(ZakVariant.Outlined, "zak-variant-outlined")]
    [InlineData(ZakVariant.Soft, "zak-variant-soft")]
    [InlineData(ZakVariant.Text, "zak-variant-text")]
    [InlineData(ZakVariant.Underline, "zak-variant-underline")]
    [InlineData(ZakVariant.Ghost, "zak-variant-ghost")]
    public void ToCssClass_ZakVariant_ReturnsExpectedClass(ZakVariant variant, string expected)
    {
        Assert.Equal(expected, variant.ToCssClass());
    }

    [Theory]
    [InlineData(ZakFormFieldVariant.Filled, "zak-form-field-filled")]
    [InlineData(ZakFormFieldVariant.Outlined, "zak-form-field-outlined")]
    [InlineData(ZakFormFieldVariant.Underline, "zak-form-field-underline")]
    [InlineData(ZakFormFieldVariant.Ghost, "zak-form-field-ghost")]
    public void ToCssClass_ZakFormFieldVariant_ReturnsExpectedClass(ZakFormFieldVariant variant, string expected)
    {
        Assert.Equal(expected, variant.ToCssClass());
    }

    [Theory]
    [InlineData(Typo.h1, "zak-typo-h1", "h1")]
    [InlineData(Typo.h3, "zak-typo-h3", "h3")]
    [InlineData(Typo.body1, "zak-typo-body1", "p")]
    [InlineData(Typo.caption, "zak-typo-caption", "span")]
    public void Typo_Mappings_ReturnExpectedValues(Typo typo, string expectedClass, string expectedTag)
    {
        Assert.Equal(expectedClass, typo.ToCssClass());
        Assert.Equal(expectedTag, typo.ToHtmlTag());
    }
}
