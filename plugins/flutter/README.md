# ArcGIS Maps SDK for Flutter agent plugin

This plugin packages a focused set of agent skills for teams building **Flutter** applications with the **ArcGIS Maps SDK for Flutter**.

It is meant to help agents make better choices when you ask them to:

- add ArcGIS Maps SDK for Flutter with `dart pub`
- build or refactor `ArcGISMapView` and `ArcGISSceneView` experiences
- wire API key, user authentication, and licensing safely
- implement offline maps and local data workflows
- diagnose rendering, platform configuration, and lifecycle issues in Flutter apps

## Included skills

| Skill | Use it for |
| --- | --- |
| `arcgis-flutter-solution-setup` | Adding ArcGIS Maps SDK for Flutter to a Flutter project and creating the first working map or scene |
| `arcgis-flutter-map-ui` | Flutter widget map UI, identify, overlays, callouts, viewpoint logic, and toolkit widgets |
| `arcgis-flutter-auth-licensing` | API key setup, user authentication, secure configuration, and licensing |
| `arcgis-flutter-offline-workflows` | Offline map areas, local data, mobile map packages, and disconnected workflows |
| `arcgis-flutter-troubleshooting` | Blank maps, package or platform setup issues, auth problems, and performance bugs |

## Install

### GitHub Copilot CLI

From a local checkout of the marketplace repo:

```powershell
copilot plugin marketplace add .
copilot plugin install flutter@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
copilot plugin marketplace add OWNER/REPO
copilot plugin install flutter@arcgis-maps-sdk-plugins
```

### Claude

From a local checkout of the marketplace repo:

```powershell
claude plugin marketplace add .
claude plugin install flutter@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
claude plugin marketplace add OWNER/REPO
claude plugin install flutter@arcgis-maps-sdk-plugins
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
copilot plugin install OWNER/REPO:plugins/flutter
```

## Verify

```powershell
copilot plugin list
copilot
```

Then inside Copilot CLI:

```text
/skills list
/skills info arcgis-flutter-solution-setup
```

## Example prompts

```text
Use /arcgis-flutter-solution-setup to add ArcGIS Maps SDK for Flutter to this app.
```

```text
Use /arcgis-flutter-map-ui to add identify-on-tap with selected-feature state and a popup panel.
```

```text
Use /arcgis-flutter-auth-licensing to remove the hardcoded API key and move it into secure configuration.
```

```text
Use /arcgis-flutter-offline-workflows to add local package loading and offline data handling.
```

```text
Use /arcgis-flutter-troubleshooting to diagnose why the map is blank on Android after upgrading dependencies.
```

## Notes

- The skills prefer the repository's existing Flutter state management, widget structure, and platform-configuration patterns when they already exist.
- For greenfield work, setup guidance assumes the current stable ArcGIS Maps SDK for Flutter line unless you specify a target version.
- Secrets should be kept out of source control. The included skills steer agents toward ignored config, `--dart-define`, or existing secure app configuration patterns.
