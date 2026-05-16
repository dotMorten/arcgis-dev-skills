# ArcGIS Maps SDK for Kotlin agent plugin

This plugin packages a focused set of agent skills for teams building **Android** applications with the **ArcGIS Maps SDK for Kotlin**.

It is meant to help agents make better choices when you ask them to:

- add ArcGIS Maps SDK for Kotlin with Gradle
- build or refactor Compose-based `MapView` and `SceneView` experiences
- wire API key, user authentication, and licensing safely
- implement offline maps and sync workflows
- diagnose rendering, lifecycle, and concurrency issues in Kotlin apps

## Included skills

| Skill | Use it for |
| --- | --- |
| `arcgis-kotlin-solution-setup` | Adding ArcGIS Maps SDK for Kotlin to an Android project and creating the first working map or scene |
| `arcgis-kotlin-map-ui` | Compose-first map UI, identify, overlays, callouts, viewpoint logic, and toolkit components |
| `arcgis-kotlin-auth-licensing` | API key setup, user authentication, secure configuration, and licensing |
| `arcgis-kotlin-offline-workflows` | Offline map areas, mobile map packages, local storage, and sync workflows |
| `arcgis-kotlin-troubleshooting` | Blank maps, Gradle setup issues, task failures, auth problems, and performance bugs |

## Install

### GitHub Copilot CLI

From a local checkout of the marketplace repo:

```powershell
copilot plugin marketplace add .
copilot plugin install kotlin@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
copilot plugin marketplace add OWNER/REPO
copilot plugin install kotlin@arcgis-maps-sdk-plugins
```

### Claude

From a local checkout of the marketplace repo:

```powershell
claude plugin marketplace add .
claude plugin install kotlin@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
claude plugin marketplace add OWNER/REPO
claude plugin install kotlin@arcgis-maps-sdk-plugins
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
copilot plugin install OWNER/REPO:plugins/kotlin
```

## Verify

```powershell
copilot plugin list
copilot
```

Then inside Copilot CLI:

```text
/skills list
/skills info arcgis-kotlin-solution-setup
```

## Example prompts

```text
Use /arcgis-kotlin-solution-setup to add ArcGIS Maps SDK for Kotlin to this Android app.
```

```text
Use /arcgis-kotlin-map-ui to add identify-on-tap with selection state and a bottom sheet.
```

```text
Use /arcgis-kotlin-auth-licensing to remove the hardcoded API key and move it into secure configuration.
```

```text
Use /arcgis-kotlin-offline-workflows to add offline map area download and reopen local content on launch.
```

```text
Use /arcgis-kotlin-troubleshooting to diagnose why the map is blank after this screen is recreated.
```

## Notes

- The skills prefer the repository's existing Android, Compose, ViewModel, and coroutine patterns when they already exist.
- For greenfield work, setup guidance assumes Gradle Kotlin DSL and the current stable ArcGIS Maps SDK for Kotlin line unless you specify a target version.
- Secrets should be kept out of source control. The included skills steer agents toward local properties, ignored config files, environment-specific configuration, or existing secure app configuration patterns.
