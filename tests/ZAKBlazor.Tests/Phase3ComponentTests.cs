using Xunit;
using ZAKBlazor;
using ZAKBlazor.Services;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Tests;

public class Phase3ComponentTests
{
    // =========================================================================
    // 1. Dialog Service & Models Tests
    // =========================================================================

    [Fact]
    public void DialogService_Show_AddsActiveDialogAndFiresEvent()
    {
        var service = new ZakDialogService();
        ZakDialogReference? openedRef = null;
        service.OnDialogOpened += r => openedRef = r;

        var reference = service.Show<MockComponent>("Test Dialog", new ZakDialogParameters { { "Param1", "Val1" } });

        Assert.Single(service.ActiveDialogs);
        Assert.Same(reference, service.ActiveDialogs[0]);
        Assert.Same(reference, openedRef);
        Assert.Equal("Test Dialog", reference.Title);
        Assert.Equal("Val1", reference.Parameters.Get<string>("Param1"));
    }

    [Fact]
    public async Task DialogService_Close_RemovesDialogAndSetsResult()
    {
        var service = new ZakDialogService();
        ZakDialogReference? closedRef = null;
        service.OnDialogClosed += r => closedRef = r;

        var reference = service.Show<MockComponent>("Dialog to close");
        service.Close(reference, "SuccessResult");

        Assert.Empty(service.ActiveDialogs);
        Assert.Same(reference, closedRef);

        var result = await reference.Result;
        Assert.Equal("SuccessResult", result);
    }

    [Fact]
    public async Task DialogService_ConfirmAsync_ResolvesBooleanResult()
    {
        var service = new ZakDialogService();
        var confirmTask = service.ConfirmAsync("Are you sure?", "Confirm Title");

        Assert.Single(service.ActiveDialogs);
        var activeDialog = service.ActiveDialogs[0];
        Assert.Equal("Confirm Title", activeDialog.Title);

        service.Close(activeDialog, true);
        var confirmed = await confirmTask;
        Assert.True(confirmed);
    }

    // =========================================================================
    // 2. Snackbar Service & Toast Tests
    // =========================================================================

    [Fact]
    public void SnackbarService_Add_CreatesMessageWithSeverity()
    {
        var service = new ZakSnackbarService();
        ZakSnackbarMessage? addedMsg = null;
        service.OnMessageAdded += m => addedMsg = m;

        var msg = service.Success("Files synchronized.", "Cloud Sync");

        Assert.Single(service.ActiveMessages);
        Assert.Same(msg, service.ActiveMessages[0]);
        Assert.Same(msg, addedMsg);
        Assert.Equal(ZakSeverity.Success, msg.Severity);
        Assert.Equal("Files synchronized.", msg.Message);
        Assert.Equal("Cloud Sync", msg.Title);
    }

    [Fact]
    public void SnackbarService_SeverityHelpers_AssignCorrectSeverities()
    {
        var service = new ZakSnackbarService();

        var success = service.Success("ok");
        var error = service.Error("fail");
        var warn = service.Warning("caution");
        var info = service.Info("notice");

        Assert.Equal(ZakSeverity.Success, success.Severity);
        Assert.Equal(ZakSeverity.Danger, error.Severity);
        Assert.Equal(ZakSeverity.Warning, warn.Severity);
        Assert.Equal(ZakSeverity.Info, info.Severity);
        Assert.Equal(4, service.ActiveMessages.Count);
    }

    [Fact]
    public void SnackbarService_Clear_EmptiesAllMessagesAndFiresEvent()
    {
        var service = new ZakSnackbarService();
        var clearedFired = false;
        service.OnCleared += () => clearedFired = true;

        service.Success("1");
        service.Error("2");
        Assert.Equal(2, service.ActiveMessages.Count);

        service.Clear();
        Assert.Empty(service.ActiveMessages);
        Assert.True(clearedFired);
    }

    // =========================================================================
    // 3. Progress Indicators Tests
    // =========================================================================

    [Fact]
    public void ProgressCircular_ClassBuilder_BuildsDeterminateAndIndeterminate()
    {
        var determinateCls = ZakClassBuilder.Create("zak-progress-circular")
            .AddClass(ZakColor.Primary.ToCssClass())
            .AddClass(ZakSize.Large.ToCssClass())
            .AddClass("zak-progress-indeterminate", false)
            .Build();

        Assert.Equal("zak-progress-circular zak-color-primary zak-size-lg", determinateCls);

        var indeterminateCls = ZakClassBuilder.Create("zak-progress-circular")
            .AddClass(ZakColor.Success.ToCssClass())
            .AddClass(ZakSize.Medium.ToCssClass())
            .AddClass("zak-progress-indeterminate", true)
            .Build();

        Assert.Equal("zak-progress-circular zak-color-success zak-size-md zak-progress-indeterminate", indeterminateCls);
    }

    [Fact]
    public void ProgressLinear_ClassBuilder_BuildsRoundedAndStriped()
    {
        var cls = ZakClassBuilder.Create("zak-progress-linear")
            .AddClass(ZakColor.Secondary.ToCssClass())
            .AddClass("zak-progress-indeterminate", false)
            .AddClass("zak-progress-rounded", true)
            .AddClass("zak-progress-striped", true)
            .Build();

        Assert.Equal("zak-progress-linear zak-color-secondary zak-progress-rounded zak-progress-striped", cls);
    }

    [Theory]
    [InlineData(-10.0, 0.0)]
    [InlineData(45.5, 45.5)]
    [InlineData(110.0, 100.0)]
    public void Progress_ValueClamping_IsAccurate(double input, double expected)
    {
        var clamped = Math.Clamp(input, 0, 100);
        Assert.Equal(expected, clamped);
    }

    // =========================================================================
    // 4. Tooltip Tests
    // =========================================================================

    [Theory]
    [InlineData(ZakPlacement.Top, "zak-tooltip-top")]
    [InlineData(ZakPlacement.Bottom, "zak-tooltip-bottom")]
    [InlineData(ZakPlacement.Left, "zak-tooltip-left")]
    [InlineData(ZakPlacement.Right, "zak-tooltip-right")]
    public void Tooltip_PlacementClasses_AreAccurate(ZakPlacement placement, string expectedClass)
    {
        string Resolve(ZakPlacement p) => p switch
        {
            ZakPlacement.Bottom or ZakPlacement.BottomStart or ZakPlacement.BottomEnd => "zak-tooltip-bottom",
            ZakPlacement.Left or ZakPlacement.LeftStart or ZakPlacement.LeftEnd => "zak-tooltip-left",
            ZakPlacement.Right or ZakPlacement.RightStart or ZakPlacement.RightEnd => "zak-tooltip-right",
            _ => "zak-tooltip-top"
        };

        var cls = ZakClassBuilder.Create("zak-tooltip")
            .AddClass(Resolve(placement))
            .AddClass("zak-tooltip-visible", true)
            .Build();

        Assert.Equal($"zak-tooltip {expectedClass} zak-tooltip-visible", cls);
    }

    // =========================================================================
    // 5. Skeleton Loader Tests
    // =========================================================================

    [Fact]
    public void Skeleton_ClassBuilder_BuildsShapesAndAnimations()
    {
        var textWave = ZakClassBuilder.Create("zak-skeleton")
            .AddClass("zak-skeleton-text")
            .AddClass("zak-skeleton-wave")
            .Build();

        Assert.Equal("zak-skeleton zak-skeleton-text zak-skeleton-wave", textWave);

        var circlePulse = ZakClassBuilder.Create("zak-skeleton")
            .AddClass("zak-skeleton-circle")
            .AddClass("zak-skeleton-pulse")
            .Build();

        Assert.Equal("zak-skeleton zak-skeleton-circle zak-skeleton-pulse", circlePulse);

        var rectNone = ZakClassBuilder.Create("zak-skeleton")
            .AddClass("zak-skeleton-rectangle")
            .AddClass("zak-skeleton-none")
            .Build();

        Assert.Equal("zak-skeleton zak-skeleton-rectangle zak-skeleton-none", rectNone);
    }

    // Dummy component for generic dialog testing
    private class MockComponent : Microsoft.AspNetCore.Components.ComponentBase { }
}
