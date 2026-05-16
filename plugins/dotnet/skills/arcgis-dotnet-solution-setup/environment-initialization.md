# ArcGIS environment initialization for .NET

Do not treat ArcGIS setup as only a package-reference change. The app should have a deliberate startup initialization path.

## .NET MAUI

Prefer:

```csharp
builder.UseArcGISRuntime(config => config
    // Configure authentication, HTTP, and other app-wide behavior here
);
```

Place this in `MauiProgram.cs`, alongside other app-wide startup wiring.

Good uses of this hook:

- register authentication configuration
- configure HTTP behavior
- centralize environment-level ArcGIS settings

## WPF, WinUI, and other non-MAUI .NET apps

Prefer:

```csharp
ArcGISRuntimeEnvironment.Initialize(config => config
    // Configure authentication, HTTP, and other app-wide behavior here
);
```

Place this in the app startup path so it runs once and remains easy to find.

Good uses of this hook:

- add `OAuthUserConfiguration`
- configure HTTP defaults, cache size, or user agent values
- centralize environment-level ArcGIS behavior before views start using the SDK

## Practical rule

- **MAUI**: `UseArcGISRuntime(config => ...)`
- **not MAUI**: `ArcGISRuntimeEnvironment.Initialize(config => ...)`

When the task also includes sign-in, pair this environment initialization with a clearly located `AuthenticationManager` setup so the next developer can trace the whole auth flow without hunting through the app.
