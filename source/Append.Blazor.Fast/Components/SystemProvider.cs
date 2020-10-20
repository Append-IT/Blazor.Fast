using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;

namespace Append.Blazor.Fast.Components
{
    public class SystemProvider : ComponentBase
    {
        [Parameter] public ThemeProvider Theme { get; set; } = new ThemeProvider();
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<CascadingValue<ThemeProvider>>(0);
            builder.AddAttribute(1, "Value", Theme);
            builder.AddAttribute(2, "ChildContent", new RenderFragment(childBuilder =>
            {
                childBuilder.OpenElement(2, $"{Theme.ThemeName}-design-system-provider");
                childBuilder.AddMultipleAttributes(3, AdditionalAttributes);
                childBuilder.AddContent(4, ChildContent);
                childBuilder.CloseElement();
            }));
            builder.CloseComponent();
        }
    }
}
