# ArcGIS Maps SDK for .NET agent plugin

This plugin packages a focused set of agent skills for teams building **WPF**, **WinUI 3**, and **.NET MAUI** applications with the **ArcGIS Maps SDK for .NET**.

It is meant to help Copilot make better choices when you ask it to:

- scaffold ArcGIS-enabled .NET apps
- add or refactor `MapView` and `SceneView` features
- wire authentication and licensing safely
- implement offline map workflows
- diagnose rendering, performance, and lifecycle issues

## Included skills

| Skill | Use it for |
| --- | --- |
| `arcgis-dotnet-solution-setup` | Creating or upgrading ArcGIS Maps SDK for .NET app structure |
| `arcgis-dotnet-map-ui` | MapView, SceneView, layers, identify, callouts, overlays, and MVVM-friendly map UI work |
| `arcgis-dotnet-auth-licensing` | API keys, OAuth, secure configuration, and licensing decisions |
| `arcgis-dotnet-offline-workflows` | Mobile map packages, geodatabases, sync, and disconnected workflows |
| `arcgis-dotnet-troubleshooting` | Blank maps, load failures, threading issues, performance, and memory investigations |

## Install

### GitHub Copilot CLI

From a local checkout of the marketplace repo:

```powershell
copilot plugin marketplace add .
copilot plugin install dotnet@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
copilot plugin marketplace add OWNER/REPO
copilot plugin install dotnet@arcgis-maps-sdk-plugins
```

### Claude

From a local checkout of the marketplace repo:

```powershell
claude plugin marketplace add .
claude plugin install dotnet@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
claude plugin marketplace add OWNER/REPO
claude plugin install dotnet@arcgis-maps-sdk-plugins
```

### Codex

This repository includes a Codex/OpenAI Agents marketplace manifest under `.agents/plugins/marketplace.json` so the plugin can be discovered from the same repo layout used by `microsoft/win-dev-skills`.

### Direct install

Direct installs still work today, but Copilot CLI warns that marketplace installs are the long-term path.

From this plugin folder:

```powershell
copilot plugin install .
```

From a GitHub subdirectory:

```powershell
copilot plugin install OWNER/REPO:plugins/dotnet
```

## Verify

```powershell
copilot plugin list
copilot
```

Then inside Copilot CLI:

```text
/skills list
/skills info arcgis-dotnet-solution-setup
```

## Sample search tool

This repository includes `.\arcgis-dotnet-search`, a small CLI that searches embedded ArcGIS Maps SDK for .NET runtime samples, toolkit sample apps, and demo apps.

```powershell
dotnet run --project .\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- search "identify feature popup" --platform winui
dotnet run --project .\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- get runtime-winui-wmsidentify
```

Use it to ground implementation choices in real ArcGIS sample code before writing map, auth, offline, or toolkit UI changes.

## Esri Developer docs MCP server

The plugin includes the `arcgis-devexp` MCP server. The .NET skills reference `.\mcp-developer-docs-guidance.md`, which tells agents to use `search_esri_developer_docs` for ArcGIS and Esri Developer documentation lookups, prefer the `net-sdk` focus area for most .NET work, and ask the required clarification question when the target Esri SDK, API, product, technology, or capability is unclear.

## Example prompts

```text
Use /arcgis-dotnet-solution-setup to add ArcGIS Maps SDK for .NET to this WinUI app.
```

```text
Use /arcgis-dotnet-map-ui to add identify-on-tap with a callout and MVVM-friendly state handling.
```

```text
Use /arcgis-dotnet-auth-licensing to replace the hardcoded API key with a secure configuration flow.
```

```text
Use /arcgis-dotnet-offline-workflows to add offline map area download and sync support.
```

```text
Use /arcgis-dotnet-troubleshooting to diagnose why the map renders blank after navigation.
```

## Notes

- The skills prefer the repository's existing architecture and package versions when they already exist.
- For greenfield work, the setup guidance assumes the latest stable ArcGIS Maps SDK for .NET line unless you specify a target version.
- Secrets should be kept out of source control. The included skills explicitly steer Copilot toward secure configuration patterns.
