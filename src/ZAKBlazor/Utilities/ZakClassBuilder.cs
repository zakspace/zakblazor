using System.Text;

namespace ZAKBlazor.Utilities;

/// <summary>
/// A fluent builder for constructing CSS class attributes conditionally and cleanly.
/// </summary>
public sealed class ZakClassBuilder
{
    private readonly StringBuilder _builder = new();
    private bool _hasClasses;

    public ZakClassBuilder() { }

    public ZakClassBuilder(string? initialClass)
    {
        if (!string.IsNullOrWhiteSpace(initialClass))
        {
            _builder.Append(initialClass.Trim());
            _hasClasses = true;
        }
    }

    public static ZakClassBuilder Create(string? initialClass = null) => new(initialClass);

    /// <summary>
    /// Appends a CSS class if the condition is true and class name is non-empty.
    /// </summary>
    public ZakClassBuilder AddClass(string? className, bool condition = true)
    {
        if (condition && !string.IsNullOrWhiteSpace(className))
        {
            if (_hasClasses)
            {
                _builder.Append(' ');
            }
            _builder.Append(className.Trim());
            _hasClasses = true;
        }
        return this;
    }

    /// <summary>
    /// Evaluates a function and appends the class name if the condition is true.
    /// </summary>
    public ZakClassBuilder AddClass(Func<string?> classNameFunc, bool condition = true)
    {
        if (condition)
        {
            var className = classNameFunc();
            return AddClass(className, true);
        }
        return this;
    }

    /// <summary>
    /// Builds and returns the compiled CSS class string, or null if empty.
    /// </summary>
    public string? Build() => _hasClasses ? _builder.ToString() : null;

    public override string ToString() => Build() ?? string.Empty;
}
