# arcgis-dotnet-search

Native-AOT-friendly CLI for searching ArcGIS Maps SDK for .NET examples indexed from:

- `Esri/arcgis-runtime-samples-dotnet` (`runtime`)
- `Esri/arcgis-maps-sdk-dotnet-toolkit` sample apps (`toolkit`)
- `Esri/arcgis-runtime-demos-dotnet` (`demo`)

## Build

```powershell
dotnet build src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -c Release
```

## Usage

```text
arcgis-dotnet-search search "<query>" ["<query2>" ...] [--max N] [--source runtime|toolkit|demo] [--platform wpf|winui|maui]
arcgis-dotnet-search get <id> [<id2> ...]
arcgis-dotnet-search list [--source runtime|toolkit|demo] [--platform wpf|winui|maui]
arcgis-dotnet-search debug "<query>"
arcgis-dotnet-search update-index [--output path] [--samples path] [--toolkit path] [--demos path] [--workdir path] [--keep]
```

`search` returns compact IDs. Use `get` to retrieve the embedded XAML/C# snippet, source path, keywords, and relevant APIs.

## Updating `Data\samples.json`

`update-index` regenerates the embedded index. By default it clones the three source repos into a temporary folder, writes `Data\samples.json`, and deletes the temp folder.

```powershell
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- update-index
```

To regenerate from existing local clones:

```powershell
dotnet run --project src\tools\arcgis-dotnet-search\arcgis-dotnet-search.csproj -- update-index `
  --samples E:\GitHub\Esri\arcgis-runtime-samples-dotnet `
  --toolkit E:\GitHub\Esri\arcgis-toolkit-dotnet5 `
  --demos E:\GitHub\Esri\arcgis-runtime-demos-dotnet
```

Use `--output <path>` to write somewhere other than this tool's `Data\samples.json`, and `--keep` to preserve temporary clones for inspection.
