using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// An implementation of a checkbox as a form-connected web-component.
    /// </summary>
    public class Switch : FastInputComponent<bool>
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-switch");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "role", "checkbox");
            builder.AddAttribute(3, "checked", BindConverter.FormatValue(CurrentValue));
            builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            Console.WriteLine(CurrentValue);
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage)
            => throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
    }
}
