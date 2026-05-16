# ArcGIS Maps SDK for .NET platform package matrix

Use the package that matches the app's UI stack.

| UI stack | Typical package |
| --- | --- |
| WPF | `Esri.ArcGISRuntime.WPF` |
| WinUI 3 | `Esri.ArcGISRuntime.WinUI` |
| .NET MAUI | `Esri.ArcGISRuntime.Maui` |

## Supporting guidance

- Keep ArcGIS packages on the same version line.
- If toolkit controls are needed, add the matching toolkit package for the same UI stack.
- For new work, keep the ArcGIS package version aligned with the rest of the solution's target frameworks and supported platforms.
- For upgrades, prefer a single deliberate upgrade across all ArcGIS packages instead of mixing versions.
