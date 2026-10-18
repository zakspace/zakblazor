using Microsoft.AspNetCore.Components;

namespace ZAKBlazor.Services;

/// <summary>
/// Service for displaying programmatic modal dialogs.
/// </summary>
public interface IZakDialogService
{
    /// <summary>
    /// Event fired when a dialog is opened.
    /// </summary>
    event Action<ZakDialogReference>? OnDialogOpened;

    /// <summary>
    /// Event fired when a dialog is closed.
    /// </summary>
    event Action<ZakDialogReference>? OnDialogClosed;

    /// <summary>
    /// Opens a custom component as a modal dialog.
    /// </summary>
    ZakDialogReference Show<TComponent>(string title, ZakDialogParameters? parameters = null, ZakDialogOptions? options = null) where TComponent : IComponent;

    /// <summary>
    /// Displays a standard confirmation modal dialog with Yes/No or Ok/Cancel actions.
    /// </summary>
    Task<bool> ConfirmAsync(string message, string title = "Confirm", string confirmText = "Confirm", string cancelText = "Cancel", ZakColor confirmColor = ZakColor.Primary);

    /// <summary>
    /// Displays an informational alert modal dialog.
    /// </summary>
    Task AlertAsync(string message, string title = "Alert", string buttonText = "OK");

    /// <summary>
    /// Closes an active dialog reference.
    /// </summary>
    void Close(ZakDialogReference reference, object? result = null);
}
