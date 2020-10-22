# Blazor.Fast
A **tiny** wrapper around  Web Components to integrate with Blazor.

Blazor.Fast is a component library which wraps the [Fast](https://www.fast.design/) and [Fluent](https://github.com/microsoft/fluentui/tree/master/packages/web-components) web components, with the following design aspects in mind:

1. Keep the same API as the core library, without introducing a bunch of custom parameters or redundant work.
2. If you know how to use FAST in another framework, it doesn’t take a lot of time to learn how to use the (very tiny) Blazor wrapper.
3. The heavy lifting is done in the core FAST or Fluent library.
4. Abstracts away the theme so we can use Fluent and/or FAST by switching a JavaScript import and change the value of a switch.
5. Make it easier for Blazor developers to integrate FAST or Fluent in their projects.

![Nuget](https://img.shields.io/nuget/v/append.blazor.fast?style=flat-square)

## The blogpost
You can read more about why and how we did this in [this blog post](https://benjaminvertonghen.medium.com/blazor-fast-webcomponents-4bae55d005ad).

### Documentation and examples
- The documentation and examples of Blazor.Fast can be found [here](https://tinyurl.com/yxjuzolo)
- The official documentation of FAST by Microsoft can be found [here](https://www.fast.design/docs/introduction/)

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
<SystemProvider Theme="new ThemeProvider(ThemeType.Fast)" use-defaults>
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

