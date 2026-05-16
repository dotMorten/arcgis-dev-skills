# ArcGIS Maps SDK for Qt agent plugin

This plugin packages a focused set of agent skills for teams building **Qt Quick/QML** and **Qt Widgets** applications with the **ArcGIS Maps SDK for Qt**.

It is meant to help agents make better choices when you ask them to:

- add ArcGIS Maps SDK for Qt to a Qt project
- build or refactor `MapView` and `SceneView` experiences in QML or widgets
- wire API key, user authentication, and licensing safely
- implement offline maps and local data workflows
- diagnose rendering, kit, build-system, and lifecycle issues in Qt apps

## Included skills

| Skill | Use it for |
| --- | --- |
| `arcgis-qt-solution-setup` | Adding ArcGIS Maps SDK for Qt to a Qt project and creating the first working map or scene |
| `arcgis-qt-map-ui` | Qt Quick/QML or Widgets map UI, identify, callouts, overlays, viewpoint logic, and toolkit controls |
| `arcgis-qt-auth-licensing` | API key setup, user authentication, secure configuration, and licensing |
| `arcgis-qt-offline-workflows` | Offline map areas, local data, mobile map packages, and sync-like workflows |
| `arcgis-qt-troubleshooting` | Blank maps, kit and SDK integration issues, auth problems, and performance bugs |

## Install

### GitHub Copilot CLI

From a local checkout of the marketplace repo:

```powershell
copilot plugin marketplace add .
copilot plugin install qt@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
copilot plugin marketplace add OWNER/REPO
copilot plugin install qt@arcgis-maps-sdk-plugins
```

### Claude

From a local checkout of the marketplace repo:

```powershell
claude plugin marketplace add .
claude plugin install qt@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
claude plugin marketplace add OWNER/REPO
claude plugin install qt@arcgis-maps-sdk-plugins
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
copilot plugin install OWNER/REPO:plugins/qt
```

## Verify

```powershell
copilot plugin list
copilot
```

Then inside Copilot CLI:

```text
/skills list
/skills info arcgis-qt-solution-setup
```

## Example prompts

```text
Use /arcgis-qt-solution-setup to add ArcGIS Maps SDK for Qt to this Qt Quick app.
```

```text
Use /arcgis-qt-map-ui to add identify-on-click with a callout and selected-feature state.
```

```text
Use /arcgis-qt-auth-licensing to remove the hardcoded API key and move it into secure configuration.
```

```text
Use /arcgis-qt-offline-workflows to add local package loading and offline data handling.
```

```text
Use /arcgis-qt-troubleshooting to diagnose why the map is blank with this Qt Creator kit.
```

## Notes

- The skills prefer the repository's existing Qt Quick, QML, Widgets, C++, and project-configuration patterns when they already exist.
- For greenfield work, setup guidance assumes the current stable ArcGIS Maps SDK for Qt line unless you specify a target version.
- Secrets should be kept out of source control. The included skills steer agents toward config files, environment-specific settings, or existing secure app configuration patterns.
