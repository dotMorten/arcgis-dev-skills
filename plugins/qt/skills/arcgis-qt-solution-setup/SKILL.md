---
name: arcgis-qt-solution-setup
description: Set up or upgrade apps that use ArcGIS Maps SDK for Qt. Use when asked to add the SDK to a Qt Quick or Widgets project, configure kits and project integration, or create the first working map or scene.
license: MIT
---

Use this skill when the task is about **project setup**, **Qt kit and SDK integration**, or **first-use ArcGIS wiring** for ArcGIS Maps SDK for Qt.

## Goals

1. Confirm whether the app uses **Qt Quick/QML** or **Qt Widgets**, and preserve the existing architecture if it is already clear.
2. Fit the ArcGIS Maps SDK for Qt into the repository's current project system and kit setup instead of inventing a parallel layout.
3. Produce a small working map or scene instead of stopping after installation guidance.
4. Keep API keys, licensing values, and auth configuration out of source control.
5. Prefer toolkit components when the task needs ready-made Qt Quick or Widgets GIS UI.

## Setup guidance

Reference `qt-setup-matrix.md`.

ArcGIS Maps SDK for Qt commonly involves:

- Qt Creator kit configuration
- matching Qt version and compiler/toolchain setup
- project integration with qmake or CMake
- platform-specific setup for desktop or mobile targets

## Setup process

1. Identify the app style:
   - Qt Quick/QML
   - Qt Widgets
   - mixed QML and C++ app
2. Inspect the project for existing patterns:
   - qmake or CMake
   - Qt Creator kit assumptions
   - app lifecycle and startup structure
   - config, secrets, and licensing initialization
3. Integrate ArcGIS Maps SDK for Qt in the least disruptive way that matches the repo's current structure.
4. Create the smallest end-to-end integration that proves the SDK is wired correctly:
   - add a `MapView` or `SceneView`
   - configure a map or scene with a sensible basemap
   - set an initial viewpoint only when it improves startup UX
5. If toolkit controls are relevant, prefer them over custom GIS UI implementations.
6. Keep project and kit instructions explicit when the repository depends on developer machine configuration.

## Behavioral rules

- If the UI stack or build system is unclear and cannot be inferred, ask.
- Do not force a Qt Quick rewrite on a Widgets app, or vice versa, unless the user asked for that change.
- Do not hardcode API keys, tokens, or licensing strings into committed source.
- Keep changes incremental and aligned with the repository's existing project structure.
- Be explicit about any developer-machine prerequisites that code alone cannot solve.

## Common deliverables

- integrate ArcGIS Maps SDK for Qt into an existing project
- add a first `MapView` or `SceneView`
- wire a map into QML or a QWidget-based screen
- add toolkit usage where it reduces custom UI code
- align project changes with qmake or CMake conventions already used in the repo

## Example requests

- "Add ArcGIS Maps SDK for Qt to this Qt Quick app."
- "Create the first map screen in this Widgets project."
- "Set up toolkit controls for this QML map screen."
- "Upgrade this project to the current ArcGIS Maps SDK for Qt line."
