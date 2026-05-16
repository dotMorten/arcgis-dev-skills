---
name: arcgis-kotlin-map-ui
description: Build or refine ArcGIS Maps SDK for Kotlin map UI. Use for Compose-based MapView or SceneView work such as identify, overlays, callouts, viewpoint logic, and toolkit components.
license: MIT
---

Use this skill when the task centers on **map experience behavior** in an Android app using ArcGIS Maps SDK for Kotlin.

## Focus areas

- Jetpack Compose map screens
- `MapView`, `SceneView`, and `LocalSceneView`
- operational layers and basemap setup
- identify workflows and feature selection
- overlays, popup-like presentation, and bottom-sheet style UI
- viewpoint and navigation behavior
- toolkit components such as compass, popup, offline map areas, basemap gallery, or auth UI

## Default approach

1. Find the current map screen, state owner, and lifecycle boundary.
2. Preserve the current UI model:
   - Compose with `ViewModel`
   - Compose with unidirectional state flow
   - mixed Android view and Compose architecture
3. Keep short-lived interaction logic near the screen layer.
4. Move reusable state, queries, and domain logic into view models or services that match the repo's conventions.
5. Prefer small, composable changes over replacing the whole screen.

## Design guidance

- Prefer official ArcGIS APIs and toolkit components over custom wrappers when they solve the problem cleanly.
- Make layer loading and failure states explicit.
- For identify and selection flows, surface:
  - whether a result was found
  - which layer or graphic produced it
  - what the UI should do when nothing is hit
- Clean up long-running jobs, listeners, and state when the screen leaves composition if the work should not continue.

## Compose guidance

Reference `compose-patterns.md`.

- Keep screen state and app state understandable and separate.
- Avoid overloading one composable with fetch, auth, map, and navigation logic at the same time.
- Use the repository's existing `ViewModel`, `StateFlow`, `MutableState`, or MVI-style patterns rather than mixing styles unnecessarily.

## Example requests

- "Add identify on tap and show the selected feature in a bottom sheet."
- "Add a SceneView to this Compose screen."
- "Use toolkit components instead of our custom map compass."
- "Refactor this map screen so state and UI responsibilities are cleaner."
