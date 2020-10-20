using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Append.Blazor.Fast.Core
{
    public abstract class FastComponent : ComponentBase
    {
        [CascadingParameter] protected ThemeProvider? ThemeProvider { get; set; }
        protected string? ThemeName => ThemeProvider?.ThemeName;

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}
