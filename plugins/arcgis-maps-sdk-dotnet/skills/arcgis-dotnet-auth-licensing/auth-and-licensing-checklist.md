# Authentication and licensing checklist

## Start with the access model

- **API key**: good when the app only needs key-based access to allowed services.
- **User sign-in / OAuth**: good when the app needs user identity, organization content, or per-user permissions.
- **Named user or organization-aware flows**: good when the deployment model depends on authenticated users and organization resources.

## Configuration guidance

- Keep secrets out of source control.
- Prefer environment-specific configuration.
- Use local developer secrets for local machines when possible.
- Use platform-secure storage or deployment-time secret injection for shipped apps.

## Startup guidance

- Initialize auth and licensing in one predictable startup path.
- Fail loudly enough that blank maps and silent permission problems are diagnosable.
- Keep sign-out and credential reset flows explicit.
