using Xunit;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Tests;

public class ZakClassBuilderTests
{
    [Fact]
    public void Build_WhenEmpty_ReturnsNull()
    {
        var builder = new ZakClassBuilder();
        Assert.Null(builder.Build());
        Assert.Equal(string.Empty, builder.ToString());
    }

    [Fact]
    public void Build_WithInitialClass_ReturnsInitialClass()
    {
        var builder = new ZakClassBuilder("initial-class");
        Assert.Equal("initial-class", builder.Build());
    }

    [Fact]
    public void AddClass_WhenConditionIsTrue_AppendsClass()
    {
        var builder = ZakClassBuilder.Create("btn")
            .AddClass("btn-primary", true)
            .AddClass("btn-disabled", false);

        Assert.Equal("btn btn-primary", builder.Build());
    }

    [Fact]
    public void AddClass_IgnoresWhitespaceOrNull()
    {
        var builder = ZakClassBuilder.Create()
            .AddClass("   ")
            .AddClass((string?)null)
            .AddClass("active", true);

        Assert.Equal("active", builder.Build());
    }

    [Fact]
    public void AddClass_WithFunc_EvaluatesOnlyWhenConditionIsTrue()
    {
        var executed = false;
        var builder = ZakClassBuilder.Create()
            .AddClass(() => { executed = true; return "dynamic"; }, false);

        Assert.False(executed);
        Assert.Null(builder.Build());

        builder.AddClass(() => { executed = true; return "dynamic"; }, true);
        Assert.True(executed);
        Assert.Equal("dynamic", builder.Build());
    }
}
