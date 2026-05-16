# ArcGIS Maps SDK for Kotlin dependency matrix

## Repository

Add the Esri Maven repository to dependency resolution:

```kotlin
maven { url = uri("https://esri.jfrog.io/artifactory/arcgis") }
```

## Core SDK

Core artifact:

```kotlin
implementation("com.esri:arcgis-maps-kotlin:300.0.0")
```

## Toolkit BOM and common modules

Use the toolkit BOM to align toolkit versions:

```kotlin
implementation(platform("com.esri:arcgis-maps-kotlin-toolkit-bom:300.0.0"))
implementation("com.esri:arcgis-maps-kotlin-toolkit-geoview-compose")
implementation("com.esri:arcgis-maps-kotlin-toolkit-authentication")
```

Common optional toolkit modules include:

- basemap gallery
- compass
- offline
- popup
- scalebar
- utility networks

## Android manifest basics

Typical permissions:

- `android.permission.INTERNET`
- location permissions only when location features are used

GeoView feature declarations:

- `0x00020000` for 2D MapView
- `0x00030000` for SceneView
- `0x00030002` for LocalSceneView
