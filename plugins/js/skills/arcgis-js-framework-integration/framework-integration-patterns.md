# ArcGIS Maps SDK for JavaScript framework integration patterns

## Lifecycle ownership

- Create the map view only after the DOM container or component host exists.
- Dispose or detach the view when the owning route or component unmounts.
- Keep one obvious owner for long-lived ArcGIS objects.

## Framework boundaries

- **React**: avoid recreating ArcGIS objects during render; use stable refs and effect-based lifecycle wiring.
- **Vue**: keep ArcGIS view setup in mounted lifecycle boundaries and clean up on unmount.
- **Angular**: keep SDK object creation aligned with component lifecycle and change-detection boundaries.
- **Web components**: load component imports once and let component markup stay declarative where possible.

## Build and tooling concerns

- Keep ArcGIS CSS, component imports, and Calcite setup aligned with the bundler entry points.
- Prefer the repo's existing TypeScript, Vite, and routing structure over sample-app rewrites.
- Be careful with lazy-loaded routes and code splitting so asset and component registration still happens when needed.
