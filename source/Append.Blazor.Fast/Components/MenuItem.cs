using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// The <see cref="MenuItem"/> should always be placed inside a <see cref="Menu"/>.
    /// </summary>
    public class MenuItem : FastComponent
    {
        [CascadingParameter] public Menu? Menu { get; set; }
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-menu-item");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
