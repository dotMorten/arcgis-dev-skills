# Flutter map UI patterns

## Good defaults

- Keep map interaction state and app state understandable and separate.
- Keep transient gesture and map interaction logic close to the widget tree.
- Move reusable async work, filtering, and business rules to controllers, notifiers, or services.
- Dispose controllers and remove listeners when widgets are torn down.

## Common implementation choices

### Adding layers

- Add a single clearly owned layer at a time.
- Expose loading and failure state rather than hiding it.

### Identify workflows

- Translate tap input into one clear identify path.
- Normalize results before broader UI state consumes them.

### Toolkit widgets

- Prefer toolkit widgets for popup, compass, overview map, and auth UI when they match the need.
- Do not reimplement toolkit behavior unless the repo already has a deliberate custom design.

### Viewpoint management

- Set an initial viewpoint only when it helps startup UX.
- Avoid repeated forced viewpoint changes that fight the user.
