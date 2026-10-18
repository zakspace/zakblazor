using Xunit;
using ZAKBlazor;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Tests;

public class Phase2ComponentTests
{
    [Fact]
    public void ButtonToolbar_ClassBuilder_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-btn-toolbar")
            .AddClass(ZakJustify.SpaceBetween.ToCssClass())
            .AddClass("zak-gap-3")
            .AddClass("zak-toolbar-wrap", true)
            .Build();

        Assert.Equal("zak-btn-toolbar zak-justify-between zak-gap-3 zak-toolbar-wrap", cls);
    }

    [Fact]
    public void FloatingActionButton_Circular_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-fab")
            .AddClass(ZakColor.Primary.ToCssClass())
            .AddClass(ZakSize.Large.ToCssClass())
            .AddClass(ZakElevation.Elevation6.ToCssClass())
            .AddClass("zak-fab-circular", true)
            .AddClass("zak-fab-fixed-bottom-end")
            .Build();

        Assert.Equal("zak-fab zak-color-primary zak-size-lg zak-elevation-6 zak-fab-circular zak-fab-fixed-bottom-end", cls);
    }

    [Fact]
    public void FloatingActionButton_Extended_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-fab")
            .AddClass(ZakColor.Secondary.ToCssClass())
            .AddClass(ZakSize.Medium.ToCssClass())
            .AddClass(ZakElevation.Elevation4.ToCssClass())
            .AddClass("zak-fab-extended", true)
            .AddClass("zak-fab-inline")
            .Build();

        Assert.Equal("zak-fab zak-color-secondary zak-size-md zak-elevation-4 zak-fab-extended zak-fab-inline", cls);
    }

    [Fact]
    public void LoadingButton_State_BuildsLoadingAndDisabledClasses()
    {
        var cls = ZakClassBuilder.Create("zak-btn zak-loading-btn")
            .AddClass(ZakVariant.Filled.ToCssClass())
            .AddClass(ZakColor.Success.ToCssClass())
            .AddClass("zak-btn-loading", true)
            .AddClass("zak-disabled", true)
            .Build();

        Assert.Equal("zak-btn zak-loading-btn zak-variant-filled zak-color-success zak-btn-loading zak-disabled", cls);
    }

    [Fact]
    public void Section_ClassBuilder_BuildsPaddingAndThemeColor()
    {
        var cls = ZakClassBuilder.Create("zak-section")
            .AddClass("zak-section-p-8")
            .AddClass(ZakColor.Primary.ToCssClass("zak-section-"))
            .Build();

        Assert.Equal("zak-section zak-section-p-8 zak-section-primary", cls);
    }

    [Fact]
    public void AspectRatio_RatioFormatting_ConvertsColonToSlash()
    {
        var ratioColon = "16:9".Replace(':', '/');
        var ratioSlash = "4/3".Replace(':', '/');

        Assert.Equal("16/9", ratioColon);
        Assert.Equal("4/3", ratioSlash);
    }

    [Fact]
    public void Breadcrumbs_Classes_AreConsistent()
    {
        var navClass = ZakClassBuilder.Create("zak-breadcrumbs").Build();
        var itemClass = ZakClassBuilder.Create("zak-breadcrumb-item")
            .AddClass("zak-disabled", false)
            .Build();
        var currentClass = ZakClassBuilder.Create("zak-breadcrumb-content")
            .AddClass("zak-breadcrumb-current", true)
            .Build();

        Assert.Equal("zak-breadcrumbs", navClass);
        Assert.Equal("zak-breadcrumb-item", itemClass);
        Assert.Equal("zak-breadcrumb-content zak-breadcrumb-current", currentClass);
    }

    [Theory]
    [InlineData(ZakLoadingPosition.Center)]
    [InlineData(ZakLoadingPosition.Start)]
    [InlineData(ZakLoadingPosition.End)]
    public void ZakLoadingPosition_EnumValues_AreValid(ZakLoadingPosition position)
    {
        Assert.True(Enum.IsDefined(typeof(ZakLoadingPosition), position));
    }

    [Theory]
    [InlineData(ZakFabPlacement.None)]
    [InlineData(ZakFabPlacement.BottomEnd)]
    [InlineData(ZakFabPlacement.BottomStart)]
    [InlineData(ZakFabPlacement.TopEnd)]
    [InlineData(ZakFabPlacement.TopStart)]
    public void ZakFabPlacement_EnumValues_AreValid(ZakFabPlacement placement)
    {
        Assert.True(Enum.IsDefined(typeof(ZakFabPlacement), placement));
    }

    [Fact]
    public void Card_ClassBuilder_BuildsCorrectClasses()
    {
        var cls = ZakClassBuilder.Create("zak-card")
            .AddClass(ZakElevation.Elevation3.ToCssClass(), true)
            .AddClass("zak-card-hoverable", true)
            .AddClass("zak-card-clickable", true)
            .AddClass(ZakShape.Rounded.ToCssClass())
            .Build();

        Assert.Equal("zak-card zak-elevation-3 zak-card-hoverable zak-card-clickable zak-shape-rounded", cls);
    }

    [Fact]
    public void Card_Outlined_OmitsElevation()
    {
        var isOutlined = true;
        var cls = ZakClassBuilder.Create("zak-card")
            .AddClass(ZakElevation.Elevation3.ToCssClass(), !isOutlined)
            .AddClass("zak-card-outlined", isOutlined)
            .Build();

        Assert.Equal("zak-card zak-card-outlined", cls);
    }

    [Fact]
    public void Badge_ClassBuilder_BuildsPillAndDotClasses()
    {
        var badgeCls = ZakClassBuilder.Create("zak-badge")
            .AddClass(ZakColor.Danger.ToCssClass("zak-badge-"))
            .AddClass("zak-badge-top-end")
            .AddClass("zak-badge-overlap", true)
            .AddClass("zak-badge-pulse", true)
            .Build();

        Assert.Equal("zak-badge zak-badge-danger zak-badge-top-end zak-badge-overlap zak-badge-pulse", badgeCls);

        var dotCls = ZakClassBuilder.Create("zak-badge")
            .AddClass(ZakColor.Primary.ToCssClass("zak-badge-"))
            .AddClass("zak-badge-dot", true)
            .Build();

        Assert.Equal("zak-badge zak-badge-primary zak-badge-dot", dotCls);
    }

    [Fact]
    public void Chip_ClassBuilder_BuildsStateClasses()
    {
        var cls = ZakClassBuilder.Create("zak-chip")
            .AddClass(ZakVariant.Filled.ToCssClass())
            .AddClass(ZakColor.Primary.ToCssClass())
            .AddClass(ZakSize.Small.ToCssClass())
            .AddClass("zak-chip-clickable", true)
            .AddClass("zak-chip-removable", true)
            .AddClass("zak-chip-selected", true)
            .AddClass("zak-disabled", false)
            .Build();

        Assert.Equal("zak-chip zak-variant-filled zak-color-primary zak-size-sm zak-chip-clickable zak-chip-removable zak-chip-selected", cls);
    }

    [Fact]
    public void Avatar_ClassBuilder_BuildsShapeAndColor()
    {
        var cls = ZakClassBuilder.Create("zak-avatar")
            .AddClass(ZakSize.Large.ToCssClass())
            .AddClass(ZakColor.Secondary.ToCssClass())
            .AddClass(ZakShape.Rounded.ToCssClass())
            .AddClass("zak-avatar-image", false)
            .Build();

        Assert.Equal("zak-avatar zak-size-lg zak-color-secondary zak-shape-rounded", cls);
    }

    [Fact]
    public void Tabs_ClassBuilder_BuildsDirectionAndScrollable()
    {
        var cls = ZakClassBuilder.Create("zak-tabs")
            .AddClass("zak-tabs-horizontal")
            .AddClass("zak-tabs-scrollable", true)
            .AddClass("zak-tabs-centered", false)
            .Build();

        Assert.Equal("zak-tabs zak-tabs-horizontal zak-tabs-scrollable", cls);
    }

    [Fact]
    public void MenuItem_ClassBuilder_BuildsDangerAndDisabled()
    {
        var cls = ZakClassBuilder.Create("zak-menu-item")
            .AddClass("zak-menu-item-danger", true)
            .AddClass("zak-disabled", true)
            .Build();

        Assert.Equal("zak-menu-item zak-menu-item-danger zak-disabled", cls);
    }
}
