---
name: arcgis-swift-troubleshooting
description: Diagnose ArcGIS Maps SDK for Swift issues. Use for blank maps, package integration problems, async task failures, auth issues, toolkit integration bugs, and performance or lifecycle regressions in Swift apps.
license: MIT
---

Use this skill when the user is debugging or stabilizing an ArcGIS Maps SDK for Swift app.

## Investigation priorities

1. Reproduce the symptom in the smallest relevant flow.
2. Determine whether the problem is caused by:
   - missing or invalid credentials
   - layer or map load failures
   - incorrect package integration
   - SwiftUI or UIKit lifecycle timing
   - stale async tasks, cancellation, or main-thread assumptions
   - retained observers or state objects
   - oversized overlays, layers, or repeated redraw work
3. Fix the root cause instead of only hiding the symptom.

## Troubleshooting style

- Check load status, thrown errors, and explicit failure paths first.
- Treat a blank map as a symptom, not a diagnosis.
- Inspect package and target configuration before changing rendering code.
- Review navigation and deallocation behavior when a map works once and then fails later.
- When performance is involved, look for duplicate layer creation, repeated identify requests, excessive state churn, and unnecessary viewpoint updates.

## Output expectations

- explain the likely root cause plainly
- make the smallest durable code change that fixes it
- improve observability when the original failure mode was silent

## Reference

Use `troubleshooting-matrix.md`.

## Example requests

- "Why is the map blank after this SwiftUI navigation flow?"
- "The package builds but the map never appears."
- "This SceneView became slow after we added overlays."
- "Fix the state retention issue in this map screen."
