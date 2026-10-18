using System.Text;

namespace ZAKBlazor.Utilities;

/// <summary>
/// A fluent builder for constructing inline CSS styles safely and cleanly.
/// </summary>
public sealed class ZakStyleBuilder
{
    private readonly StringBuilder _builder = new();
    private bool _hasStyles;

    public ZakStyleBuilder() { }

    public ZakStyleBuilder(string? initialStyle)
    {
        if (!string.IsNullOrWhiteSpace(initialStyle))
        {
            var trimmed = initialStyle.Trim();
            _builder.Append(trimmed);
            if (!trimmed.EndsWith(';'))
            {
                _builder.Append(';');
            }
            _hasStyles = true;
        }
    }

    public static ZakStyleBuilder Create(string? initialStyle = null) => new(initialStyle);

    /// <summary>
    /// Adds a CSS property and value if value is non-empty and condition is true.
    /// </summary>
    public ZakStyleBuilder AddStyle(string property, string? value, bool condition = true)
    {
        if (condition && !string.IsNullOrWhiteSpace(value))
        {
            if (_hasStyles)
            {
                _builder.Append(' ');
            }
            _builder.Append(property.Trim());
            _builder.Append(": ");
            _builder.Append(value.Trim());
            _builder.Append(';');
            _hasStyles = true;
        }
        return this;
    }

    /// <summary>
    /// Adds a raw style snippet if condition is true.
    /// </summary>
    public ZakStyleBuilder AddRaw(string? rawStyle, bool condition = true)
    {
        if (condition && !string.IsNullOrWhiteSpace(rawStyle))
        {
            if (_hasStyles)
            {
                _builder.Append(' ');
            }
            var trimmed = rawStyle.Trim();
            _builder.Append(trimmed);
            if (!trimmed.EndsWith(';'))
            {
                _builder.Append(';');
            }
            _hasStyles = true;
        }
        return this;
    }

    /// <summary>
    /// Builds and returns the compiled CSS style string, or null if empty.
    /// </summary>
    public string? Build() => _hasStyles ? _builder.ToString() : null;

    public override string ToString() => Build() ?? string.Empty;
}
