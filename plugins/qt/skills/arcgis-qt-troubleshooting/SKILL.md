---
name: arcgis-qt-troubleshooting
description: Diagnose ArcGIS Maps SDK for Qt issues. Use for blank maps, Qt kit or SDK integration problems, auth problems, QML or Widgets lifecycle issues, toolkit integration bugs, and performance regressions.
license: MIT
---

Use this skill when the user is debugging or stabilizing an ArcGIS Maps SDK for Qt app.

## Investigation priorities

1. Reproduce the symptom in the smallest relevant flow.
2. Determine whether the problem is caused by:
   - missing or invalid credentials
   - layer or map load failures
   - incorrect Qt kit, compiler, or SDK integration
   - qmake or CMake project configuration issues
   - QML or Widgets lifecycle timing
   - leaked signal connections or retained state objects
   - duplicated overlays, layers, or frequent viewpoint updates
3. Fix the root cause instead of only hiding the symptom.

## Troubleshooting style

- Check load status, thrown errors, and explicit failure paths first.
- Treat a blank map as a symptom, not a diagnosis.
- Inspect Qt kit and SDK configuration before changing rendering code.
- Review screen teardown and recreation behavior when a map works once and then fails later.
- When performance is involved, look for duplicate layer creation, repeated identify requests, excessive state churn, and unnecessary viewpoint updates.

## Output expectations

- explain the likely root cause plainly
- make the smallest durable code change that fixes it
- improve observability when the original failure mode was silent

## Reference

Use `troubleshooting-matrix.md`.

## Example requests

- "Why is the map blank in this QML screen?"
- "The SDK is configured but the map never appears."
- "This SceneView became slow after we added overlays."
- "Fix the lifetime or connection issue in this map screen."
