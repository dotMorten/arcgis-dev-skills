# ArcGIS Maps SDK for JavaScript agent plugin

This plugin packages a focused set of agent skills for teams building **JavaScript** and **TypeScript** web applications with the **ArcGIS Maps SDK for JavaScript**.

It is meant to help agents make better choices when you ask them to:

- add the ArcGIS Maps SDK for JavaScript with npm or the CDN
- integrate the SDK cleanly into React, Vue, Angular, Vite, TypeScript, or web-component based apps
- build or refactor `MapView`, `SceneView`, or map component experiences
- wire API key or OAuth-based access safely
- diagnose rendering, bundling, auth, and performance issues in web apps

## Included skills

| Skill | Use it for |
| --- | --- |
| `arcgis-js-solution-setup` | Adding ArcGIS Maps SDK for JavaScript to a web app and creating the first working map or scene |
| `arcgis-js-framework-integration` | React, Vue, Angular, Vite, TypeScript, Calcite, routing, lifecycle, and component-boundary integration |
| `arcgis-js-map-ui` | MapView, SceneView, web components, layers, identify, popups, widgets, and interaction logic |
| `arcgis-js-auth-access` | API keys, OAuth, secure browser configuration, and access-model decisions |
| `arcgis-js-troubleshooting` | Blank maps, asset loading, bundler issues, CORS, auth failures, and performance investigations |

## Install

### GitHub Copilot CLI

From a local checkout of the marketplace repo:

```powershell
copilot plugin marketplace add .
copilot plugin install js@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
copilot plugin marketplace add OWNER/REPO
copilot plugin install js@arcgis-maps-sdk-plugins
```

### Claude

From a local checkout of the marketplace repo:

```powershell
claude plugin marketplace add .
claude plugin install js@arcgis-maps-sdk-plugins
```

From a GitHub repository:

```powershell
claude plugin marketplace add OWNER/REPO
claude plugin install js@arcgis-maps-sdk-plugins
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
copilot plugin install OWNER/REPO:plugins/js
```

## Verify

```powershell
copilot plugin list
copilot
```

Then inside Copilot CLI:

```text
/skills list
/skills info arcgis-js-solution-setup
```

## Example prompts

```text
Use /arcgis-js-solution-setup to add ArcGIS Maps SDK for JavaScript to this Vite app.
```

```text
Use /arcgis-js-map-ui to add identify-on-click with popup state and Calcite-based surrounding UI.
```

```text
Use /arcgis-js-framework-integration to move this ArcGIS map into a reusable React component without breaking view lifecycle.
```

```text
Use /arcgis-js-auth-access to replace the hardcoded API key with a secure browser configuration flow.
```

```text
Use /arcgis-js-troubleshooting to diagnose why the map is blank after switching this app to @arcgis/core imports.
```

## Notes

- The skills prefer the repository's existing framework, bundler, routing, and state-management patterns when they already exist.
- For greenfield work, setup guidance assumes the current ArcGIS Maps SDK for JavaScript line unless you specify a target version or delivery model.
- The JavaScript plugin intentionally focuses on browser delivery, framework integration, and web-application lifecycle concerns rather than mirroring the native SDK skill split.
- Secrets should be kept out of source control. The included skills steer agents toward browser-safe configuration patterns rather than server-only assumptions.
