namespace ZAKBlazor.Services;

/// <summary>
/// Implementation of IZakSnackbarService managing the active notification toast queue.
/// </summary>
public class ZakSnackbarService : IZakSnackbarService
{
    private readonly List<ZakSnackbarMessage> _activeMessages = new();

    public event Action<ZakSnackbarMessage>? OnMessageAdded;
    public event Action<ZakSnackbarMessage>? OnMessageRemoved;
    public event Action? OnCleared;

    public IReadOnlyList<ZakSnackbarMessage> ActiveMessages => _activeMessages.AsReadOnly();

    public ZakSnackbarMessage Add(string message, ZakSeverity severity = ZakSeverity.Normal, Action<ZakSnackbarOptions>? configure = null)
    {
        var options = new ZakSnackbarOptions();
        configure?.Invoke(options);

        var snackbarMessage = new ZakSnackbarMessage
        {
            Message = message,
            Severity = severity,
            Options = options
        };

        _activeMessages.Add(snackbarMessage);
        OnMessageAdded?.Invoke(snackbarMessage);
        return snackbarMessage;
    }

    public ZakSnackbarMessage Success(string message, string? title = null, Action<ZakSnackbarOptions>? configure = null)
    {
        var msg = Add(message, ZakSeverity.Success, configure);
        msg.Title = title;
        return msg;
    }

    public ZakSnackbarMessage Error(string message, string? title = null, Action<ZakSnackbarOptions>? configure = null)
    {
        var msg = Add(message, ZakSeverity.Danger, configure);
        msg.Title = title;
        return msg;
    }

    public ZakSnackbarMessage Warning(string message, string? title = null, Action<ZakSnackbarOptions>? configure = null)
    {
        var msg = Add(message, ZakSeverity.Warning, configure);
        msg.Title = title;
        return msg;
    }

    public ZakSnackbarMessage Info(string message, string? title = null, Action<ZakSnackbarOptions>? configure = null)
    {
        var msg = Add(message, ZakSeverity.Info, configure);
        msg.Title = title;
        return msg;
    }

    public void Remove(ZakSnackbarMessage message)
    {
        if (_activeMessages.Remove(message))
        {
            OnMessageRemoved?.Invoke(message);
        }
    }

    public void Clear()
    {
        _activeMessages.Clear();
        OnCleared?.Invoke();
    }
}
