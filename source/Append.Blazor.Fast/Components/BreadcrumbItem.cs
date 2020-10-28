using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// The <see cref="BreadcrumbItem"/>is placed inside the <seealso cref="Breadcrumb"/> component.
    /// It provides a slot with a default anchor. The component also provides a slot for a separator that defaults using a /.
    /// </summary>
    public class BreadcrumbItem : FastComponent
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-breadcrumb-item");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
