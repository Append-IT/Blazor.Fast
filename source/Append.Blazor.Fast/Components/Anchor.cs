using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// The <see cref="Anchor"/> component represent an control that should invoke an action or perform a navigation.
    /// </summary>
    public class Anchor : FastComponent
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-anchor");
            builder.AddAttribute(1, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, Navigate));
            builder.AddEventPreventDefaultAttribute(2, "onclick", true);
            builder.AddMultipleAttributes(3, AdditionalAttributes);
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
        private void Navigate()
        {
            if (AdditionalAttributes is null)
                return;

            if (!AdditionalAttributes!.TryGetValue("href", out var href))
                return;

            NavigationManager.NavigateTo(Convert.ToString(href)!);
        }
    }
}
