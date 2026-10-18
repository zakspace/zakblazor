namespace ZAKBlazor;
 

public class ZakElevationTokens
{
    public string Shadow0 { get; set; } = "none";
    public string Shadow1 { get; set; } = "0 1px 2px 0 rgba(0, 0, 0, 0.05)";
    public string Shadow2 { get; set; } = "0 1px 3px 0 rgba(0, 0, 0, 0.08), 0 1px 2px -1px rgba(0, 0, 0, 0.08)";
    public string Shadow3 { get; set; } = "0 4px 6px -1px rgba(0, 0, 0, 0.08), 0 2px 4px -2px rgba(0, 0, 0, 0.06)";
    public string Shadow4 { get; set; } = "0 10px 15px -3px rgba(0, 0, 0, 0.08), 0 4px 6px -4px rgba(0, 0, 0, 0.05)";
    public string Shadow5 { get; set; } = "0 10px 20px -3px rgba(0, 0, 0, 0.09), 0 4px 6px -4px rgba(0, 0, 0, 0.05)";
    public string Shadow6 { get; set; } = "0 12px 20px -4px rgba(0, 0, 0, 0.10), 0 4px 6px -2px rgba(0, 0, 0, 0.05)";
    public string Shadow8 { get; set; } = "0 16px 24px -4px rgba(0, 0, 0, 0.10), 0 8px 10px -6px rgba(0, 0, 0, 0.05)";
    public string Shadow12 { get; set; } = "0 20px 25px -5px rgba(0, 0, 0, 0.12), 0 8px 10px -6px rgba(0, 0, 0, 0.06)";
    public string Shadow16 { get; set; } = "0 25px 30px -5px rgba(0, 0, 0, 0.15), 0 10px 12px -6px rgba(0, 0, 0, 0.08)";
    public string Shadow24 { get; set; } = "0 25px 50px -12px rgba(0, 0, 0, 0.22)";

    public virtual string ToCssVariables()
    {
        return $@"
        --zak-shadow-0: {Shadow0};
        --zak-shadow-1: {Shadow1};
        --zak-shadow-2: {Shadow2};
        --zak-shadow-3: {Shadow3};
        --zak-shadow-4: {Shadow4};
        --zak-shadow-5: {Shadow5};
        --zak-shadow-6: {Shadow6};
        --zak-shadow-8: {Shadow8};
        --zak-shadow-12: {Shadow12};
        --zak-shadow-16: {Shadow16};
        --zak-shadow-24: {Shadow24};";
    }
}
 