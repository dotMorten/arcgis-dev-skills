---
name: arcgis-js-auth-access
description: Help with ArcGIS Maps SDK for JavaScript authentication and access configuration. Use for API key setup, OAuth, browser-safe configuration, and choosing the right access model for web apps.
license: MIT
---

Use this skill when the task involves **credentials**, **access configuration**, or **user authentication** for an ArcGIS Maps SDK for JavaScript app.

## Primary objectives

1. Choose the lightest access model that satisfies the app's needs.
2. Keep secrets out of the repository and out of client-side code paths that should stay server-owned.
3. Fit access configuration into the app's existing build and environment model.
4. Make auth flows easy for the next developer to trace.

## Decision guide

Reference `auth-and-access-checklist.md`.

Default choices:

- If the app only needs supported location services access, prefer an API key or other browser-safe token approach.
- If the app needs user-specific or organization-scoped content, prefer OAuth with `OAuthInfo` and `IdentityManager`.
- If the access model is unclear and multiple approaches fit, explain the tradeoff and ask.

## Implementation rules

- Never commit secrets, refresh tokens, or server-only credentials into browser code.
- Prefer configuration paths already used by the app, such as:
  - `.env` or `.env.local`
  - build-time environment injection
  - ignored local config files
  - existing backend token exchange flows
- Use `esriConfig.apiKey` or class-specific API key configuration intentionally rather than scattering keys through unrelated files.
- For OAuth, register `OAuthInfo` and `IdentityManager` setup in one discoverable startup path.
- Keep sign-in, sign-out, and credential reset behavior explicit.
- Surface authentication failures instead of hiding them behind blank UI.

## What to produce

- browser-safe access configuration
- OAuth or API key wiring that matches the current architecture
- startup auth setup that is easy to find
- concise code-level guidance where browser auth setup would otherwise be hard to discover

## Example requests

- "Replace the hardcoded ArcGIS API key."
- "Add ArcGIS Online sign-in to this app."
- "Move JavaScript SDK auth config into environment variables."
- "Set up OAuth in this Vite app without leaking secrets."
