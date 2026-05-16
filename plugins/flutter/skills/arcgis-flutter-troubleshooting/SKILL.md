---
name: arcgis-flutter-troubleshooting
description: Diagnose ArcGIS Maps SDK for Flutter issues. Use for blank maps, package or platform setup issues, auth problems, widget lifecycle bugs, toolkit integration issues, and performance regressions.
license: MIT
---

Use this skill when the user is debugging or stabilizing an ArcGIS Maps SDK for Flutter app.

## Investigation priorities

1. Reproduce the symptom in the smallest relevant flow.
2. Determine whether the problem is caused by:
   - missing or invalid credentials
   - layer or map load failures
   - incomplete package setup or missing `arcgis_maps_core`
   - Android or iOS platform configuration issues
   - widget lifecycle timing
   - leaked controllers, listeners, or retained state objects
   - duplicated overlays, layers, or frequent viewpoint updates
3. Fix the root cause instead of only hiding the symptom.

## Troubleshooting style

- Check load status, thrown errors, and explicit failure paths first.
- Treat a blank map as a symptom, not a diagnosis.
- Inspect package setup and platform configuration before changing rendering code.
- Review widget teardown and recreation behavior when a map works once and then fails later.
- When performance is involved, look for duplicate layer creation, repeated identify requests, excessive state churn, and unnecessary viewpoint updates.

## Output expectations

- explain the likely root cause plainly
- make the smallest durable code change that fixes it
- improve observability when the original failure mode was silent

## Reference

Use `troubleshooting-matrix.md`.

## Example requests

- "Why is the map blank on Android after this dependency change?"
- "The package is added but the map never appears."
- "This map screen became slow after we added overlays."
- "Fix the controller or lifecycle issue in this map screen."
