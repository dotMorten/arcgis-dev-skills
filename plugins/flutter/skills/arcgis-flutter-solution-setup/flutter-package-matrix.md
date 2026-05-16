# ArcGIS Maps SDK for Flutter package matrix

## Core package

Add the main package:

```yaml
dependencies:
  arcgis_maps: ^300.0.0
```

Then run:

```text
flutter pub upgrade
dart run arcgis_maps install
```

Keep `arcgis_maps_core` out of source control.

## Toolkit package

Add toolkit widgets when needed:

```yaml
dependencies:
  arcgis_maps_toolkit: ^300.0.0
```

The toolkit requires `arcgis_maps` to already be installed.

## Platform guidance

- Android deployment from Windows or macOS
- iOS deployment from macOS
- Android minimum SDK requirement should be kept aligned with the current ArcGIS Flutter requirements

## Good defaults

- Prefer `--dart-define` or ignored config for secrets
- Add only the platform auth callback configuration the app actually needs
- Keep pub package versions aligned across ArcGIS packages
