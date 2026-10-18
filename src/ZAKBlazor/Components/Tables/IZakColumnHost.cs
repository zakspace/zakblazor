namespace ZAKBlazor;

/// <summary>
/// Host interface implemented by tabular components that accept ZakTableColumn children.
/// </summary>
/// <typeparam name="TItem">The data row type.</typeparam>
public interface IZakColumnHost<TItem>
{
    void RegisterColumn(ZakTableColumn<TItem> column);
    void UnregisterColumn(ZakTableColumn<TItem> column);
}
