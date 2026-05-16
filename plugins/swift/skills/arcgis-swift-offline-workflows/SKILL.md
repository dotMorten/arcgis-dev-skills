---
name: arcgis-swift-offline-workflows
description: Implement or improve offline map workflows with ArcGIS Maps SDK for Swift. Use for offline map areas, mobile map packages, local data storage, sync behavior, and disconnected user experiences in Swift apps.
license: MIT
---

Use this skill when the request involves **offline GIS behavior** in a Swift app.

## Scope

- offline map areas
- mobile map packages
- local geodatabases or file-backed local content
- sync-enabled edits
- download, resume, retry, and refresh behavior
- file storage strategy and content lifecycle

## Workflow

1. Determine which offline model the app needs:
   - packaged offline content
   - generated offline areas
   - sync-enabled editable workflows
2. Inspect how the app already stores files, tracks tasks, and reports progress.
3. Fit ArcGIS jobs and async work into the app's existing concurrency style.
4. Make status, cancellation, retry, and stale-data behavior explicit.
5. Keep local storage paths and cleanup rules predictable across supported Apple platforms.

## Rules

- Do not treat offline support as only a download button; handle the lifecycle of local content.
- Surface progress and failure states clearly.
- Preserve local edits deliberately during sync flows.
- Watch for storage growth, stale packages, and background task assumptions.
- Prefer a small coordinator, service, or observable model for offline orchestration instead of burying everything in the view.

## Design checklist

Reference `offline-workflow-checklist.md`.

## Example requests

- "Add offline map area download to this app."
- "Persist downloaded map content and reopen it on launch."
- "Implement sync for offline edits."
- "Diagnose why offline content is never refreshed."
