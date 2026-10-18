using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using ZAKBlazor.Utilities;

namespace ZAKBlazor.Primitives;

/// <summary>
/// Dynamic HTML element wrapper that renders the specified semantic HTML tag while passing down
/// attributes, CSS classes, styles, and child content.
/// </summary>
public class ZakElement : ZakComponentBase
{
    /// <summary>
    /// The HTML tag to render (defaults to "div").
    /// </summary>
    [Parameter]
    public string TagName { get; set; } = "div";

    /// <summary>
    /// Child content to render inside the element.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, TagName);
        builder.AddAttribute(1, "id", ElementId);

        var cssClass = CreateClassBuilder().Build();
        if (!string.IsNullOrEmpty(cssClass))
        {
            builder.AddAttribute(2, "class", cssClass);
        }

        var style = CreateStyleBuilder().Build();
        if (!string.IsNullOrEmpty(style))
        {
            builder.AddAttribute(3, "style", style);
        }

        builder.AddMultipleAttributes(4, AdditionalAttributes);
        builder.AddContent(5, ChildContent);
        builder.CloseElement();
    }
}
