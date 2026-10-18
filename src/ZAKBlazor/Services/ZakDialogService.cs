using Microsoft.AspNetCore.Components;

namespace ZAKBlazor.Services;

/// <summary>
/// Implementation of IZakDialogService managing active dialog references.
/// </summary>
public class ZakDialogService : IZakDialogService
{
    private readonly List<ZakDialogReference> _activeDialogs = new();

    public event Action<ZakDialogReference>? OnDialogOpened;
    public event Action<ZakDialogReference>? OnDialogClosed;

    public IReadOnlyList<ZakDialogReference> ActiveDialogs => _activeDialogs.AsReadOnly();

    public ZakDialogReference Show<TComponent>(string title, ZakDialogParameters? parameters = null, ZakDialogOptions? options = null) where TComponent : IComponent
    {
        var reference = new ZakDialogReference
        {
            Title = title,
            ComponentType = typeof(TComponent),
            Parameters = parameters ?? new ZakDialogParameters(),
            Options = options ?? new ZakDialogOptions()
        };

        _activeDialogs.Add(reference);
        OnDialogOpened?.Invoke(reference);
        return reference;
    }

    public async Task<bool> ConfirmAsync(string message, string title = "Confirm", string confirmText = "Confirm", string cancelText = "Cancel", ZakColor confirmColor = ZakColor.Primary)
    {
        ZakDialogReference? reference = null;
        reference = new ZakDialogReference
        {
            Title = title,
            Options = new ZakDialogOptions { MaxWidth = "460px" },
            CustomContent = builder =>
            {
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "class", "zak-dialog-confirm-body");
                builder.OpenElement(2, "p");
                builder.AddAttribute(3, "class", "zak-dialog-confirm-message");
                builder.AddContent(4, message);
                builder.CloseElement(); // p

                builder.OpenElement(5, "div");
                builder.AddAttribute(6, "class", "zak-dialog-actions");

                // Cancel Button
                builder.OpenComponent<ZakButton>(7);
                builder.AddAttribute(8, "Variant", ZakVariant.Text);
                builder.AddAttribute(9, "Color", ZakColor.Default);
                builder.AddAttribute(10, "OnClick", EventCallback.Factory.Create(this, () => Close(reference!, false)));
                builder.AddAttribute(11, "ChildContent", (RenderFragment)(b => b.AddContent(12, cancelText)));
                builder.CloseComponent();

                // Confirm Button
                builder.OpenComponent<ZakButton>(13);
                builder.AddAttribute(14, "Variant", ZakVariant.Filled);
                builder.AddAttribute(15, "Color", confirmColor);
                builder.AddAttribute(16, "OnClick", EventCallback.Factory.Create(this, () => Close(reference!, true)));
                builder.AddAttribute(17, "ChildContent", (RenderFragment)(b => b.AddContent(18, confirmText)));
                builder.CloseComponent();

                builder.CloseElement(); // div.zak-dialog-actions
                builder.CloseElement(); // div.zak-dialog-confirm-body
            }
        };

        _activeDialogs.Add(reference);
        OnDialogOpened?.Invoke(reference);

        var result = await reference.Result;
        return result is true;
    }

    public async Task AlertAsync(string message, string title = "Alert", string buttonText = "OK")
    {
        ZakDialogReference? reference = null;
        reference = new ZakDialogReference
        {
            Title = title,
            Options = new ZakDialogOptions { MaxWidth = "420px" },
            CustomContent = builder =>
            {
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "class", "zak-dialog-confirm-body");
                builder.OpenElement(2, "p");
                builder.AddAttribute(3, "class", "zak-dialog-confirm-message");
                builder.AddContent(4, message);
                builder.CloseElement();

                builder.OpenElement(5, "div");
                builder.AddAttribute(6, "class", "zak-dialog-actions");
                builder.OpenComponent<ZakButton>(7);
                builder.AddAttribute(8, "Variant", ZakVariant.Filled);
                builder.AddAttribute(9, "Color", ZakColor.Primary);
                builder.AddAttribute(10, "OnClick", EventCallback.Factory.Create(this, () => Close(reference!, true)));
                builder.AddAttribute(11, "ChildContent", (RenderFragment)(b => b.AddContent(12, buttonText)));
                builder.CloseComponent();
                builder.CloseElement();
                builder.CloseElement();
            }
        };

        _activeDialogs.Add(reference);
        OnDialogOpened?.Invoke(reference);
        await reference.Result;
    }

    public void Close(ZakDialogReference reference, object? result = null)
    {
        if (_activeDialogs.Remove(reference))
        {
            reference.Dismiss(result);
            OnDialogClosed?.Invoke(reference);
        }
    }
}
