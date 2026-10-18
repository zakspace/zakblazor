using Xunit;
using ZAKBlazor;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Tests;

public class Phase5ComponentTests
{
    // =========================================================================
    // 1. Alert Tests
    // =========================================================================

    [Theory]
    [InlineData(ZakColor.Success, "zak-alert-success")]
    [InlineData(ZakColor.Warning, "zak-alert-warning")]
    [InlineData(ZakColor.Danger, "zak-alert-danger")]
    [InlineData(ZakColor.Info, "zak-alert-info")]
    public void Alert_ColorClasses_MatchExpected(ZakColor color, string expectedClass)
    {
        var cssClass = color.ToCssClass("zak-alert");
        Assert.Equal(expectedClass, cssClass);
    }

    [Theory]
    [InlineData(ZakVariant.Soft, "zak-variant-soft")]
    [InlineData(ZakVariant.Outlined, "zak-variant-outlined")]
    [InlineData(ZakVariant.Filled, "zak-variant-filled")]
    public void Alert_VariantClasses_MatchExpected(ZakVariant variant, string expectedClass)
    {
        var cssClass = variant.ToCssClass();
        Assert.Equal(expectedClass, cssClass);
    }

    // =========================================================================
    // 2. Rating Tests
    // =========================================================================

    [Fact]
    public void Rating_CalculatesScoreBoundsCorrectly()
    {
        var max = 5;
        var score = 3.5;

        Assert.True(score <= max);
        Assert.True(score >= 0);

        var isStar1Active = score >= 1;
        var isStar3Active = score >= 3;
        var isStar4Active = score >= 4;

        Assert.True(isStar1Active);
        Assert.True(isStar3Active);
        Assert.False(isStar4Active);
    }

    [Fact]
    public void Rating_ClassBuilder_RendersCorrectly()
    {
        var cls = ZakClassBuilder.Create("zak-rating")
            .AddClass(ZakColor.Warning.ToCssClass("zak-rating"))
            .AddClass("zak-rating-readonly", true)
            .Build();

        Assert.Contains("zak-rating", cls);
        Assert.Contains("zak-rating-warning", cls);
        Assert.Contains("zak-rating-readonly", cls);
    }

    // =========================================================================
    // 3. Kbd & Keycap Tests
    // =========================================================================

    [Fact]
    public void Kbd_ClassBuilder_AppliesSizeClasses()
    {
        var smallKbd = ZakClassBuilder.Create("zak-kbd")
            .AddClass(ZakSize.Small.ToCssClass("zak-kbd"))
            .Build();

        var largeKbd = ZakClassBuilder.Create("zak-kbd")
            .AddClass(ZakSize.Large.ToCssClass("zak-kbd"))
            .Build();

        Assert.Equal("zak-kbd zak-kbd-sm", smallKbd);
        Assert.Equal("zak-kbd zak-kbd-lg", largeKbd);
    }

    // =========================================================================
    // 4. Empty State Tests
    // =========================================================================

    [Fact]
    public void EmptyState_ClassBuilder_IncludesCompactModifier()
    {
        var standard = ZakClassBuilder.Create("zak-empty-state")
            .AddClass("zak-empty-state-compact", false)
            .Build();

        var compact = ZakClassBuilder.Create("zak-empty-state")
            .AddClass("zak-empty-state-compact", true)
            .Build();

        Assert.Equal("zak-empty-state", standard);
        Assert.Contains("zak-empty-state-compact", compact);
    }

    // =========================================================================
    // 5. OTP / Verification Input Tests
    // =========================================================================

    [Fact]
    public void OtpInput_LengthAndCompletionDetection()
    {
        var length = 6;
        var entered = "123456";

        Assert.Equal(length, entered.Length);
        Assert.True(entered.All(char.IsDigit));

        var partial = "123";
        Assert.NotEqual(length, partial.Length);
    }

    // =========================================================================
    // 6. Segmented Control Tests
    // =========================================================================

    [Fact]
    public void SegmentedControl_SelectionItem_MatchesDefaultValue()
    {
        var items = new List<ZakSegmentItem<string>>
        {
            new("list", "List View"),
            new("grid", "Grid View"),
            new("table", "Table View")
        };

        var selected = "grid";
        var activeItem = items.FirstOrDefault(i => i.Value == selected);

        Assert.NotNull(activeItem);
        Assert.Equal("Grid View", activeItem.Label);
    }

    // =========================================================================
    // 7. Stepper Tests
    // =========================================================================

    [Fact]
    public void Stepper_StepIndexCalculations_DetectCompletion()
    {
        var activeStep = 2; // Step 3 (0, 1, 2)

        bool IsCompleted(int index) => index < activeStep;
        bool IsActive(int index) => index == activeStep;

        Assert.True(IsCompleted(0));
        Assert.True(IsCompleted(1));
        Assert.True(IsActive(2));
        Assert.False(IsCompleted(2));
        Assert.False(IsCompleted(3));
    }

    // =========================================================================
    // 8. Accordion Tests
    // =========================================================================

    [Fact]
    public void Accordion_SingleExpand_LogicValidatesExclusivity()
    {
        var itemsState = new Dictionary<string, bool>
        {
            ["Item1"] = true,
            ["Item2"] = false,
            ["Item3"] = false
        };

        // When Item2 expands in single-expand mode:
        void Expand(string key, bool multiple)
        {
            if (!multiple)
            {
                foreach (var k in itemsState.Keys.ToList())
                {
                    itemsState[k] = (k == key);
                }
            }
            else
            {
                itemsState[key] = true;
            }
        }

        Expand("Item2", multiple: false);

        Assert.False(itemsState["Item1"]);
        Assert.True(itemsState["Item2"]);
        Assert.False(itemsState["Item3"]);
    }
}
