# Authentication and access checklist for JavaScript

## Start with the access model

- **API key / browser-safe token**: good when the app only needs supported ArcGIS location service access.
- **User OAuth**: good when the app needs user identity, organization content, or per-user permissions.
- **Backend-assisted access**: good when privileged or server-only credentials must stay off the client.

## JavaScript SDK auth guidance

- For API key setups, prefer a centralized configuration path such as `esriConfig.apiKey`.
- For OAuth, use `OAuthInfo` and `IdentityManager` rather than inventing a parallel browser auth mechanism for ArcGIS resources.
- Keep the portal URL, app ID, redirect URI, and auth namespace aligned across runtime config and portal registration.
- If the app signs users out, destroy credentials explicitly instead of only hiding UI.

## Configuration guidance

- Keep secrets out of source control.
- Prefer environment-specific config.
- Avoid copying API keys into many files when one startup config can own them.
- Be clear about what is safe in a browser bundle and what must stay server-side.

## Practical rule

- **Service access only**: prefer API key-style setup.
- **User content or organization sign-in**: prefer OAuth.
- **Privileged access**: keep it behind a backend you control.
