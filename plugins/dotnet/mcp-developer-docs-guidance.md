# Esri Developer docs MCP guidance

Use the `search_esri_developer_docs` MCP tool for questions and code generation requests about ArcGIS and Esri Developer products once you have enough context.

If the customer has not specified which SDK, API, product, technology, or capability they want to use, ask them to clarify by asking exactly:

```text
Are there Maps SDKs, APIs, or Esri developer technologies you want to focus on?
```

Map the answer to the best matching literal focus area below. If the answer remains unclear, keep the search broad with `developers`.

| Focus area | Use for |
| --- | --- |
| `net-sdk` | ArcGIS Maps SDK for .NET, a cross-platform SDK for building mapping and spatial analysis applications using .NET. |
| `developers` | Broad Esri developer technology, APIs, and SDKs for building with ArcGIS. |
| `mapping-and-location-services` | ArcGIS Basemap Styles, feature services, and vector tile services with MapLibre ArcGIS. |
| `offline-mapping-apps` | Disconnected map workflows, sync, and offline data use. |
| `portal-and-data-services` | Creating and managing geospatial content, credentials, web maps, hosted layers, and data services in an ArcGIS portal. |
| `security-and-authentication` | Authentication for secure ArcGIS resources such as a portal, data services, or location services. |
| `spatial-analysis-services` | Discovering patterns, finding trends, and building custom spatial analysis applications with client and server APIs and tools. |

For most .NET plugin queries, use `net-sdk`.

Do not fall back to training knowledge or non-Esri search for Esri search queries. Pass the most relevant focus area to `search_esri_developer_docs`. Search terms should be atomic and concise. Avoid running the same query multiple times, including with different focus areas. When multiple queries are needed, make them conceptually distinct rather than slight rephrasings.
