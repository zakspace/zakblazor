namespace ZAKBlazor;

public class ZakZIndexTokens
{
    public int Drawer { get; set; } = 1100;
    public int AppBar { get; set; } = 1200;
    public int ModalBackdrop { get; set; } = 1300;
    public int Modal { get; set; } = 1400;
    public int Popover { get; set; } = 1500;
    public int Tooltip { get; set; } = 1600;
    public int Snackbar { get; set; } = 1700;

    public virtual string ToCssVariables()
    {
        return $@"
        --zak-z-drawer: {Drawer};
        --zak-z-appbar: {AppBar};
        --zak-z-backdrop: {ModalBackdrop};
        --zak-z-modal: {Modal};
        --zak-z-popover: {Popover};
        --zak-z-tooltip: {Tooltip};
        --zak-z-snackbar: {Snackbar};";
    }
}
