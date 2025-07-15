# 🛎️ Maui.AlertService

A reusable .NET MAUI alert popup control using FontAwesome icons and customizable multi-button layouts.

---

## ✅ Features

- Custom title, message, button text
- Support for 1, 2, or 3 buttons
- Enum-based return values: `Cancel`, `Option0`, `Option1`
- Built-in icon types: `Info`, `Warning`, `Error`, `Question`, `Success`
- FontAwesome icon styling
- Optional auto-dismiss (for notifications)
- Minimal dependencies — no Lottie or animations

---

## 🔧 Setup Instructions

### Step 1: Add FontAwesome

Copy the `fa-solid-900.ttf` file into your main app's `Resources/Fonts` folder.

```csharp
// In MauiProgram.cs:
builder.ConfigureFonts(fonts =>
{
    fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolid");
});

## 📘 Full Examples

See the [Examples](./Examples) folder for working code samples:
- `OneButtonExamplePage.xaml`: Simple “OK” dialog
- `TwoButtonExamplePage.xaml`: Yes/No confirmation
- `ThreeButtonExamplePage.xaml`: Cancel / Option A / Option B
