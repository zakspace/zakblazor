# ZAKBlazor

<p align="center">
  <img src="src/ZAKBlazor.Docs/wwwroot/images/logo.png" alt="ZAKBlazor Logo" width="120" />
</p>

<p align="center">
  <strong>Modern, Accessible, and Themeable Blazor UI Component Library</strong>
</p>

<p align="center">
  <a href="#features">Features</a> •
  <a href="#installation">Installation</a> •
  <a href="#quick-start">Quick Start</a> •
  <a href="#theming">Theming</a> •
  <a href="#layout">Layout</a> •
  <a href="#components">Components</a> •
  <a href="#solution-architecture">Architecture</a> •
  <a href="#license">License</a>
</p>

---

## Introduction

**ZAKBlazor** is an open-source-quality Blazor UI component library built for enterprise portals, SaaS dashboards, and modern web applications. Targetting modern .NET (9.0+), ZAKBlazor provides a strongly-typed component architecture, native Blazor state management, WCAG-compliant accessibility, dynamic CSS variable runtime theming (dark & light modes), and minimal JavaScript dependencies.

## Features

- **Coherent Design System**: Powered by CSS custom properties (`--zak-*`), logical properties, and atomic design tokens.
- **Dynamic Theming**: Seamless dark and light mode switching at runtime without page reloads or layout flashes.
- **Enterprise-Ready Layout**: Composable application shell (`ZakLayout`, `ZakAppBar`, `ZakDrawer`, `ZakMainContent`, `ZakContainer`, `ZakStack`, `ZakBox`).
- **WCAG Accessibility**: Full semantic HTML tags, keyboard navigation, focus indicators, and screen reader ARIA bindings built into every interactive element.
- **Zero Third-Party UI Bloat**: Pure Blazor C# components and modular CSS; JavaScript is isolated only to browser capabilities like local storage and clipboard interaction.
- **Documentation Platform**: Full-featured documentation portal (`ZAKBlazor.Docs`) with interactive component previews, copyable code, and API reference tables.
- **Realistic Samples**: Comprehensive enterprise admin dashboard (`ZAKBlazor.Samples`) showing realistic dashboard compositions.

---

## Installation

Install the library into your Blazor project via the .NET CLI:

```bash
dotnet add package ZAKBlazor
```

Or via NuGet Package Manager:

```powershell
Install-Package ZAKBlazor
```

---

## Quick Start

### 1. Register Services

Register ZAKBlazor in your application `Program.cs`:

```csharp
using ZAKBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args); // or WebApplication.CreateBuilder(args);
builder.Services.AddZAKBlazor();

await builder.Build().RunAsync();
```

### 2. Include Assets

Add the CSS and JS references to your host page (`index.html` or `App.razor`):

```html
<!-- ZAKBlazor Core Stylesheet -->
<link rel="stylesheet" href="_content/ZAKBlazor/css/zakblazor.css" />

<!-- ZAKBlazor Minimal JS Interop -->
<script src="_content/ZAKBlazor/js/zakblazor.js"></script>
```

### 3. Add Namespace Imports

Add the following to your root `_Imports.razor`:

```razor
@using ZAKBlazor
@using ZAKBlazor.Primitives
@using ZAKBlazor.Services
@using ZAKBlazor.Utilities
```

### 4. Wrap with Theme Provider

Wrap your application inside `ZakThemeProvider`:

```razor
<!-- App.razor -->
<ZakThemeProvider>
    <Router AppAssembly="@typeof(App).Assembly">
        <Found Context="routeData">
            <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        </Found>
        <NotFound>
            <p>Page not found</p>
        </NotFound>
    </Router>
</ZakThemeProvider>
```

---

## Theming

ZAKBlazor uses CSS variables that update dynamically when dark mode is toggled:

```razor
@inject IZakThemeService ThemeService

<ZakButton Variant="ZakVariant.Filled"
           Color="ZakColor.Primary"
           StartIcon="@(ThemeService.IsDarkMode ? ZakIcons.Sun : ZakIcons.Moon)"
           OnClick="() => ThemeService.ToggleDarkModeAsync()">
    Toggle Theme
</ZakButton>
```

### Custom Palette Overrides

You can pass a custom theme with tailored light and dark palettes:

```csharp
var customTheme = new ZakTheme
{
    PaletteLight = new ZakPaletteLight
    {
        Primary = "#5E43F3",
        Secondary = "#00D2B4",
        Background = "#F8FAFC"
    },
    PaletteDark = new ZakPaletteDark
    {
        Primary = "#7B66FF",
        Secondary = "#00E5C5",
        Background = "#0B0F19",
        Surface = "#131B2E"
    }
};

<ZakThemeProvider Theme="customTheme">
    ...
</ZakThemeProvider>
```

---

## Layout

Assemble an enterprise dashboard shell in seconds:

```razor
<ZakLayout>
    <ZakAppBar Fixed="true">
        <ZakIconButton Icon="@ZakIcons.Menu" OnClick="() => LayoutService.ToggleDrawer()" />
        <ZakText Typo="Typo.h6">Enterprise Portal</ZakText>
    </ZakAppBar>

    <ZakDrawer Width="260px" ClipMode="true">
        <!-- Navigation Menu -->
    </ZakDrawer>

    <ZakMainContent>
        <ZakContainer MaxWidth="ZakBreakpoint.Lg">
            @Body
        </ZakContainer>
    </ZakMainContent>
</ZakLayout>
```

---

## Core Components (Phase 1)

| Component | Description |
|---|---|
| `ZakButton` | Button with variants (Filled, Outlined, Soft, Text), sizes, loading spinner, and icon slots. |
| `ZakIconButton` | Accessible circular/rounded trigger for toolbars, actions, and menus. |
| `ZakIcon` | Scalable SVG icon primitive supporting built-in curated paths (`ZakIcons`). |
| `ZakText` | Semantic typography component supporting 13 typographic scales (`Typo.h1` to `Typo.button`). |
| `ZakLayout` | Root app shell container coordinating responsive drawer and app bar positioning. |
| `ZakAppBar` | Header navigation bar supporting fixed, sticky, and dense presentations. |
| `ZakDrawer` | Collapsible, responsive navigation drawer with automatic mobile overlay backdrop. |
| `ZakMainContent` | Content wrapper that automatically responds to drawer open/close animations. |
| `ZakContainer` | Responsive max-width container (`sm`, `md`, `lg`, `xl`, `fluid`). |
| `ZakStack` | Flexbox row/column layout primitive with customizable gap, alignment, and wrapping. |
| `ZakBox` | Atomic structural wrapper supporting elevations, borders, radiuses, and padding. |
| `ZakDivider` | Horizontal and vertical separator supporting centered text content. |
| `ZakThemeProvider` | Dynamic theme provider emitting CSS custom properties into the DOM. |

---

## Solution Architecture

```text
ZakBlazor/
├── src/
│   ├── ZAKBlazor/              # Core Razor Class Library
│   │   ├── Components/         # Buttons, Typography, Layout, Icons
│   │   ├── Primitives/         # ZakComponentBase, ZakElement
│   │   ├── Theme/              # ZakTheme, ZakPalette, ZakThemeProvider
│   │   ├── Services/           # ThemeService, LayoutService
│   │   ├── Utilities/          # ZakClassBuilder, ZakStyleBuilder, CssExtensions
│   │   ├── Enums/              # ZakColor, ZakVariant, ZakSize, Typo, etc.
│   │   └── wwwroot/            # Modular CSS and minimal JS interop
│   │
│   ├── ZAKBlazor.Docs/         # Documentation Platform (WebAssembly)
│   └── ZAKBlazor.Samples/      # Enterprise Showcase Application
│
├── tests/
│   └── ZAKBlazor.Tests/        # Automated Unit Test Suite (xUnit)
│
├── Directory.Build.props       # Centralized build configuration
├── ZakBlazor.sln              # Solution file
└── README.md
```

---

## Testing

Execute the automated test suite with the .NET CLI:

```bash
dotnet test ZakBlazor.sln
```

---

## License

This project is licensed under the [MIT License](LICENSE).
