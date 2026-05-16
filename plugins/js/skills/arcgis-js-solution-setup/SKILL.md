---
name: arcgis-js-solution-setup
description: Set up or upgrade apps that use ArcGIS Maps SDK for JavaScript. Use when asked to add the SDK to a web project, choose between npm and CDN delivery, configure assets, or create the first working map or scene.
license: MIT
---

Use this skill when the task is about **project setup**, **SDK adoption**, or **first-use ArcGIS wiring** for ArcGIS Maps SDK for JavaScript.

## Goals

1. Confirm the app type and delivery model before editing: **npm/bundler** or **CDN**.
2. Reuse the repository's existing framework, bundler, and UI architecture.
3. Add the ArcGIS Maps SDK for JavaScript using supported package or CDN flows instead of inventing custom loading.
4. Produce a small working map or scene instead of stopping at dependency setup.
5. Keep API keys and auth configuration out of source control.

## Package guidance

Reference `js-package-matrix.md`.

Typical npm packages:

- `@arcgis/core`
- `@arcgis/map-components`
- `@esri/calcite-components` when surrounding UI needs Calcite components

## Setup process

1. Inspect the project for existing patterns:
   - framework and router choice
   - bundler or build tool
   - CSS entry points
   - environment handling
   - existing web component usage
2. Choose the lightest supported delivery model:
   - **npm** for framework or locally built apps
   - **CDN** for simple HTML/JavaScript apps that do not need local packaging
3. Add the required packages or CDN import.
4. Ensure ArcGIS assets and CSS are loaded correctly for the chosen setup.
5. Create the smallest end-to-end integration that proves the SDK is wired correctly:
   - `MapView`, `SceneView`, `arcgis-map`, or `arcgis-scene`
   - a map or scene with a sensible basemap
   - container sizing that guarantees visible output
6. Use map components or Calcite components when they fit the requested UI better than rebuilding the same behavior from scratch.

## Behavioral rules

- Do not hardcode API keys or OAuth client information into committed browser code unless the user explicitly wants a non-secret public key path and the repo already follows that pattern.
- Prefer `@arcgis/core` and `@arcgis/map-components` imports over legacy loader patterns for modern npm apps.
- Be explicit about CSS and asset loading. Many "blank map" bugs come from incomplete setup rather than broken map code.
- Keep framework-specific changes incremental and aligned with the repository's existing component structure.

## Common deliverables

- add `@arcgis/core` and related npm dependencies
- add ArcGIS CSS imports or CDN script usage
- create a first working `MapView`, `SceneView`, `arcgis-map`, or `arcgis-scene`
- wire basic map state into the existing app structure
- document the chosen npm or CDN integration path where it is not obvious

## Example requests

- "Add ArcGIS Maps SDK for JavaScript to this Vite app."
- "Create the first map screen in this TypeScript project."
- "Set up ArcGIS map components in this web app."
- "Upgrade this app from a CDN prototype to npm packages."
