using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// The <see cref="Tooltip"/> component is used provide extra information about another element when it is hovered.
    /// </summary>
    public class Tooltip : FastComponent
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-tooltip");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
