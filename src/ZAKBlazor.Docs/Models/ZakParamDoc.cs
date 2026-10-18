namespace ZAKBlazor.Docs;

public class ZakParamDoc
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string? DefaultValue { get; set; }
    public string Description { get; set; }

    public ZakParamDoc(string name, string type, string? defaultValue, string description)
    {
        Name = name;
        Type = type;
        DefaultValue = defaultValue;
        Description = description;
    }
}
