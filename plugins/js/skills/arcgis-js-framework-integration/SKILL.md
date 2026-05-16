---
name: arcgis-js-framework-integration
description: Integrate ArcGIS Maps SDK for JavaScript into modern web stacks. Use for React, Vue, Angular, Vite, TypeScript, Calcite, routing, lifecycle, and component-boundary issues.
license: MIT
---

Use this skill when the task is about **framework integration**, **component lifecycle**, **bundler setup**, or **web-app architecture** around ArcGIS Maps SDK for JavaScript.

## Primary objectives

1. Fit ArcGIS into the repository's existing web framework instead of forcing a generic sample structure onto it.
2. Keep long-lived ArcGIS objects stable across renders, route changes, and component boundaries.
3. Prefer framework-friendly composition over ad hoc globals and DOM mutation.
4. Make lifecycle ownership of views, components, and cleanup easy to trace.

## Integration guidance

Reference `framework-integration-patterns.md`.

Default choices:

- Respect the framework's lifecycle and render model first.
- Prefer map components when they simplify framework integration cleanly.
- Use direct `MapView` or `SceneView` ownership when the app needs lower-level control.
- Keep routing, lazy loading, and shared app state aligned with the repo's existing patterns.

## Implementation rules

- Do not recreate views on every render or state update.
- Avoid storing long-lived ArcGIS instances inside ephemeral render-only values.
- Be explicit about mount, ready, and teardown behavior.
- Keep framework wrappers thin unless the repository already uses a deeper abstraction.
- Reuse existing TypeScript, Vite, router, and component conventions instead of introducing a parallel app structure.

## What to produce

- framework-aware ArcGIS component or module integration
- route-safe and lifecycle-safe view ownership
- bundler and component imports that match the app's tooling
- concise guidance when ArcGIS objects cross component or state boundaries

## Example requests

- "Move this ArcGIS map into a reusable React component."
- "Wire ArcGIS map components into this Vue app."
- "Fix the Angular lifecycle issues around MapView creation and cleanup."
- "Make this Vite + TypeScript app integrate Calcite and ArcGIS components cleanly."
