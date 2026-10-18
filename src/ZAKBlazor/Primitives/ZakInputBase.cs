using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ZAKBlazor.Primitives;

/// <summary>
/// Abstract base class for all two-way data-bound form controls in ZAKBlazor.
/// Provides seamless integration with Blazor's EditContext, DataAnnotationsValidator,
/// error state reflection, and standard input parameters.
/// </summary>
/// <typeparam name="TValue">The type of the bound value.</typeparam>
public abstract class ZakInputBase<TValue> : ZakComponentBase
{
    private FieldIdentifier _fieldIdentifier;
    private bool _hasSubscribedToEditContext;

    [CascadingParameter]
    protected EditContext? CascadedEditContext { get; set; }

    [CascadingParameter]
    protected ZakFormFieldVariant? CascadedFormFieldVariant { get; set; }

    /// <summary>
    /// The current value of the form control.
    /// </summary>
    [Parameter]
    public TValue? Value { get; set; }

    /// <summary>
    /// Event fired when the value changes, supporting two-way binding (@bind-Value).
    /// </summary>
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// An expression that identifies the bound value for EditContext validation.
    /// </summary>
    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; }

    /// <summary>
    /// Visual label text displayed above or associated with the input control.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// Helper or hint text rendered below the input control.
    /// </summary>
    [Parameter]
    public string? HelperText { get; set; }

    /// <summary>
    /// Explicit error text override. If set, forces the control into an error state.
    /// </summary>
    [Parameter]
    public string? ErrorText { get; set; }

    /// <summary>
    /// Placeholder text shown when the input has no value.
    /// </summary>
    [Parameter]
    public string? Placeholder { get; set; }

    /// <summary>
    /// If true, prevents user input and applies disabled styling.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// If true, the value cannot be modified by user typing.
    /// </summary>
    [Parameter]
    public bool ReadOnly { get; set; }

    /// <summary>
    /// If true, marks the field as required and indicates requirement in UI.
    /// </summary>
    [Parameter]
    public bool Required { get; set; }

    /// <summary>
    /// The sizing tier of the input: Small, Medium, or Large.
    /// </summary>
    [Parameter]
    public ZakSize Size { get; set; } = ZakSize.Medium;

    private ZakVariant? _explicitVariant;

#pragma warning disable BL0007
    /// <summary>
    /// Visual presentation variant: Outlined, Filled, Underline, or Ghost.
    /// Inherits the parent <see cref="ZakFormField"/> variant when inside one, or defaults to <see cref="ZakVariant.Outlined"/>.
    /// </summary>
    [Parameter]
    public ZakVariant Variant
    {
        get
        {
            if (_explicitVariant.HasValue)
            {
                return _explicitVariant.Value;
            }

            if (CascadedFormFieldVariant.HasValue)
            {
                return CascadedFormFieldVariant.Value switch
                {
                    ZakFormFieldVariant.Filled => ZakVariant.Filled,
                    ZakFormFieldVariant.Outlined => ZakVariant.Outlined,
                    ZakFormFieldVariant.Underline => ZakVariant.Underline,
                    ZakFormFieldVariant.Ghost => ZakVariant.Ghost,
                    _ => ZakVariant.Outlined
                };
            }

            return ZakVariant.Outlined;
        }
        set => _explicitVariant = value;
    }
#pragma warning restore BL0007

    /// <summary>
    /// Accent color applied when the input is active or focused.
    /// </summary>
    [Parameter]
    public ZakColor Color { get; set; } = ZakColor.Primary;

    /// <summary>
    /// Field identifier used for EditContext validation tracking.
    /// </summary>
    protected FieldIdentifier FieldIdentifier => _fieldIdentifier;

    /// <summary>
    /// Returns true if the control has explicit error text or active validation errors in EditContext.
    /// </summary>
    protected virtual bool HasError =>
        !string.IsNullOrEmpty(ErrorText) ||
        (CascadedEditContext != null && !string.IsNullOrEmpty(_fieldIdentifier.FieldName) && CascadedEditContext.GetValidationMessages(_fieldIdentifier).Any());

    /// <summary>
    /// Resolves the validation error message to display.
    /// </summary>
    protected virtual string? ValidationErrorMessage =>
        ErrorText ?? (CascadedEditContext != null && !string.IsNullOrEmpty(_fieldIdentifier.FieldName)
            ? CascadedEditContext.GetValidationMessages(_fieldIdentifier).FirstOrDefault()
            : null);

    public override Task SetParametersAsync(ParameterView parameters)
    {
        var editContextChanged = parameters.TryGetValue<EditContext>(nameof(CascadedEditContext), out var newEditContext) &&
                                 newEditContext != CascadedEditContext;

        var valueExpressionChanged = parameters.TryGetValue<Expression<Func<TValue>>>(nameof(ValueExpression), out var newExpression) &&
                                     newExpression != ValueExpression;

        var result = base.SetParametersAsync(parameters);

        if (valueExpressionChanged && ValueExpression != null)
        {
            _fieldIdentifier = FieldIdentifier.Create(ValueExpression);
        }

        if (editContextChanged && CascadedEditContext != null && !_hasSubscribedToEditContext)
        {
            CascadedEditContext.OnValidationStateChanged += HandleValidationStateChanged;
            _hasSubscribedToEditContext = true;
        }

        return result;
    }

    /// <summary>
    /// Updates the bound value, notifies ValueChanged, and informs EditContext.
    /// </summary>
    protected async Task SetCurrentValueAsync(TValue? value)
    {
        if (!EqualityComparer<TValue>.Default.Equals(Value, value))
        {
            Value = value;
            await ValueChanged.InvokeAsync(value);

            if (CascadedEditContext != null && !string.IsNullOrEmpty(_fieldIdentifier.FieldName))
            {
                CascadedEditContext.NotifyFieldChanged(_fieldIdentifier);
            }
        }
    }

    private void HandleValidationStateChanged(object? sender, ValidationStateChangedEventArgs e)
    {
        StateHasChanged();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && _hasSubscribedToEditContext && CascadedEditContext != null)
        {
            CascadedEditContext.OnValidationStateChanged -= HandleValidationStateChanged;
            _hasSubscribedToEditContext = false;
        }
        base.Dispose(disposing);
    }
}
