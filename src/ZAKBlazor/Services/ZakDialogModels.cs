using Microsoft.AspNetCore.Components;

namespace ZAKBlazor.Services;

/// <summary>
/// Configuration options for displaying a modal dialog.
/// </summary>
public class ZakDialogOptions
{
    /// <summary>
    /// Maximum width constraint for the dialog container.
    /// </summary>
    public string MaxWidth { get; set; } = "560px";

    /// <summary>
    /// Whether the dialog spans the full width up to MaxWidth.
    /// </summary>
    public bool FullWidth { get; set; } = true;

    /// <summary>
    /// Whether clicking on the backdrop closes the dialog.
    /// </summary>
    public bool CloseOnBackdropClick { get; set; } = true;

    /// <summary>
    /// Whether pressing the Escape key closes the dialog.
    /// </summary>
    public bool CloseOnEscape { get; set; } = true;

    /// <summary>
    /// Whether to display a close button (X) in the dialog header.
    /// </summary>
    public bool ShowCloseButton { get; set; } = true;

    /// <summary>
    /// Whether backdrop has a frosted glass blur filter.
    /// </summary>
    public bool BackdropBlur { get; set; } = true;

    /// <summary>
    /// Custom CSS class applied to the dialog dialog surface.
    /// </summary>
    public string? DialogClass { get; set; }

    /// <summary>
    /// Custom inline styles applied to the dialog surface.
    /// </summary>
    public string? DialogStyle { get; set; }
}

/// <summary>
/// Container for component parameters passed into a dynamic modal dialog.
/// </summary>
public class ZakDialogParameters : Dictionary<string, object>
{
    public void Add<T>(string name, T value) where T : notnull
    {
        base[name] = value;
    }

    public T? Get<T>(string name)
    {
        if (TryGetValue(name, out var val) && val is T typed)
        {
            return typed;
        }
        return default;
    }
}

/// <summary>
/// Represents a handle to an open dialog instance.
/// </summary>
public class ZakDialogReference
{
    private readonly TaskCompletionSource<object?> _resultTcs = new();

    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public Type? ComponentType { get; set; }
    public ZakDialogParameters Parameters { get; set; } = new();
    public ZakDialogOptions Options { get; set; } = new();
    public RenderFragment? CustomContent { get; set; }

    /// <summary>
    /// A task that resolves when the dialog is dismissed, containing the dialog result.
    /// </summary>
    public Task<object?> Result => _resultTcs.Task;

    internal void Dismiss(object? result = null)
    {
        _resultTcs.TrySetResult(result);
    }
}
