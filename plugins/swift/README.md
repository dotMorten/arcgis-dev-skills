# ArcGIS Maps SDK for Swift agent plugin

This plugin packages a focused set of agent skills for teams building **SwiftUI** and **UIKit** applications with the **ArcGIS Maps SDK for Swift**.

It is meant to help agents make better choices when you ask them to:

- add ArcGIS Maps SDK for Swift with Swift Package Manager
- build or refactor `MapView` and `SceneView` experiences
- wire API key, user authentication, and licensing safely
- implement offline map and sync workflows
- diagnose rendering, lifecycle, and concurrency issues in Swift apps

## Included skills

| Skill | Use it for |
| --- | --- |
| `arcgis-swift-solution-setup` | Adding ArcGIS Maps SDK for Swift to a project and creating the first working map or scene |
| `arcgis-swift-map-ui` | SwiftUI or UIKit map UI, identify, overlays, callouts, viewpoint logic, and toolkit controls |
| `arcgis-swift-auth-licensing` | API key setup, user authentication, secure configuration, and licensing |
| `arcgis-swift-offline-workflows` | Offline map areas, mobile map packages, local data, and sync workflows |
| `arcgis-swift-troubleshooting` | Blank maps, package integration problems, task failures, concurrency bugs, and performance issues |

## Install

### GitHub Copilot CLI

From a local checkout of the marketplace repo:

```powershell
copilot plugin marketplace add .
copilot plugin install swift@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
copilot plugin marketplace add OWNER/REPO
copilot plugin install swift@arcgis-maps-sdk-plugins
```

### Claude

From a local checkout of the marketplace repo:

```powershell
claude plugin marketplace add .
claude plugin install swift@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
claude plugin marketplace add OWNER/REPO
claude plugin install swift@arcgis-maps-sdk-plugins
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
copilot plugin install OWNER/REPO:plugins/swift
```

## Verify

```powershell
copilot plugin list
copilot
```

Then inside Copilot CLI:

```text
/skills list
/skills info arcgis-swift-solution-setup
```

## Example prompts

```text
Use /arcgis-swift-solution-setup to add ArcGIS Maps SDK for Swift to this SwiftUI app.
```

```text
Use /arcgis-swift-map-ui to add identify-on-tap with selection state and a bottom sheet.
```

```text
Use /arcgis-swift-auth-licensing to remove the hardcoded API key and move it into secure configuration.
```

```text
Use /arcgis-swift-offline-workflows to add offline map area download and reopen local content on launch.
```

```text
Use /arcgis-swift-troubleshooting to diagnose why the map is blank after navigating back to this view.
```

## Notes

- The skills prefer the repository's existing SwiftUI, UIKit, and concurrency patterns when they already exist.
- For greenfield work, setup guidance assumes Swift Package Manager with the current stable ArcGIS Maps SDK for Swift line unless you specify a target version.
- Secrets should be kept out of source control. The included skills steer agents toward xcconfig, secrets files, environment-specific configuration, or existing secure app configuration patterns.
