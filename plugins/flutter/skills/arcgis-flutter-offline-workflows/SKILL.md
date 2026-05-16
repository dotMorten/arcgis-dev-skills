---
name: arcgis-flutter-offline-workflows
description: Implement or improve offline map workflows with ArcGIS Maps SDK for Flutter. Use for local data, mobile map packages, offline map areas, file storage, and disconnected user experiences in Flutter apps.
license: MIT
---

Use this skill when the request involves **offline GIS behavior** in a Flutter app.

## Scope

- offline map areas
- mobile map packages
- local geodatabases or file-backed local content
- sync-enabled editable workflows
- download, resume, retry, and refresh behavior
- storage strategy and content lifecycle

## Workflow

1. Determine which offline model the app needs:
   - packaged offline content
   - generated offline areas
   - sync-enabled editable workflows
2. Inspect how the app already stores files, tracks jobs, and reports progress.
3. Fit ArcGIS jobs and async work into the app's existing state and lifecycle style.
4. Make status, cancellation, retry, and stale-data behavior explicit.
5. Keep local storage paths and cleanup rules predictable across supported mobile targets.

## Rules

- Do not treat offline support as only a download button; handle the lifecycle of local content.
- Surface progress and failure states clearly.
- Preserve local edits deliberately during sync flows.
- Watch for storage growth, stale packages, and platform-specific file path assumptions.
- Prefer a small coordinator, repository, or controller for offline orchestration instead of burying everything in UI code.

## Design checklist

Reference `offline-workflow-checklist.md`.

## Example requests

- "Add local mobile map package loading to this app."
- "Persist downloaded map content and reopen it on launch."
- "Implement offline edit handling."
- "Diagnose why offline content is never refreshed."
