using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Diagnostics.CodeAnalysis;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// An implementation of a generic input for textual values as a form-connected web-component.
    /// @bind-value:event="oninput" is currently not possible due to: https://github.com/dotnet/aspnetcore/issues/11960
    /// </summary>
    public class TextField : FastInputComponent<string>
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-text-field");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(3, "class", CssClass);
            builder.AddAttribute(4, "value", BindConverter.FormatValue(CurrentValue));
            builder.AddAttribute(5, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddContent(6, ChildContent);
            builder.CloseElement();
        }
        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
