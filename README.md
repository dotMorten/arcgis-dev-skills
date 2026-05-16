# ArcGIS Maps SDK agent marketplace

This repository is structured as a **multi-plugin marketplace** so it can grow into a family of agent plugins for different ArcGIS Maps SDKs.

Today it publishes the **.NET**, **Swift**, **Kotlin**, **Qt**, and **Flutter** plugins.

It now includes marketplace manifests for:

- **GitHub Copilot CLI** via `.github/plugin/marketplace.json`
- **Claude** via `.claude-plugin/marketplace.json`
- **Codex / OpenAI Agents plugin discovery** via `.agents/plugins/marketplace.json`

## Install

### GitHub Copilot CLI

From a local checkout:

```powershell
copilot plugin marketplace add .
copilot plugin install dotnet@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
copilot plugin marketplace add https://github.com/dotMorten/arcgis-dev-skills
copilot plugin install dotnet@arcgis-maps-sdk-plugins
```

### Claude

From a local checkout:

```powershell
claude plugin marketplace add .
claude plugin install dotnet@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
claude plugin marketplace add https://github.com/dotMorten/arcgis-dev-skills
claude plugin install dotnet@arcgis-maps-sdk-plugins
```

### Codex

The repository now exposes a Codex-compatible marketplace manifest under `.agents/plugins/marketplace.json`, matching the pattern used by `microsoft/win-dev-skills`.

## Repository layout

```text
.github/plugin/marketplace.json        Marketplace manifest
.claude-plugin/marketplace.json        Claude marketplace manifest
.agents/plugins/marketplace.json       Codex/OpenAI Agents marketplace manifest
plugins/dotnet/                        Published .NET plugin
plugins/swift/                         Published Swift plugin
plugins/kotlin/                        Published Kotlin plugin
plugins/flutter/                       Published Flutter plugin
plugins/qt/                            Published Qt plugin
```

## Published plugins

| Plugin | Status | Notes |
| --- | --- | --- |
| `dotnet` | Available | Skills for WPF, WinUI 3, and .NET MAUI with ArcGIS Maps SDK for .NET |
| `swift` | Available | Skills for SwiftUI and UIKit apps using ArcGIS Maps SDK for Swift |
| `kotlin` | Available | Skills for Android apps using ArcGIS Maps SDK for Kotlin |
| `flutter` | Available | Skills for Flutter apps using ArcGIS Maps SDK for Flutter |
| `qt` | Available | Skills for Qt Quick/QML and Widgets apps using ArcGIS Maps SDK for Qt |

## Plugin details

### .NET plugin

The .NET plugin lives at `plugins/dotnet`.

Included skills:

- `arcgis-dotnet-solution-setup`
- `arcgis-dotnet-map-ui`
- `arcgis-dotnet-auth-licensing`
- `arcgis-dotnet-offline-workflows`
- `arcgis-dotnet-troubleshooting`

See `plugins/dotnet/README.md` for plugin-specific guidance and example prompts.

### Swift plugin

The Swift plugin lives at `plugins/swift`.

Included skills:

- `arcgis-swift-solution-setup`
- `arcgis-swift-map-ui`
- `arcgis-swift-auth-licensing`
- `arcgis-swift-offline-workflows`
- `arcgis-swift-troubleshooting`

See `plugins/swift/README.md` for plugin-specific guidance and example prompts.

### Kotlin plugin

The Kotlin plugin lives at `plugins/kotlin`.

Included skills:

- `arcgis-kotlin-solution-setup`
- `arcgis-kotlin-map-ui`
- `arcgis-kotlin-auth-licensing`
- `arcgis-kotlin-offline-workflows`
- `arcgis-kotlin-troubleshooting`

See `plugins/kotlin/README.md` for plugin-specific guidance and example prompts.

### Qt plugin

The Qt plugin lives at `plugins/qt`.

Included skills:

- `arcgis-qt-solution-setup`
- `arcgis-qt-map-ui`
- `arcgis-qt-auth-licensing`
- `arcgis-qt-offline-workflows`
- `arcgis-qt-troubleshooting`

See `plugins/qt/README.md` for plugin-specific guidance and example prompts.

### Flutter plugin

The Flutter plugin lives at `plugins/flutter`.

Included skills:

- `arcgis-flutter-solution-setup`
- `arcgis-flutter-map-ui`
- `arcgis-flutter-auth-licensing`
- `arcgis-flutter-offline-workflows`
- `arcgis-flutter-troubleshooting`

See `plugins/flutter/README.md` for plugin-specific guidance and example prompts.
