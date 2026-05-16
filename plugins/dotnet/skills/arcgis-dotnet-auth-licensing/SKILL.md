---
name: arcgis-dotnet-auth-licensing
description: Help with ArcGIS Maps SDK for .NET authentication and licensing. Use for API key setup, OAuth or user sign-in, secure secret handling, and choosing an appropriate licensing/configuration approach.
license: MIT
---

Use this skill when the task involves **credentials**, **secure configuration**, or **licensing** for an ArcGIS Maps SDK for .NET app.

## Primary objectives

1. Choose the lightest authentication approach that satisfies the task.
2. Keep secrets out of the repository.
3. Fit credentials into the app's existing configuration model.
4. Make the authentication flow understandable to the next developer.

## Decision guide

Reference `auth-and-licensing-checklist.md`.

Use these defaults:

- If the app only needs access patterns supported by an API key, prefer an API key setup.
- If the app needs user-specific or organization-scoped access, prefer an OAuth or named-user style sign-in flow.
- If the task is unclear, explain the tradeoff and ask for the intended access model.

## OAuth coverage expectations

Reference:

- `auth-and-licensing-checklist.md`
- `windows-and-maui-oauth-patterns.md`

When the task is about **ArcGIS Online OAuth**, cover the right host-specific pattern instead of giving generic sign-in advice:

- **.NET MAUI**:
  - prefer configuring ArcGIS at app startup with `UseArcGISRuntime(config => ...)`
  - use `WebAuthenticator` for the browser-based sign-in flow on supported MAUI platforms
  - on **Windows MAUI**, note that the Esri `MauiSignin` demo uses **WinUIEx.WebAuthenticator** as the Windows-specific bridge while .NET MAUI WebAuthenticator support catches up
  - wire the browser result into ArcGIS through an `IOAuthHandler`
- **Windows packaged apps**:
  - prefer startup configuration with `ArcGISRuntimeEnvironment.Initialize(config => ...)`
  - register the OAuth redirect URI with the packaged app model, typically via protocol activation in the package manifest
  - use a system-browser OAuth authorize handler that returns the authorization code to ArcGIS
- **Windows unpackaged apps**:
  - still use `ArcGISRuntimeEnvironment.Initialize(config => ...)`
  - be explicit that unpackaged apps do **not** get package-manifest protocol registration automatically
  - use a browser callback strategy the app actually owns, such as:
    - a loopback redirect handled by the app
    - a custom URI scheme registered by the installer or deployment process
  - route the callback through a custom OAuth authorize handler instead of pretending the packaged flow applies unchanged

## Implementation rules

- Never commit secrets, API keys, refresh tokens, or client secrets.
- Prefer configuration sources already used in the app, such as:
  - environment variables
  - user secrets for local development
  - platform-secure settings
  - app configuration files that read from secure deployment-time values
- Keep the sign-in and sign-out lifecycle explicit.
- Surface authentication failures instead of swallowing them.
- Keep licensing initialization close to startup and make it easy to find.
- Keep credential persistence explicit. If the app should restore ArcGIS Online sessions, wire `CredentialPersistence` deliberately rather than relying on wishful defaults.
- For ArcGIS Online OAuth, configure `AuthenticationManager.Current.OAuthUserConfigurations` at startup and keep the challenge handler and OAuth handler easy to locate.

## What to produce

- secure configuration plumbing
- auth service wiring that matches the current architecture
- startup initialization for ArcGIS auth or licensing
- developer-facing guidance in touched files when the setup is not obvious

## Example requests

- "Replace the hardcoded ArcGIS API key."
- "Add sign-in support for our ArcGIS organization."
- "Wire licensing into app startup."
- "Make this MAUI app use secure local development secrets."
- "Show the right OAuth setup for packaged and unpackaged Windows."
