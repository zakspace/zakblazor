using Xunit;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Tests;

public class ZakStyleBuilderTests
{
    [Fact]
    public void Build_WhenEmpty_ReturnsNull()
    {
        var builder = new ZakStyleBuilder();
        Assert.Null(builder.Build());
        Assert.Equal(string.Empty, builder.ToString());
    }

    [Fact]
    public void AddStyle_WhenConditionIsTrue_AddsProperlyFormattedProperty()
    {
        var style = ZakStyleBuilder.Create()
            .AddStyle("color", "red", true)
            .AddStyle("font-size", "14px", true)
            .AddStyle("display", "none", false)
            .Build();

        Assert.Equal("color: red; font-size: 14px;", style);
    }

    [Fact]
    public void AddRaw_WhenConditionIsTrue_AppendsRawWithSemicolon()
    {
        var style = ZakStyleBuilder.Create("margin: 0")
            .AddRaw("padding: 10px")
            .Build();

        Assert.Equal("margin: 0; padding: 10px;", style);
    }
}
