using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Append.Blazor.Fast.Core
{
    public abstract class FastInputComponent<T> : InputBase<T>
    {
        [CascadingParameter] protected ThemeProvider? ThemeProvider { get; set; }
        protected string? ThemeName => ThemeProvider?.ThemeName;
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}
