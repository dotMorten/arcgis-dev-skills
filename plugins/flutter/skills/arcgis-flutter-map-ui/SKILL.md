---
name: arcgis-flutter-map-ui
description: Build or refine ArcGIS Maps SDK for Flutter map UI. Use for Flutter map and scene widgets such as identify, overlays, popup flows, viewpoint logic, and toolkit widgets.
license: MIT
---

Use this skill when the task centers on **map experience behavior** in a Flutter app using ArcGIS Maps SDK for Flutter.

## Focus areas

- `ArcGISMapView` and scene views
- basemap and operational layer setup
- identify workflows and feature selection
- overlays, popup-like presentation, and sheet or panel UX
- viewpoint and navigation behavior
- toolkit widgets such as authenticator, compass, overview map, popup view, or building explorer

## Default approach

1. Find the current map screen, state owner, and lifecycle boundary.
2. Preserve the current UI model:
   - stateful widget
   - provider/bloc/riverpod style state management
   - feature-first screen architecture
3. Keep short-lived interaction logic near the screen layer.
4. Move reusable state, queries, and domain logic into controllers, notifiers, or services that match the repo's conventions.
5. Prefer small, composable changes over replacing the whole screen.

## Design guidance

- Prefer official ArcGIS APIs and toolkit widgets over custom wrappers when they solve the problem cleanly.
- Make layer loading and failure states explicit.
- For identify and selection flows, surface:
  - whether a result was found
  - which layer or graphic produced it
  - what the UI should do when nothing is hit
- Clean up controllers, listeners, and temporary map state when widgets are disposed.

## Flutter guidance

Reference `flutter-ui-patterns.md`.

- Keep map interaction state and app state understandable and separate.
- Avoid overloading a single widget with fetch, auth, map, and navigation logic at the same time.
- Use the repository's existing state-management approach rather than mixing styles unnecessarily.

## Example requests

- "Add identify on tap and show the result in a bottom sheet."
- "Add a scene view to this Flutter screen."
- "Use toolkit widgets instead of our custom compass."
- "Refactor this map screen so state and UI responsibilities are cleaner."
