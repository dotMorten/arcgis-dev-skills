---
name: arcgis-dotnet-offline-workflows
description: Implement or improve offline map workflows with ArcGIS Maps SDK for .NET. Use for mobile map packages, offline map areas, geodatabase sync, local cache strategy, and disconnected editing flows.
license: MIT
---

Use this skill when the request involves **offline GIS behavior**.

## Grounding with samples

Before implementing an offline pattern, search the local sample index with `arcgis-dotnet-search` run from the marketplace root of this plugin:

```powershell
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- search "offline map sync geodatabase" --source runtime
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- search "offline workflows" --source demo
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- get <id>
```

Use runtime samples for focused API usage and demo apps for full lifecycle structure.

## Scope

- offline map areas
- mobile map packages
- local geodatabases
- sync-enabled edits
- download, resume, retry, and refresh behavior
- storage and cache lifecycle decisions

## Workflow

1. Determine which offline model the app needs:
   - packaged offline content
   - generated offline areas
   - sync-enabled editable data
2. Inspect how the app currently stores files, tracks jobs, and reports progress.
3. Fit ArcGIS jobs and sync operations into the app's existing async patterns.
4. Make status, cancellation, retry, and stale-data behavior explicit.
5. Keep local storage paths and cleanup rules predictable.

## Rules

- Do not treat offline support as only a download button; handle the full lifecycle.
- Surface progress and failure states clearly.
- Preserve local edits deliberately during sync flows.
- Be careful with storage growth, cache invalidation, and update strategy.
- Prefer small services or coordinators for offline orchestration rather than burying everything in the page code-behind.

## Design checklist

Reference `offline-workflow-checklist.md`.

## Example requests

- "Add offline map area download to this field app."
- "Store map packages locally and reopen them on startup."
- "Implement sync for offline edits."
- "Diagnose why downloaded content never refreshes."
