---
name: arcgis-js-map-ui
description: Build or refine map UI with ArcGIS Maps SDK for JavaScript. Use for MapView, SceneView, map components, layers, popups, identify, widgets, and interaction-driven web mapping UX.
license: MIT
---

Use this skill when the task is about **map UI**, **interaction design**, or **view-level GIS behavior** in a JavaScript or TypeScript web app.

## Primary objectives

1. Preserve the repository's current UI framework and state-management patterns.
2. Prefer ArcGIS map components, widgets, and view APIs over custom reimplementation.
3. Keep map interactions responsive and discoverable.
4. Make identify, selection, popup, and viewpoint flows easy to follow in code.

## UI guidance

Reference `js-ui-patterns.md`.

Default choices:

- Prefer `arcgis-map` or `MapView` for 2D experiences.
- Prefer `arcgis-scene` or `SceneView` for 3D experiences.
- Use existing ArcGIS widgets or components for common map controls before building custom ones.
- Use Calcite components when the surrounding app already uses them or when they fit the requested UX cleanly.

## Implementation rules

- Keep map creation and map-view wiring close together unless the repo already centralizes that logic.
- Avoid burying all ArcGIS state behind unnecessary wrapper abstractions.
- For framework apps, integrate with the framework's lifecycle correctly so the view is created and destroyed predictably.
- When adding identify or popup logic, make the async flow explicit and keep loading, empty, and error states understandable.
- Prefer layer-specific configuration and popup templates over one-off DOM manipulation.

## What to produce

- map or scene setup wired into the existing UI
- identify, popup, selection, or overlay behavior
- widget and component integration that matches the app's architecture
- concise structural guidance when map state crosses component boundaries

## Example requests

- "Add identify-on-click and show a popup with selected feature details."
- "Refactor this page to use arcgis-map and Calcite panel layout."
- "Add a sketch or layer-list experience without rewriting the whole page."
- "Move this map setup into a reusable React component."
