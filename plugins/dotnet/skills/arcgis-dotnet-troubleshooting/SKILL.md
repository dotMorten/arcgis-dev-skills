---
name: arcgis-dotnet-troubleshooting
description: Diagnose ArcGIS Maps SDK for .NET issues. Use for blank maps, load failures, threading and lifecycle bugs, toolkit integration problems, performance regressions, memory pressure, and navigation-related rendering issues.
license: MIT
---

Use this skill when the user is debugging or stabilizing an ArcGIS Maps SDK for .NET app.

For ArcGIS and Esri Developer documentation lookups, follow `..\..\mcp-developer-docs-guidance.md`. Prefer the `net-sdk` focus area unless the symptom is specifically about auth, offline, portal/data services, location services, or spatial analysis.

## Grounding with samples

When symptoms involve API usage, lifecycle, toolkit controls, auth, or offline jobs, search the local sample index with `arcgis-dotnet-search` located relative to this skill:

```powershell
dotnet run --project ..\..\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- search "<symptom or API>" --platform winui
dotnet run --project ..\..\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- get <id>
```

Compare the failing code to the closest working sample before changing unrelated rendering or navigation code.

## Investigation priorities

1. Reproduce the symptom in the smallest relevant flow.
2. Determine whether the problem is caused by:
   - missing or invalid credentials
   - load status failures
   - wrong target package or version mismatch
   - page lifecycle or navigation timing
   - threading or dispatcher usage
   - event subscription leaks
   - oversized graphics, layers, or repeated redraw work
3. Fix the root cause instead of only masking the symptom.

## Troubleshooting style

- Check `LoadStatus`, exceptions, and explicit failure messages first.
- Treat a blank map as a symptom, not a diagnosis.
- Inspect startup auth and licensing before changing rendering code.
- Review navigation and disposal behavior when a view works once and then fails.
- When performance is involved, look for duplicate layers, repeated subscriptions, unnecessary overlay rebuilds, and over-frequent viewpoint updates.

## Output expectations

- explain the likely root cause plainly
- make the smallest durable code change that fixes it
- improve observability when the original failure mode was silent

## Reference

Use `troubleshooting-matrix.md`.

## Example requests

- "Why is the map blank after navigating back to this page?"
- "The layer never loads but there is no visible error."
- "This SceneView became sluggish after we added overlays."
- "Fix the memory leak in our map page."
