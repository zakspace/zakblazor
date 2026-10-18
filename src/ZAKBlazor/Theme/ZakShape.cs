namespace ZAKBlazor;
 

public class ZakShapeTokens
{
    public string RadiusNone { get; set; } = "0px";
    public string RadiusSm { get; set; } = "6px";
    public string RadiusMd { get; set; } = "10px";
    public string RadiusLg { get; set; } = "16px";
    public string RadiusXl { get; set; } = "24px";
    public string RadiusPill { get; set; } = "9999px";
    public string RadiusCircle { get; set; } = "50%";

    public virtual string ToCssVariables()
    {
        return $@"
        --zak-radius-none: {RadiusNone};
        --zak-radius-sm: {RadiusSm};
        --zak-radius-md: {RadiusMd};
        --zak-radius-lg: {RadiusLg};
        --zak-radius-xl: {RadiusXl};
        --zak-radius-pill: {RadiusPill};
        --zak-radius-circle: {RadiusCircle};";
    }
}
 