---
name: arcgis-js-troubleshooting
description: Diagnose ArcGIS Maps SDK for JavaScript issues. Use for blank maps, asset-path problems, auth errors, CORS failures, build-tool regressions, performance issues, and interaction bugs.
license: MIT
---

Use this skill when an ArcGIS Maps SDK for JavaScript app is **broken**, **blank**, **slow**, or behaving unexpectedly.

## Troubleshooting priorities

1. Reproduce the visible symptom and narrow it to setup, assets, auth, data, or rendering.
2. Check the most common JavaScript SDK failure points first.
3. Fix the root cause instead of papering over missing assets or auth errors.
4. Leave the app easier to diagnose next time.

## Investigation guide

Reference `troubleshooting-matrix.md`.

Start with these checks:

- Is the map container sized correctly and actually mounted?
- Are ArcGIS CSS, assets, and imports loaded the way the chosen npm or CDN setup expects?
- Is the app failing on CORS, proxy, or token/auth errors?
- Is the framework lifecycle creating duplicate views or destroying the view too early?
- Did a bundler, route change, or lazy-loaded boundary break asset resolution?

## Behavioral rules

- Do not settle for "the map is blank" as a diagnosis.
- Preserve the existing framework and build setup unless the root cause requires changing it.
- Prefer a small reproducible fix over a large migration when the issue is localized.
- Make console, network, and runtime errors part of the reasoning, not an afterthought.

## What to produce

- root-cause diagnosis
- targeted fix
- brief code-level explanation when the failure mode was non-obvious
- follow-up hardening only when it directly prevents the same failure class

## Example requests

- "Why did this map go blank after moving to Vite?"
- "Fix the OAuth sign-in loop in this JavaScript app."
- "Find the CORS issue blocking this layer."
- "Investigate why the scene is slow after adding several layers."
