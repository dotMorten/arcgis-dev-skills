---
name: arcgis-swift-solution-setup
description: Set up or upgrade apps that use ArcGIS Maps SDK for Swift. Use when asked to add the SDK to an Xcode project, configure Swift Package Manager dependencies, or create the first working map or scene in a SwiftUI or UIKit app.
license: MIT
---

Use this skill when the task is about **project setup**, **Swift Package Manager integration**, or **first-use ArcGIS wiring** for ArcGIS Maps SDK for Swift.

## Goals

1. Confirm whether the app uses **SwiftUI** or **UIKit**, and preserve the existing architecture if it is already clear.
2. Add ArcGIS Maps SDK for Swift using Swift Package Manager instead of inventing a custom integration path.
3. Produce a small working map or scene instead of stopping after package configuration.
4. Keep API keys, licensing values, and auth configuration out of source control.
5. Prefer the toolkit package when the task needs toolkit controls, because it brings in ArcGIS as a dependency.

## Package guidance

Reference `swift-package-matrix.md`.

Default package URL for ArcGIS Maps SDK for Swift:

`https://github.com/Esri/arcgis-maps-sdk-swift`

Default toolkit package URL:

`https://github.com/Esri/arcgis-maps-sdk-swift-toolkit`

## Setup process

1. Identify the app style:
   - SwiftUI
   - UIKit
   - mixed app with UIKit navigation and SwiftUI screens
2. Inspect the project for existing patterns:
   - package dependency management
   - app lifecycle and scene setup
   - view model and state management
   - local configuration and secrets handling
3. Add the ArcGIS package and keep versions consistent with any ArcGIS toolkit package.
4. Create the smallest end-to-end integration that proves the SDK is wired correctly:
   - import `ArcGIS`
   - render a `MapView` or `SceneView`
   - configure a map or scene with a sensible basemap
   - set an initial viewpoint only when it improves startup UX
5. If the task requires toolkit components, prefer importing `ArcGISToolkit` rather than recreating built-in controls.
6. Fit the result into the repo's existing architecture instead of creating a parallel app structure.

## Behavioral rules

- If the UI stack or target platform is unclear and cannot be inferred, ask.
- Prefer Swift Package Manager over manual vendoring or ad hoc binary handling.
- Do not hardcode API keys, tokens, or licensing strings into committed Swift files.
- Do not force a SwiftUI rewrite on a UIKit app, or vice versa, unless the user asks for that change.
- Keep changes incremental and aligned with the repository's state management style.

## Common deliverables

- add ArcGIS package dependencies to an Xcode project
- create a first `MapView` or `SceneView`
- wire a map into a SwiftUI view, UIKit controller, or shared view model
- add toolkit dependencies for controls like compass, popup, search, or offline UI
- upgrade package versions consistently across ArcGIS packages

## Example requests

- "Add ArcGIS Maps SDK for Swift to this SwiftUI app."
- "Create the first map screen in this iOS project."
- "Add ArcGIS toolkit components to this app."
- "Upgrade this project to the current ArcGIS Maps SDK for Swift line."
