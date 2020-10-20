using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// <see cref="Tabs"/> are a set of layered sections of content that display one panel of content at a time. 
    /// Each tab panel has an associated tab element, that when activated, displays the panel.
    /// The list of tab elements is arranged along one edge of the currently displayed panel.
    /// </summary>
    public class Tabs : FastComponent
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-tabs");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
