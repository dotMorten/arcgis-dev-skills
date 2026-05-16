---
name: arcgis-kotlin-solution-setup
description: Set up or upgrade apps that use ArcGIS Maps SDK for Kotlin. Use when asked to add the SDK to an Android project, configure Gradle dependencies, or create the first working map or scene in a Compose-based app.
license: MIT
---

Use this skill when the task is about **project setup**, **Gradle integration**, or **first-use ArcGIS wiring** for ArcGIS Maps SDK for Kotlin.

## Goals

1. Confirm the app structure and preserve the existing architecture if it is already clear.
2. Add ArcGIS Maps SDK for Kotlin using Gradle and the Esri Maven repository instead of inventing a custom integration path.
3. Produce a small working map or scene instead of stopping after dependency configuration.
4. Keep API keys, licensing values, and auth configuration out of source control.
5. Prefer toolkit modules when the task needs Compose GeoView wrappers or auth UI.

## Dependency guidance

Reference `gradle-dependency-matrix.md`.

Default Maven repository:

`https://esri.jfrog.io/artifactory/arcgis`

Core SDK artifact:

`com.esri:arcgis-maps-kotlin`

Toolkit BOM:

`com.esri:arcgis-maps-kotlin-toolkit-bom`

## Setup process

1. Identify the app structure:
   - single-module app
   - multi-module app
   - Compose-first UI
   - mixed Android view and Compose app
2. Inspect the project for existing patterns:
   - version catalogs and `libs.versions.toml`
   - top-level and module-level `build.gradle.kts`
   - `settings.gradle.kts` repository configuration
   - app startup, state management, and dependency injection
3. Add the Esri Maven repository in the correct place if it is missing.
4. Add the ArcGIS SDK dependency and keep toolkit versions aligned with the same release line.
5. Create the smallest end-to-end integration that proves the SDK is wired correctly:
   - render a `MapView` or `SceneView`
   - configure a map or scene with a sensible basemap
   - set an initial viewpoint only when it improves startup UX
6. Add required manifest entries only when the app truly needs them.

## Behavioral rules

- If the project is not Compose-based, do not force a sweeping rewrite unless the user asked for it.
- Prefer Gradle Kotlin DSL and version catalogs when the project already uses them.
- Do not hardcode API keys, tokens, or licensing strings into committed Kotlin files.
- Do not add broad permissions the app does not need.
- Keep changes incremental and aligned with the repository's state management and DI approach.

## Common deliverables

- add ArcGIS dependencies to Gradle files
- add the Esri Maven repository
- create a first working map screen
- wire toolkit modules like geoview compose or authentication
- add needed Android manifest permissions and GL feature declarations deliberately

## Example requests

- "Add ArcGIS Maps SDK for Kotlin to this Android app."
- "Create the first map screen in this Compose project."
- "Set up toolkit modules for map and auth."
- "Upgrade this project to the current ArcGIS Maps SDK for Kotlin line."
