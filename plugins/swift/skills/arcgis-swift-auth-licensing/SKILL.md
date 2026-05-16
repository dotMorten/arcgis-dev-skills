---
name: arcgis-swift-auth-licensing
description: Help with ArcGIS Maps SDK for Swift authentication and licensing. Use for API key setup, secure configuration, user authentication, and choosing an appropriate licensing approach for Swift apps.
license: MIT
---

Use this skill when the task involves **credentials**, **secure configuration**, or **licensing** for an ArcGIS Maps SDK for Swift app.

## Primary objectives

1. Choose the lightest access model that satisfies the app's needs.
2. Keep secrets out of the repository.
3. Fit credentials into the app's existing configuration model.
4. Make the auth and licensing path easy for future maintainers to find.

## Decision guide

Reference `auth-and-licensing-checklist.md`.

Default choices:

- If the app only needs API key-supported services, prefer an API key setup.
- If the app needs user-specific or organization-scoped content, prefer an authenticated user flow.
- If the user has not specified the access model and multiple approaches fit, explain the tradeoff and ask.

## Implementation rules

- Never commit API keys, refresh tokens, secrets, or licensing strings.
- Prefer secure configuration patterns already used by the app, such as:
  - xcconfig files excluded from source control
  - development-only secrets files
  - environment-specific configuration
  - platform-secure storage or existing secrets abstractions
- Keep auth startup and reset behavior explicit.
- Surface authentication failures instead of silently swallowing them.
- Keep licensing initialization easy to locate in app startup flow.

## What to produce

- secure configuration plumbing
- auth and licensing setup that matches the current architecture
- startup initialization for ArcGIS auth or licensing
- concise code-level guidance where the setup would otherwise be hard to discover

## Example requests

- "Replace the hardcoded ArcGIS API key."
- "Set up secure local development secrets for this SwiftUI app."
- "Add user authentication for ArcGIS content."
- "Wire licensing into app startup."
