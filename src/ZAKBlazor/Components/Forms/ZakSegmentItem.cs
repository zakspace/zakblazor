namespace ZAKBlazor;

/// <summary>
/// Represents an individual item in a <see cref="ZakSegmentedControl{TValue}"/>.
/// </summary>
public record ZakSegmentItem<TValue>(TValue Value, string Label, string? Icon = null, bool Disabled = false);
