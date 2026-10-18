namespace ZAKBlazor.Services;

/// <summary>
/// Service managing global application shell layout states such as responsive drawer toggling.
/// </summary>
public interface IZakLayoutService
{
    event Action? OnLayoutChanged;

    bool IsDrawerOpen { get; }

    void ToggleDrawer();
    void SetDrawerOpen(bool isOpen);
}
