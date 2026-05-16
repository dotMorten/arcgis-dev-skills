# ArcGIS Maps SDK agent marketplace

This repository is structured as a **multi-plugin marketplace** so it can grow into a family of agent plugins for different ArcGIS Maps SDKs.

Today it publishes the **.NET** plugin. The repository layout also reserves space for future plugins targeting **Swift**, **Kotlin**, **Flutter**, and **Qt**.

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
plugins/swift/                         Reserved for future Swift plugin
plugins/kotlin/                        Reserved for future Kotlin plugin
plugins/flutter/                       Reserved for future Flutter plugin
plugins/qt/                            Reserved for future Qt plugin
```

## Published plugins

| Plugin | Status | Notes |
| --- | --- | --- |
| `dotnet` | Available | Skills for WPF, WinUI 3, and .NET MAUI with ArcGIS Maps SDK for .NET |
| `swift` | Planned | Placeholder directory only |
| `kotlin` | Planned | Placeholder directory only |
| `flutter` | Planned | Placeholder directory only |
| `qt` | Planned | Placeholder directory only |

## .NET plugin

The current plugin lives at `plugins/dotnet`.

Included skills:

- `arcgis-dotnet-solution-setup`
- `arcgis-dotnet-map-ui`
- `arcgis-dotnet-auth-licensing`
- `arcgis-dotnet-offline-workflows`
- `arcgis-dotnet-troubleshooting`

See `plugins/dotnet/README.md` for plugin-specific guidance and example prompts.
