using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// The <see cref="Badge"/> component is used to highlight an item and attract attention or flag status, such as “New”, “Sale”, or other short phrases or a number to represent unread messages, updates available, etc..
    /// </summary>
    public class Badge : FastComponent
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-badge");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
