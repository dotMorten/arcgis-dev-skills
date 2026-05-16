# SwiftUI and UIKit map UI patterns

## Good defaults

- Keep map state and app state understandable and separate.
- Keep transient gesture and view interaction logic close to the screen.
- Move reusable async work, filtering, and business rules to observable models or services.
- Cancel or clean up tasks when views disappear and stale work should not continue.

## Common implementation choices

### Adding layers

- Add a single clearly owned layer at a time.
- Expose loading and failure state rather than hiding it.

### Identify workflows

- Translate tap or gesture input into one clear identify path.
- Normalize results before broader UI state consumes them.

### Toolkit controls

- Prefer toolkit controls for compass, popup, search, offline areas, and similar UX when they match the need.
- Do not reimplement toolkit behavior unless the repo already has a deliberate custom design.

### Viewpoint management

- Set an initial viewpoint only when it helps startup UX.
- Avoid fighting the user's navigation with repeated forced viewpoint changes.
