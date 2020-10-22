using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// The <see cref="SliderLabel"/> component provides a default styled label to be placed inside a slider component. 
    /// Users can choose to hide the mark as well as provide custom label content.
    /// </summary>
    public class SliderLabel : FastComponent
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-slider-label");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
