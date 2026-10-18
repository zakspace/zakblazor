using Microsoft.AspNetCore.Components;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Primitives;

/// <summary>
/// Root abstract component for all ZAKBlazor components providing consistent parameter binding,
/// attribute splatting, unique identification, and CSS class and style composition.
/// </summary>
public abstract class ZakComponentBase : ComponentBase, IAsyncDisposable, IDisposable
{
    private readonly string _generatedId = $"zak-{Guid.NewGuid():N}"[..12];

    /// <summary>
    /// Unique identifier for the component element.
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    /// <summary>
    /// Resolves the actual element ID attribute (custom or auto-generated).
    /// </summary>
    public string ElementId => Id ?? _generatedId;

    /// <summary>
    /// Custom CSS classes applied to the root element.
    /// </summary>
    [Parameter]
    public string? Class { get; set; }

    /// <summary>
    /// Custom inline styles applied to the root element.
    /// </summary>
    [Parameter]
    public string? Style { get; set; }

    /// <summary>
    /// User-defined custom tag or metadata associated with the component.
    /// </summary>
    [Parameter]
    public object? Tag { get; set; }

    /// <summary>
    /// Captures any unmatched attributes (e.g. data-*, aria-*, custom attributes).
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Resolves the component's internal CSS class composition.
    /// </summary>
    protected virtual string? Classname => Class;

    /// <summary>
    /// Resolves the component's internal inline style composition.
    /// </summary>
    protected virtual string? Stylename => Style;

    /// <summary>
    /// Helper to construct CSS class strings fluently.
    /// </summary>
    protected ZakClassBuilder CreateClassBuilder(string? defaultClass = null) =>
        ZakClassBuilder.Create(defaultClass)
            .AddClass(Classname);

    /// <summary>
    /// Helper to construct inline styles fluently.
    /// </summary>
    protected ZakStyleBuilder CreateStyleBuilder(string? defaultStyle = null) =>
        ZakStyleBuilder.Create(defaultStyle)
            .AddRaw(Stylename);

    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual ValueTask DisposeAsync()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}
