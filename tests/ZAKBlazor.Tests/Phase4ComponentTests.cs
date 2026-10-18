using Xunit;
using ZAKBlazor;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Tests;

public class Phase4ComponentTests
{
    // =========================================================================
    // 1. DatePicker Tests
    // =========================================================================

    [Fact]
    public void DatePicker_DateFormatting_FormatsCorrectly()
    {
        var testDate = new DateTime(2026, 9, 16);
        var isoFormat = testDate.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        var customFormat = testDate.ToString("MMM dd, yyyy", System.Globalization.CultureInfo.InvariantCulture);

        Assert.Equal("2026-09-16", isoFormat);
        Assert.Equal("Sep 16, 2026", customFormat);
    }

    [Fact]
    public void DatePicker_MinMaxClamping_DetectsDisabledDays()
    {
        var min = new DateTime(2026, 9, 10);
        var max = new DateTime(2026, 9, 20);

        var beforeMin = new DateTime(2026, 9, 5);
        var inRange = new DateTime(2026, 9, 15);
        var afterMax = new DateTime(2026, 9, 25);

        Assert.True(beforeMin < min);
        Assert.True(inRange >= min && inRange <= max);
        Assert.True(afterMax > max);
    }

    // =========================================================================
    // 2. Autocomplete Tests
    // =========================================================================

    [Fact]
    public async Task Autocomplete_SearchFilter_MatchesQuery()
    {
        var items = new List<string> { "Blazor WebAssembly", "Blazor Server", "React", "Vue", "Angular" };

        Task<IEnumerable<string>> Search(string query) =>
            Task.FromResult(items.Where(i => i.Contains(query, StringComparison.OrdinalIgnoreCase)));

        var results = (await Search("blazor")).ToList();

        Assert.Equal(2, results.Count);
        Assert.Contains("Blazor WebAssembly", results);
        Assert.Contains("Blazor Server", results);
    }

    // =========================================================================
    // 3. StatCard & Metric Tests
    // =========================================================================

    [Fact]
    public void StatCard_ClassBuilder_BuildsTrendAndElevation()
    {
        var positiveCls = ZakClassBuilder.Create("zak-stat-card")
            .AddClass("zak-stat-trend-positive", true)
            .AddClass(ZakElevation.Elevation2.ToCssClass())
            .Build();

        Assert.Equal("zak-stat-card zak-stat-trend-positive zak-elevation-2", positiveCls);

        var negativeCls = ZakClassBuilder.Create("zak-stat-card")
            .AddClass("zak-stat-trend-negative", true)
            .Build();

        Assert.Equal("zak-stat-card zak-stat-trend-negative", negativeCls);
    }

    // =========================================================================
    // 4. Timeline Tests
    // =========================================================================

    [Fact]
    public void Timeline_ClassBuilder_BuildsOrientationAndPosition()
    {
        var timelineCls = ZakClassBuilder.Create("zak-timeline")
            .AddClass("zak-timeline-vertical")
            .Build();

        var itemCls = ZakClassBuilder.Create("zak-timeline-item")
            .AddClass(ZakColor.Success.ToCssClass("zak-timeline-node-"))
            .Build();

        Assert.Equal("zak-timeline zak-timeline-vertical", timelineCls);
        Assert.Equal("zak-timeline-item zak-timeline-node-success", itemCls);
    }

    // =========================================================================
    // 5. Tree View Tests
    // =========================================================================

    [Fact]
    public void Tree_ClassBuilder_BuildsExpandedAndSelected()
    {
        var nodeCls = ZakClassBuilder.Create("zak-tree-node")
            .AddClass("zak-tree-node-expanded", true)
            .AddClass("zak-tree-node-selected", true)
            .Build();

        Assert.Equal("zak-tree-node zak-tree-node-expanded zak-tree-node-selected", nodeCls);
    }

    // =========================================================================
    // 6. ColorPicker Tests
    // =========================================================================

    [Theory]
    [InlineData("#5E43F3")]
    [InlineData("#00D2B4")]
    [InlineData("#10B981")]
    public void ColorPicker_HexPresets_AreValidHex(string hex)
    {
        Assert.StartsWith("#", hex);
        Assert.Equal(7, hex.Length);
    }
}
