# ArcGIS Maps SDK for JavaScript UI patterns

## Core UI choices

- Use **map components** for fast, declarative web mapping UI.
- Use **`MapView` / `SceneView`** directly when the app needs lower-level control or already has view-based integration.
- Use **Calcite** for surrounding app chrome, panels, shells, and action bars when the UX fits that system.

## Common interaction patterns

- **Identify / click selection**: use hit testing or layer queries, keep selection state explicit, and update popup or side-panel UI from one place.
- **Popup-driven UX**: prefer popup templates and view popup APIs over ad hoc HTML strings spread across files.
- **Viewpoint sync**: centralize zoom, center, and extent updates so map-driven and UI-driven navigation stay consistent.
- **Layer toggles**: wire visibility to the app's existing state model instead of duplicating map state in multiple stores.

## Framework integration notes

- Create the view after the container exists.
- Destroy or detach the view when the owning component unmounts.
- Keep long-lived ArcGIS objects out of repeated render loops.
