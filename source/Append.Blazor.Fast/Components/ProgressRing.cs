using Append.Blazor.Fast.Core;
using Microsoft.AspNetCore.Components.Rendering;

namespace Append.Blazor.Fast.Components
{
    /// <summary>
    /// <see cref="Progress"/> components are used to indicate the length of time a process will take.
    /// This may either be as a determinate state in which the progress is a percentage of the total time needed to complete the task or as an indeterminate state where the wait time is unspecified.
    /// For <see cref="Progress"/> components which have a linear visual appearance, use <see cref="Progress"/>.
    /// For progress implementations which are circular, use <seealso cref="ProgressRing"/>.
    /// </summary>
    public class ProgressRing : FastComponent
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"{ThemeName}-progress-ring");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
