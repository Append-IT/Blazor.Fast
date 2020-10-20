using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// The <see cref="Menu"/> is a widget that offers a list of choices to the user, such as a set of actions or functions. 
    /// While any DOM content is permissible as a child of the menu, only fast-menu-item's and slotted content with a role of menuitem, menuitemcheckbox, or menuitemradio will receive keyboard support.
    /// </summary>
    public class Menu : FastComponent
    {
        
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<CascadingValue<Menu>>(0);
            builder.AddAttribute(1, "Value", this);
            builder.AddAttribute(2, "ChildContent", new RenderFragment(childBuilder =>
            {
                childBuilder.OpenElement(3, $"{ThemeName}-menu");
                childBuilder.AddMultipleAttributes(4, AdditionalAttributes);
                childBuilder.AddContent(5, ChildContent);
                childBuilder.CloseElement();
            }));
            builder.CloseComponent();
        }
    }
}
