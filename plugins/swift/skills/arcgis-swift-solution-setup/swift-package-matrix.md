# ArcGIS Maps SDK for Swift package matrix

## Core package

Use this package for the main SDK:

`https://github.com/Esri/arcgis-maps-sdk-swift`

Import in source files:

```swift
import ArcGIS
```

## Toolkit package

Use this package when you need toolkit controls or job helpers:

`https://github.com/Esri/arcgis-maps-sdk-swift-toolkit`

Imports:

```swift
import ArcGIS
import ArcGISToolkit
```

## Platform guidance

- Primary targets include iOS devices
- Mac Catalyst is supported
- Vision Pro and visionOS-related scenarios may be relevant for some apps

## Good defaults

- Prefer Swift Package Manager in Xcode
- Keep ArcGIS and toolkit versions aligned
- If you already depend on the toolkit package, avoid adding the core package separately unless the project structure requires it
