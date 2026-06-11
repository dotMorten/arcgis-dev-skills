---
name: arcgis-dotnet-map-ui
description: Build or refine ArcGIS Maps SDK for .NET map UI features. Use for MapView or SceneView work such as layers, graphics overlays, identify, callouts, navigation, viewpoint logic, and MVVM-friendly interaction patterns.
license: MIT
---

Use this skill when the task centers on **map experience behavior** inside an ArcGIS Maps SDK for .NET application.

## Grounding with samples

Before choosing APIs or toolkit controls, search the local sample index when `arcgis-dotnet-search` is available:

```powershell
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- search "<feature>" --platform winui
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- get <id>
```

Search terms that work well include feature nouns and workflows such as `identify popup`, `graphics overlay`, `scene layer`, `basemap gallery`, `legend`, `floor filter`, and `geometry editor`.

## Focus areas

- `MapView` and `SceneView`
- operational layers and basemap composition
- graphics overlays, selection, and highlighting
- identify workflows
- callouts and popup-style interactions
- viewpoint and navigation behavior
- event handling that stays maintainable in MVVM-oriented codebases

## Default approach

1. Find the current map page, control, and view model.
2. Preserve the existing architectural split between UI behavior and domain/application state.
3. Keep ArcGIS-specific view interactions close to the view when they depend on control events or screen coordinates.
4. Move reusable state, commands, and service calls into view models or services.
5. Prefer small, composable changes over replacing the whole map page.

## Design guidance

- Use official ArcGIS controls and APIs directly instead of wrapping everything in custom abstractions.
- Favor toolkit components when they reduce boilerplate cleanly.
- Keep layer loading explicit and observable; do not hide failures.
- For identify and selection flows, surface:
  - what was hit
  - whether the layer was loaded
  - what happens when no result is found
- For callouts and overlays, ensure cleanup on navigation and disposal-sensitive lifecycle events.

## MVVM guidance

- Accept that some map interactions are view-centric.
- Bind persistent UI state, filters, selected model objects, and commands through the view model.
- Avoid pushing raw screen-coordinate logic or direct control manipulation into the view model unless the repo already follows that pattern.

## When implementing features

Reference `mapview-patterns.md`.

Prefer changes like:

- add a new operational layer with explicit load handling
- add tap-to-identify and route the selected result into existing state
- synchronize viewpoint with app navigation only when the UX needs it
- add graphics overlays for temporary analysis or selection feedback
- improve cleanup when pages are recreated or navigated away from

## Example requests

- "Add identify on tap and show a callout."
- "Put the selected feature in the view model and highlight it on the map."
- "Add a SceneView with a 3D layer and initial camera."
- "Refactor this page so map interactions are MVVM-friendly."
