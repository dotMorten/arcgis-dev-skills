# ArcGIS Online OAuth patterns for .NET

Use the app type to choose the right OAuth callback strategy. Do not give one Windows answer for all deployment models.

## .NET MAUI

Preferred startup pattern:

- configure ArcGIS in `MauiProgram.cs` with `builder.UseArcGISRuntime(config => ...)`
- register OAuth user configuration and related environment settings during startup
- assign `AuthenticationManager.Current.OAuthHandler` to a platform-aware implementation

Browser flow guidance:

- On iOS and Android, `WebAuthenticator` is the normal browser bridge.
- For **Windows MAUI**, the Esri `MauiSignin` sample uses **WinUIEx.WebAuthenticator** as the Windows-specific bridge for ArcGIS OAuth.
- Keep the redirect URI, client ID, and portal URL in one configuration source instead of scattering them through the app.

Implementation notes drawn from the `MauiSignin` sample:

- use an `IOAuthHandler`
- call the browser authenticator with the ArcGIS `authorizeUri` and `redirectUri`
- feed the returned properties back to ArcGIS
- configure `AuthenticationManager.Current.OAuthUserConfigurations`
- set up credential persistence explicitly if the app should restore signed-in sessions

Relevant sample:

- `Esri/arcgis-maps-sdk-dotnet-demos/src/MauiSignin`

## Windows packaged apps

Preferred startup pattern:

- initialize ArcGIS in app startup with `ArcGISRuntimeEnvironment.Initialize(config => ...)`

OAuth guidance:

- use the system browser
- use a redirect URI the packaged app owns
- for custom URI scheme flows, register the protocol in the package manifest so the app can receive the callback

The Esri MapViewer demo shows this style of thinking:

- an `OAuthUserConfiguration`
- `ArcGISRuntimeEnvironment.Initialize(config => ...)`
- a custom OAuth authorize handler
- a redirect URI that must match the packaged protocol activation setup

## Windows unpackaged apps

Preferred startup pattern:

- initialize ArcGIS in app startup with `ArcGISRuntimeEnvironment.Initialize(config => ...)`

Important distinction:

- unpackaged apps do not automatically get package-manifest protocol registration
- a redirect URI that works for a packaged app may not work unchanged for an unpackaged deployment

Use an app-owned callback strategy such as:

- a loopback redirect handled by the app
- a custom URI scheme registered by installer or deployment setup

Then route the callback through a custom OAuth authorize handler. Be explicit about what external registration or installer work is required.

## Shared rules

- Keep the ArcGIS Online app registration, redirect URI, and runtime configuration aligned.
- Never commit client secrets for public client OAuth flows.
- Keep sign-in, sign-out, and credential reset behavior explicit.
- If the app restores prior credentials, handle expired or revoked credentials by clearing and restarting the auth flow instead of failing silently.
