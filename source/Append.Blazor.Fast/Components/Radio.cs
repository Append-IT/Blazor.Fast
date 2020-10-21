using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// An implementation of a <see cref="Radio"/> button as a form-connected web-component. Facilitating single select from a group of visible choices.
    /// </summary>
    public class Radio : FastInputComponent<bool>
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-radio");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "checked", BindConverter.FormatValue(CurrentValue));
            builder.AddAttribute(3, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage)
            => throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
    }
}
