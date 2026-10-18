using Xunit;
using ZAKBlazor;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Tests;

public class FormControlsTests
{
    [Fact]
    public void InputWrapper_Outlined_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-input-wrapper")
            .AddClass(ZakVariant.Outlined.ToCssClass())
            .AddClass(ZakSize.Medium.ToCssClass())
            .AddClass(ZakColor.Primary.ToCssClass())
            .AddClass("zak-input-error", false)
            .AddClass("zak-disabled", false)
            .Build();

        Assert.Equal("zak-input-wrapper zak-variant-outlined zak-size-md zak-color-primary", cls);
    }

    [Fact]
    public void InputWrapper_FilledWithError_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-input-wrapper")
            .AddClass(ZakVariant.Filled.ToCssClass())
            .AddClass(ZakSize.Large.ToCssClass())
            .AddClass("zak-input-error", true)
            .Build();

        Assert.Equal("zak-input-wrapper zak-variant-filled zak-size-lg zak-input-error", cls);
    }

    [Fact]
    public void InputWrapper_Underline_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-input-wrapper")
            .AddClass(ZakVariant.Underline.ToCssClass())
            .AddClass(ZakSize.Medium.ToCssClass())
            .Build();

        Assert.Equal("zak-input-wrapper zak-variant-underline zak-size-md", cls);
    }

    [Fact]
    public void InputWrapper_Ghost_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-input-wrapper")
            .AddClass(ZakVariant.Ghost.ToCssClass())
            .AddClass(ZakSize.Small.ToCssClass())
            .Build();

        Assert.Equal("zak-input-wrapper zak-variant-ghost zak-size-sm", cls);
    }

    [Theory]
    [InlineData(ZakFormFieldVariant.Outlined, "zak-form-field zak-form-field-outlined zak-variant-outlined")]
    [InlineData(ZakFormFieldVariant.Filled, "zak-form-field zak-form-field-filled zak-variant-filled")]
    [InlineData(ZakFormFieldVariant.Underline, "zak-form-field zak-form-field-underline zak-variant-underline")]
    [InlineData(ZakFormFieldVariant.Ghost, "zak-form-field zak-form-field-ghost zak-variant-ghost")]
    public void FormField_Variants_BuildCorrectClasses(ZakFormFieldVariant variant, string expected)
    {
        var cls = ZakClassBuilder.Create("zak-form-field")
            .AddClass(variant.ToCssClass())
            .AddClass($"zak-variant-{variant.ToString().ToLowerInvariant()}")
            .Build();

        Assert.Equal(expected, cls);
    }

    [Fact]
    public void Label_Required_BuildsRequiredClass()
    {
        var cls = ZakClassBuilder.Create("zak-label")
            .AddClass("zak-label-required", true)
            .Build();

        Assert.Equal("zak-label zak-label-required", cls);
    }

    [Fact]
    public void Checkbox_CheckedAndDisabled_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-checkbox")
            .AddClass("zak-checkbox-checked", true)
            .AddClass(ZakColor.Success.ToCssClass())
            .AddClass("zak-disabled", true)
            .Build();

        Assert.Equal("zak-checkbox zak-checkbox-checked zak-color-success zak-disabled", cls);
    }

    [Fact]
    public void Switch_SmallAndChecked_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-switch")
            .AddClass("zak-switch-checked", true)
            .AddClass("zak-switch-sm", true)
            .AddClass(ZakColor.Primary.ToCssClass())
            .Build();

        Assert.Equal("zak-switch zak-switch-checked zak-switch-sm zak-color-primary", cls);
    }

    [Fact]
    public void RadioGroup_Horizontal_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-radio-group")
            .AddClass("zak-radio-group-horizontal")
            .AddClass(ZakColor.Secondary.ToCssClass())
            .Build();

        Assert.Equal("zak-radio-group zak-radio-group-horizontal zak-color-secondary", cls);
    }

    [Fact]
    public void Slider_ClassBuilder_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-slider")
            .AddClass(ZakColor.Danger.ToCssClass())
            .AddClass("zak-disabled", false)
            .Build();

        Assert.Equal("zak-slider zak-color-danger", cls);
    }

    [Fact]
    public void InputGroup_ClassBuilder_BuildsCorrectBaseClass()
    {
        var cls = ZakClassBuilder.Create("zak-input-group").Build();
        Assert.Equal("zak-input-group", cls);
    }
}
