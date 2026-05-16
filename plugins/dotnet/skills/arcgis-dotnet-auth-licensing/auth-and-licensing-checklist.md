# Authentication and licensing checklist

## Start with the access model

- **API key**: good when the app only needs key-based access to allowed services.
- **User sign-in / OAuth**: good when the app needs user identity, organization content, or per-user permissions.
- **Named user or organization-aware flows**: good when the deployment model depends on authenticated users and organization resources.

## ArcGIS Online OAuth checklist

- Register an `OAuthUserConfiguration` for the ArcGIS Online or portal URL you are targeting.
- Configure startup auth once, in a predictable app initialization path.
- Decide the browser callback strategy based on app type:
  - **MAUI**: `WebAuthenticator`, with the Windows-specific bridge your app actually uses
  - **Windows packaged**: protocol activation registered in the package manifest
  - **Windows unpackaged**: app-owned callback registration such as loopback or installer-registered custom URI scheme
- Keep the redirect URI consistent across:
  - the ArcGIS app registration
  - platform-specific app configuration
  - runtime OAuth handler code
- Use credential persistence deliberately if the app should restore sessions across launches.
- Keep sign-out and credential revocation/reset behavior explicit.

## Configuration guidance

- Keep secrets out of source control.
- Prefer environment-specific configuration.
- Use local developer secrets for local machines when possible.
- Use platform-secure storage or deployment-time secret injection for shipped apps.
- Avoid hardcoding redirect URIs or client identifiers in multiple places when one configuration source can own them.

## Startup guidance

- Initialize auth and licensing in one predictable startup path.
- Fail loudly enough that blank maps and silent permission problems are diagnosable.
- Keep sign-out and credential reset flows explicit.
- For MAUI, prefer `UseArcGISRuntime(config => ...)` for auth/environment setup.
- For non-MAUI apps, prefer `ArcGISRuntimeEnvironment.Initialize(config => ...)`.
