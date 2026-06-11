---
name: arcgis-dotnet-solution-setup
description: Set up or upgrade WPF, WinUI 3, or .NET MAUI apps that use ArcGIS Maps SDK for .NET. Use when asked to scaffold a new ArcGIS-enabled .NET app, add the SDK to an existing solution, or create the first working map or scene.
license: MIT
---

Use this skill when the task is about **project setup**, **SDK adoption**, or **first-use integration** for ArcGIS Maps SDK for .NET.

## Grounding with samples

Before creating the first map or scene, search the local sample index when `arcgis-dotnet-search` is available:

```powershell
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- search "display map" --platform wpf
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- search "scene view" --platform maui
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- get <id>
```

Use the matching platform sample as the baseline for namespaces, startup initialization, and `MapView`/`SceneView` setup.

## Goals

1. Confirm the target UI stack before editing: **WPF**, **WinUI 3**, or **.NET MAUI**.
2. Reuse the repository's existing architecture, dependency injection, and MVVM patterns.
3. Add the ArcGIS package that matches the target platform.
4. Produce a minimal but working first map or scene instead of stopping at package installation.
5. Keep API keys, client IDs, and license values out of source control.

## Platform package guidance

Use the matrix in `platform-package-matrix.md`.

Prefer the current repo's ArcGIS package major version if one already exists. For greenfield work, prefer the latest stable ArcGIS Maps SDK for .NET line requested by the user or already established by the solution.

## Environment initialization

Reference `environment-initialization.md`.

When the task includes startup wiring, do not stop at package installation. Cover where ArcGIS environment configuration should live:

- **.NET MAUI**: prefer `builder.UseArcGISRuntime(config => ...)` in `MauiProgram.cs`
- **WPF / WinUI / other non-MAUI .NET apps**: prefer `ArcGISRuntimeEnvironment.Initialize(config => ...)` in the app startup path

Use these startup hooks for configuration such as:

- authentication setup
- HTTP behavior
- app-wide environment settings

If the task also includes sign-in, keep the environment initialization path and the `AuthenticationManager` path discoverable and close together.

## Setup process

1. Identify the app type and target framework.
2. Inspect the solution for existing patterns:
   - app startup and navigation
   - view and view model structure
   - configuration sources such as `appsettings.json`, user secrets, environment variables, or MAUI platform config
3. Add the correct NuGet package and keep versions consistent across ArcGIS packages.
4. Initialize the ArcGIS environment in the correct startup hook for the target app type.
5. Create the smallest end-to-end integration that proves the SDK is wired correctly:
   - `MapView` or `SceneView`
   - a map or scene instance
   - a sensible basemap
   - initial viewpoint if needed
6. If credentials are required, route them through the app's normal configuration system.
7. If the repository uses MVVM, keep view-specific interactions in the view layer and move application state to view models or services.

## Behavioral rules

- If the target platform is not stated and cannot be inferred, ask for it.
- Do not hardcode secrets, API keys, OAuth client IDs with secrets, or license strings into checked-in files.
- Do not invent a custom GIS abstraction layer unless the repository already uses one.
- Prefer incremental integration over large rewrites.
- When toolkit controls solve the UI problem cleanly, mention or use them instead of building custom controls from scratch.

## Common deliverables

- add ArcGIS packages to a `.csproj`
- add `UseArcGISRuntime(config => ...)` in MAUI or `ArcGISRuntimeEnvironment.Initialize(config => ...)` elsewhere
- introduce a first `MapView` or `SceneView`
- wire the map from an existing view model or page model
- migrate from placeholder map content to a real ArcGIS basemap
- upgrade package versions consistently across app and toolkit packages

## Example requests

- "Add ArcGIS Maps SDK for .NET to this WinUI app."
- "Create a MAUI sample page with a working map."
- "Upgrade this WPF app from an older ArcGIS package line."
- "Scaffold the first SceneView in this solution."
