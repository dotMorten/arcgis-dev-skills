# Authentication and licensing checklist for Flutter apps

## Start with the access model

- **API key**: good when the app only needs key-based ArcGIS location services.
- **User authentication**: good when the app needs organization content, user identity, or user-specific permissions.
- **Licensed deployment**: required for production deployment scenarios; keep the initialization path explicit.

## Configuration guidance

- Keep secrets out of source control.
- Prefer per-environment configuration.
- Use existing secure storage or secrets handling patterns when the app already has them.
- For development, prefer `--dart-define` or ignored config files over hardcoded source constants.

## Startup guidance

- Initialize auth and licensing in one predictable path.
- Fail visibly enough that blank maps and access problems are diagnosable.
- Keep sign-out, reset, or credential clearing behavior explicit.
