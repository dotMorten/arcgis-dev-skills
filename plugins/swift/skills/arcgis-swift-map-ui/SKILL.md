---
name: arcgis-swift-map-ui
description: Build or refine ArcGIS Maps SDK for Swift map UI. Use for SwiftUI or UIKit map experiences such as MapView, SceneView, identify, overlays, popup flows, viewpoint logic, and toolkit components.
license: MIT
---

Use this skill when the task centers on **map experience behavior** in a Swift app using ArcGIS Maps SDK for Swift.

## Focus areas

- SwiftUI and UIKit map screens
- `MapView` and `SceneView`
- operational layers and basemap setup
- identify workflows and feature selection
- overlays, popup-like presentation, and bottom sheet style UI
- viewpoint and navigation behavior
- toolkit components such as compass, popup, search, offline map areas, or location controls

## Default approach

1. Find the current map screen, state owner, and lifecycle boundary.
2. Preserve the current UI model:
   - SwiftUI view with observable state
   - UIKit controller and delegate flow
   - mixed architecture
3. Keep short-lived interaction logic near the view layer.
4. Move reusable state, queries, and domain logic into observable models, controllers, or services that match the repo's conventions.
5. Prefer small, composable changes over replacing the whole screen.

## Design guidance

- Prefer official ArcGIS APIs and toolkit components over custom wrappers when they solve the problem cleanly.
- Make layer loading and failure states explicit.
- For identify and selection flows, surface:
  - whether a result was found
  - which layer or graphic produced it
  - what the UI should do when nothing is hit
- Clean up observers, tasks, and bindings when the view disappears or the controller is deallocated.

## SwiftUI guidance

Reference `swiftui-patterns.md`.

- Keep UI state and interaction state predictable.
- Avoid overloading a single view with fetch, auth, map, and navigation logic all at once.
- Use the repository's existing `ObservableObject`, `@Observable`, `@StateObject`, or actor patterns rather than mixing styles unnecessarily.

## UIKit guidance

- Respect the current controller hierarchy.
- Keep ArcGIS view lifecycle work aligned with UIKit lifecycle methods already used in the repo.
- Avoid pushing view-only logic into service layers.

## Example requests

- "Add identify on tap and present the result in a bottom sheet."
- "Add a SceneView to this SwiftUI screen."
- "Use toolkit controls instead of our custom map compass."
- "Refactor this map screen so state and UI responsibilities are cleaner."
