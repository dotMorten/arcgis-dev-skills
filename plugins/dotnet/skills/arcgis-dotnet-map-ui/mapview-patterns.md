# ArcGIS map UI patterns

## Good defaults

- Load layers deliberately and surface failures early.
- Keep transient map-control interactions in the view layer.
- Keep app state and business decisions in view models or services.
- Dispose or detach event subscriptions when pages or controls are torn down.

## Common implementation choices

### Adding layers

- Prefer adding one clearly named layer at a time.
- If authentication or remote loading is involved, make the failure state visible.

### Identify workflows

- Translate tap or click events into a clear identify path.
- Normalize the result into an app-friendly model before handing it to broader UI state.

### Graphics overlays

- Use overlays for temporary drawings, selections, sketches, and analysis feedback.
- Clear or refresh overlays when the underlying selection context changes.

### Navigation and viewpoint

- Set an initial viewpoint only when it improves startup UX.
- Avoid fighting the user's manual navigation with over-aggressive auto-centering.
