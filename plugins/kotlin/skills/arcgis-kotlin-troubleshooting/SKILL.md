---
name: arcgis-kotlin-troubleshooting
description: Diagnose ArcGIS Maps SDK for Kotlin issues. Use for blank maps, Gradle integration problems, coroutine or lifecycle issues, auth problems, toolkit integration bugs, and performance regressions in Android apps.
license: MIT
---

Use this skill when the user is debugging or stabilizing an ArcGIS Maps SDK for Kotlin app.

## Investigation priorities

1. Reproduce the symptom in the smallest relevant flow.
2. Determine whether the problem is caused by:
   - missing or invalid credentials
   - layer or map load failures
   - incorrect Gradle or repository integration
   - Compose lifecycle timing
   - stale coroutines, cancellation, or main-thread assumptions
   - retained state holders or repeated recomposition work
   - duplicated overlays, layers, or frequent viewpoint updates
3. Fix the root cause instead of only hiding the symptom.

## Troubleshooting style

- Check load status, thrown errors, and explicit failure paths first.
- Treat a blank map as a symptom, not a diagnosis.
- Inspect Gradle and repository configuration before changing rendering code.
- Review lifecycle and state restoration behavior when a map works once and then fails later.
- When performance is involved, look for duplicate layer creation, repeated identify requests, excessive state churn, and unnecessary viewpoint updates.

## Output expectations

- explain the likely root cause plainly
- make the smallest durable code change that fixes it
- improve observability when the original failure mode was silent

## Reference

Use `troubleshooting-matrix.md`.

## Example requests

- "Why is the map blank after this Compose navigation flow?"
- "The SDK dependency is present but the map never appears."
- "This SceneView became slow after we added overlays."
- "Fix the recomposition or state retention issue in this map screen."
