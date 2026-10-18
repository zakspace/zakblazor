namespace ZAKBlazor;

/// <summary>
/// Defines depth and shadow elevations from 0 (flat) to 24 (maximum float).
/// </summary>
public enum ZakElevation
{
    Elevation0 = 0,
    Elevation1 = 1,
    Elevation2 = 2,
    Elevation3 = 3,
    Elevation4 = 4,
    Elevation5 = 5,
    Elevation6 = 6,
    Elevation8 = 8,
    Elevation12 = 12,
    Elevation16 = 16,
    Elevation24 = 24
}

/// <summary>
/// Defines standard responsive breakpoints.
/// </summary>
public enum ZakBreakpoint
{
    None,
    Xs,
    Sm,
    Md,
    Lg,
    Xl,
    Xxl
}
