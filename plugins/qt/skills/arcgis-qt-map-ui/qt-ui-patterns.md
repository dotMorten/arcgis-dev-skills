# Qt map UI patterns

## Good defaults

- Keep transient map interaction logic close to the screen.
- Move reusable business logic into C++ backing types, models, or controllers.
- Expose loading and failure state instead of hiding it.
- Clean up signal connections and temporary map interaction objects when screens are destroyed.

## Common implementation choices

### Adding layers

- Add a single clearly owned layer at a time.
- Make failures visible during development and in logs.

### Identify workflows

- Translate the input gesture into one clear identify path.
- Normalize results before broader UI state consumes them.

### Toolkit components

- Prefer toolkit components for common GIS UI such as popup, callout, search, scale bar, floor filtering, or north arrow.
- Do not reimplement toolkit behavior unless the repo already has a deliberate custom design.

### Viewpoint management

- Set an initial viewpoint only when it helps startup UX.
- Avoid repeated forced viewpoint changes that fight the user.
