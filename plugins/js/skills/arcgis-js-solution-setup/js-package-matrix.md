# ArcGIS Maps SDK for JavaScript package matrix

Choose the delivery model that matches the app.

| App style | Typical setup |
| --- | --- |
| Simple HTML/JavaScript page | ArcGIS CDN with `<script type="module" src="https://js.arcgis.com/...">` |
| Modern npm app | `@arcgis/core` |
| Web component-driven npm app | `@arcgis/map-components` plus `@arcgis/core` |
| Calcite-based UI | `@esri/calcite-components` alongside ArcGIS packages |

## Supporting guidance

- For npm apps, keep ArcGIS packages on a consistent version line.
- For component-based apps, ensure the ArcGIS CSS and component imports are loaded exactly once.
- For CDN apps, keep the HTML and body sizing explicit so the map can render.
- Prefer the repository's existing framework integration patterns over inventing a new wrapper layer.
