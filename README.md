# Blazor.Fast
A **tiny** wrapper around [Fast](https://www.fast.design/) and [Fluent](https://github.com/microsoft/fluentui/tree/master/packages/web-components) Web Components to integrate with Blazor.

![Nuget](https://img.shields.io/nuget/v/append.blazor.fast?style=flat-square)

## The blogpost
You can read more about why we did this in [this blog post](https://benjaminvertonghen.medium.com/blazor-fast-webcomponents-4bae55d005ad).

### Documentation and examples
We just have to put the docs online, but there are samples in the documnetation project. 

### Installing

Create a new Blazor Application
`dotnet new blazorwasm -o WebApplication`

You can install from NuGet using the following command:

`Install-Package Append.Blazor.Fast`

### Setup

1. Add the Javascript file to the `_host.cshtml` (server-side) or `index.html` (client-side) page below the Blazor framework script.
```razor
// Provided by default
<script src="_framework/blazor.webassembly.js"></script>
// FAST
<script type="module" src="https://unpkg.com/@microsoft/fast-components"></script>
// Fluent (optional)
<script type="module" src="https://unpkg.com/@fluentui/web-components"></script>
```

2. Add the required namespaces in the `_imports.razor` file
```razor
@using Append.Blazor.Fast.Components
@using Append.Blazor.Fast.Core
```

3. Adjust the `App.razor` file to the following, to provide a highest level ThemeProvider.
```razor
<SystemProvider Theme="new ThemeProvider(ThemeType.Fast)" use-defaults> //Provide a Theme Fluent or Fast
 <Router AppAssembly="@typeof(Program).Assembly">
  <Found Context="routeData">
   <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
  </Found>
  <NotFound>
   <LayoutView Layout="@typeof(MainLayout)">
    <p>Sorry, there is nothing at this address.</p>
   </LayoutView>
  </NotFound>
 </Router>
</SystemProvider>
```
4. Use a component on the `index.razor` page
```razor
<Button appearance="accent">Click Me</Button>
```

### Further reading
- You can find documentation about the the core library [Fast Design by Microsoft](https://www.fast.design/docs/introduction/)
- Examples provided in the core library can be found in the [Component Explorer](https://explore.fast.design/components/fast-accordion)

