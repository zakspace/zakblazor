namespace ZAKBlazor;

public class ZakSpacingTokens
{
    public string Spacing0 { get; set; } = "0px";
    public string Spacing1 { get; set; } = "4px";
    public string Spacing2 { get; set; } = "8px";
    public string Spacing3 { get; set; } = "12px";
    public string Spacing4 { get; set; } = "16px";
    public string Spacing5 { get; set; } = "20px";
    public string Spacing6 { get; set; } = "24px";
    public string Spacing8 { get; set; } = "32px";
    public string Spacing10 { get; set; } = "40px";
    public string Spacing12 { get; set; } = "48px";
    public string Spacing16 { get; set; } = "64px";

    public virtual string ToCssVariables()
    {
        return $@"
        --zak-spacing-0: {Spacing0};
        --zak-spacing-1: {Spacing1};
        --zak-spacing-2: {Spacing2};
        --zak-spacing-3: {Spacing3};
        --zak-spacing-4: {Spacing4};
        --zak-spacing-5: {Spacing5};
        --zak-spacing-6: {Spacing6};
        --zak-spacing-8: {Spacing8};
        --zak-spacing-10: {Spacing10};
        --zak-spacing-12: {Spacing12};
        --zak-spacing-16: {Spacing16};";
    }
} 
