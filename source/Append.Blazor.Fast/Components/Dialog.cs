using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// A <see cref="Dialog"/> is a window overlaid on either the primary window or another dialog window. Windows under a modal dialog are inert. 
    /// That is, users cannot interact with content outside an active dialog window. 
    /// Inert content outside an active dialog is typically visually obscured or dimmed so it is difficult to discern, and in some implementations, attempts to interact with the inert content cause the dialog to close.
    /// Like non-modal dialogs, modal dialogs contain their tab sequence.That is, Tab and Shift + Tab do not move focus outside the dialog.However, unlike most non-modal dialogs, modal dialogs do not provide means for moving keyboard focus outside the dialog window without closing the dialog.
    /// </summary>
    public class Dialog : FastComponent
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-dialog");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
