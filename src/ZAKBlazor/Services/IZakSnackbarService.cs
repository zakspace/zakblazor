namespace ZAKBlazor.Services;

/// <summary>
/// Configuration options for toast snackbar notifications.
/// </summary>
public class ZakSnackbarOptions
{
    /// <summary>
    /// Duration in milliseconds before auto-dismissal. Default is 4000ms.
    /// Set to 0 or negative to prevent auto-dismissal.
    /// </summary>
    public int Duration { get; set; } = 4000;

    /// <summary>
    /// Whether to display a close button (X) on the snackbar.
    /// </summary>
    public bool ShowCloseButton { get; set; } = true;

    /// <summary>
    /// Whether to display a countdown progress bar at the bottom.
    /// </summary>
    public bool ShowProgressBar { get; set; } = true;

    /// <summary>
    /// Optional action button label (e.g. "UNDO", "RETRY").
    /// </summary>
    public string? ActionText { get; set; }

    /// <summary>
    /// Callback executed when the action button is clicked.
    /// </summary>
    public Action? OnActionClick { get; set; }

    /// <summary>
    /// Screen placement anchor for the snackbars. Default is BottomEnd.
    /// </summary>
    public ZakPlacement Placement { get; set; } = ZakPlacement.BottomEnd;
}

/// <summary>
/// Represents an active snackbar notification toast.
/// </summary>
public class ZakSnackbarMessage
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Message { get; set; } = string.Empty;
    public string? Title { get; set; }
    public ZakSeverity Severity { get; set; } = ZakSeverity.Normal;
    public ZakSnackbarOptions Options { get; set; } = new();
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}

/// <summary>
/// Service for triggering toast notifications across the application.
/// </summary>
public interface IZakSnackbarService
{
    event Action<ZakSnackbarMessage>? OnMessageAdded;
    event Action<ZakSnackbarMessage>? OnMessageRemoved;
    event Action? OnCleared;

    IReadOnlyList<ZakSnackbarMessage> ActiveMessages { get; }

    ZakSnackbarMessage Add(string message, ZakSeverity severity = ZakSeverity.Normal, Action<ZakSnackbarOptions>? configure = null);
    ZakSnackbarMessage Success(string message, string? title = null, Action<ZakSnackbarOptions>? configure = null);
    ZakSnackbarMessage Error(string message, string? title = null, Action<ZakSnackbarOptions>? configure = null);
    ZakSnackbarMessage Warning(string message, string? title = null, Action<ZakSnackbarOptions>? configure = null);
    ZakSnackbarMessage Info(string message, string? title = null, Action<ZakSnackbarOptions>? configure = null);

    void Remove(ZakSnackbarMessage message);
    void Clear();
}
