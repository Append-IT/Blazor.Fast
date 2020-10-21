using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// An implementation of a range slider as a form-connected web-component. 
    /// Note that if the slider is in vertical orientation by default the component will get a height using the css var --fast-slider-height, by default that equates to (10px * var(--thumb-size)) or 160px. 
    /// Inline style will override that height.
    /// </summary>
    public class Slider<TValue> : FastInputComponent<TValue>
    {
        private static string _defaultOrientation = "horizontal";
        private readonly static string _stepAttributeValue; // Null by default, so only allows whole numbers as per HTML spec

        static Slider()
        {
            // Unwrap Nullable<T>, because InputBase already deals with the Nullable aspect
            // of it for us. We will only get asked to parse the T for nonempty inputs.
            var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
            if (targetType == typeof(int) ||
                targetType == typeof(long) ||
                targetType == typeof(short) ||
                targetType == typeof(float) ||
                targetType == typeof(double) ||
                targetType == typeof(decimal))
            {
                _stepAttributeValue = "any";
            }
            else
            {
                throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
            }
        }

        /// <summary>
        /// Gets or sets the error message used when displaying an a parsing error.
        /// </summary>
        [Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must be a number.";

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-slider");
            builder.AddAttribute(1, "step", _stepAttributeValue);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", SliderCssClass);
            builder.AddAttribute(4, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(5, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddContent(6, ChildContent);
            builder.CloseElement();
        }

        /// <summary>
        /// Gets a CSS class string that combines the <c>class</c> attribute and <see cref="FieldClass"/>
        /// properties. Derived components should typically use this value for the primary HTML element's
        /// 'class' attribute.
        /// </summary>
        protected string SliderCssClass
        {
            get
            {
                var orientation = _defaultOrientation;
                if (AdditionalAttributes != null && AdditionalAttributes.TryGetValue("orientation", out var customDirection))
                {
                    orientation = Convert.ToString(customDirection, CultureInfo.InvariantCulture);
                }
                if (AdditionalAttributes != null && AdditionalAttributes.TryGetValue("class", out var @class) &&
                    !string.IsNullOrEmpty(Convert.ToString(@class, CultureInfo.InvariantCulture)))
                {
                    return $"{@class} {orientation} {SliderFieldClass}";
                }

                return $"{orientation} {SliderFieldClass}"; // Never null or empty
            }
        }

        /// <summary>
        /// Gets a string that indicates the status of the field being edited. This will include
        /// some combination of "modified", "valid", or "invalid", depending on the status of the field.
        /// </summary>
        private string SliderFieldClass => EditContext.FieldCssClass(FieldIdentifier);

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.InvariantCulture, out result))
            {
                validationErrorMessage = null;
                return true;
            }
            else
            {
                validationErrorMessage = string.Format(CultureInfo.InvariantCulture, ParsingErrorMessage, DisplayName ?? FieldIdentifier.FieldName);
                return false;
            }
        }

        /// <summary>
        /// Formats the value as a string. Derived classes can override this to determine the formatting used for <c>CurrentValueAsString</c>.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>A string representation of the value.</returns>
        protected override string? FormatValueAsString(TValue? value)
        {
            // Avoiding a cast to IFormattable to avoid boxing.
            switch (value)
            {
                case null:
                    return null;

                case int @int:
                    return BindConverter.FormatValue(@int, CultureInfo.InvariantCulture);

                case long @long:
                    return BindConverter.FormatValue(@long, CultureInfo.InvariantCulture);

                case short @short:
                    return BindConverter.FormatValue(@short, CultureInfo.InvariantCulture);

                case float @float:
                    return BindConverter.FormatValue(@float, CultureInfo.InvariantCulture);

                case double @double:
                    return BindConverter.FormatValue(@double, CultureInfo.InvariantCulture);

                case decimal @decimal:
                    return BindConverter.FormatValue(@decimal, CultureInfo.InvariantCulture);

                default:
                    throw new InvalidOperationException($"Unsupported type {value.GetType()}");
            }
        }
    }
}
