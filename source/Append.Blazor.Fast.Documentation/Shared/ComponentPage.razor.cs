using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Append.Blazor.Fast.Documentation.Shared
{
    public partial class ComponentPage
    {
        private IEnumerable<Type> _examples = new List<Type>();
        [Parameter] public Type Component { get; set; }
        [Parameter] public RenderFragment Information { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            GetAllExamplesForComponent(Component.Name);
        }
        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)
                        && t.BaseType == typeof(ComponentBase))
                      .ToArray();
        }
        private void GetAllExamplesForComponent(string componentName)
        {
            var namespaceOfTheExamples = $"Append.Blazor.Fast.Documentation.Examples.{componentName}";
            _examples = GetTypesInNamespace(Assembly.GetExecutingAssembly(), namespaceOfTheExamples);
        }
        private RenderFragment BuildExample(Type example) => builder =>
        {
            builder.OpenComponent(0, example);
            builder.SetKey(example);
            builder.CloseComponent();
        };
    }
}
