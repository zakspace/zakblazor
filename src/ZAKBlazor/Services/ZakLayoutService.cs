namespace ZAKBlazor.Services;

public class ZakLayoutService : IZakLayoutService
{
    public event Action? OnLayoutChanged;

    public bool IsDrawerOpen { get; private set; } = true;

    public void ToggleDrawer()
    {
        IsDrawerOpen = !IsDrawerOpen;
        OnLayoutChanged?.Invoke();
    }

    public void SetDrawerOpen(bool isOpen)
    {
        if (IsDrawerOpen == isOpen) return;
        IsDrawerOpen = isOpen;
        OnLayoutChanged?.Invoke();
    }
}
