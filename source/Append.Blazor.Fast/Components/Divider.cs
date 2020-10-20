using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// The <see cref="Divider"/> is a web component implementation of a horizontal rule.
    /// </summary>
    public class Divider : FastComponent
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-divider");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
