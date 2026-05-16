---
name: arcgis-flutter-solution-setup
description: Set up or upgrade apps that use ArcGIS Maps SDK for Flutter. Use when asked to add the SDK to a Flutter project, configure platform requirements, or create the first working map or scene.
license: MIT
---

Use this skill when the task is about **project setup**, **pub package integration**, or **first-use ArcGIS wiring** for ArcGIS Maps SDK for Flutter.

## Goals

1. Confirm the app structure and preserve the existing architecture if it is already clear.
2. Add ArcGIS Maps SDK for Flutter using the supported `arcgis_maps` package flow instead of inventing a custom integration path.
3. Produce a small working map or scene instead of stopping after dependency configuration.
4. Keep API keys, licensing values, and auth configuration out of source control.
5. Prefer toolkit widgets when the task needs ready-made mapping UI.

## Package guidance

Reference `flutter-package-matrix.md`.

Core package:

`arcgis_maps`

Toolkit package:

`arcgis_maps_toolkit`

## Setup process

1. Inspect the Flutter project for existing patterns:
   - state management
   - platform configuration
   - `pubspec.yaml` usage
   - Android and iOS app settings
   - secrets and environment handling
2. Add the `arcgis_maps` dependency with pub.
3. Run the required setup flow conceptually in the instructions you encode:
   - `flutter pub upgrade`
   - `dart run arcgis_maps install`
4. Ensure `arcgis_maps_core` is treated as generated/binary project content and kept out of source control.
5. Add the smallest end-to-end integration that proves the SDK is wired correctly:
   - import `package:arcgis_maps/arcgis_maps.dart`
   - render an `ArcGISMapView` or scene view widget
   - configure a map or scene with a sensible basemap
6. Add only the platform permissions and Android configuration the app actually needs.

## Behavioral rules

- Do not hardcode API keys, tokens, or licensing strings into committed Dart files.
- Do not ignore the `dart run arcgis_maps install` step; the Flutter package depends on installed core binaries.
- Be explicit about Android minimum SDK and platform auth callback setup when relevant.
- Keep changes incremental and aligned with the repository's existing widget and state-management style.
- Prefer toolkit widgets over custom implementations when they solve the requested UX cleanly.

## Common deliverables

- add `arcgis_maps` to `pubspec.yaml`
- document or encode the `arcgis_maps_core` setup step
- create a first working `ArcGISMapView`
- wire toolkit widgets like popup, compass, overview map, or authenticator
- update Android or iOS config only when required for the requested feature

## Example requests

- "Add ArcGIS Maps SDK for Flutter to this app."
- "Create the first map screen in this Flutter project."
- "Set up the toolkit widgets for popup and compass."
- "Upgrade this project to the current ArcGIS Maps SDK for Flutter line."
