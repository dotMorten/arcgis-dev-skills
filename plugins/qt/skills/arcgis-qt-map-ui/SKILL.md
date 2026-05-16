---
name: arcgis-qt-map-ui
description: Build or refine ArcGIS Maps SDK for Qt map UI. Use for Qt Quick/QML or Widgets map experiences such as MapView, SceneView, identify, callouts, overlays, viewpoint logic, and toolkit controls.
license: MIT
---

Use this skill when the task centers on **map experience behavior** in a Qt app using ArcGIS Maps SDK for Qt.

## Focus areas

- Qt Quick/QML map screens
- Qt Widgets map screens
- `MapView` and `SceneView`
- operational layers and basemap setup
- identify workflows and feature selection
- callouts, popup-like UI, and overlay behavior
- viewpoint and navigation behavior
- toolkit components such as callout, basemap gallery, popup view, search, scale bar, floor filter, or north arrow

## Default approach

1. Find the current map screen, state owner, and lifecycle boundary.
2. Preserve the current UI model:
   - QML-first app with C++ backing types
   - QWidget-based app
   - mixed QML and C++ architecture
3. Keep short-lived interaction logic near the UI layer.
4. Move reusable state, queries, and domain logic into controllers, models, or backing objects that match the repo's conventions.
5. Prefer small, composable changes over replacing the whole screen.

## Design guidance

- Prefer official ArcGIS APIs and toolkit controls over custom wrappers when they solve the problem cleanly.
- Make layer loading and failure states explicit.
- For identify and selection flows, surface:
  - whether a result was found
  - which layer or graphic produced it
  - what the UI should do when nothing is hit
- Clean up signal connections, temporary objects, and interaction state when views are destroyed or recreated.

## Qt Quick guidance

Reference `qt-ui-patterns.md`.

- Keep UI state and GIS state understandable and separate.
- Avoid putting too much domain logic directly in QML files.
- Prefer clean boundaries between QML presentation and C++ backing logic when the repo already uses that style.

## Widgets guidance

- Respect the current controller and widget hierarchy.
- Keep ArcGIS view lifecycle work aligned with the widget lifecycle already used in the repo.
- Avoid hiding view-only logic in service layers.

## Example requests

- "Add identify on click and show a callout."
- "Add a SceneView to this QML screen."
- "Use toolkit controls instead of our custom basemap picker."
- "Refactor this map screen so state and UI responsibilities are cleaner."
