using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// An <see cref="Accordion"/> is a vertically stacked set of interactive headings that each contain a title, content snippet, or thumbnail representing a section of content. 
    /// The headings function as controls that enable users to reveal or hide their associated sections of content.
    /// Accordions are commonly used to reduce the need to scroll when presenting multiple sections of content on a single page.
    /// </summary>
    public class Accordion : FastComponent
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-accordion");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
