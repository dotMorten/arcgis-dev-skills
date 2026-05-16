# ArcGIS Maps SDK for JavaScript troubleshooting matrix

## Blank or partially rendered map

- missing or duplicated ArcGIS CSS
- map container has no size
- assets or imports not loaded for the chosen npm or CDN integration
- view created before the DOM container exists
- API key, token, or portal-item access failure

## Data or layer failures

- CORS or proxy issues
- unsupported layer source or wrong URL
- OAuth or token scope problems
- service unavailable or blocked by environment config

## Framework or build regressions

- component lifecycle creates duplicate views
- asset resolution changed during bundler migration
- lazy loading or route transitions dispose the view unexpectedly
- module imports changed without matching CSS or component imports

## Performance issues

- too many layers or graphics added eagerly
- expensive watch handlers or repeated queries
- unnecessary re-renders around long-lived ArcGIS objects
- large client-side datasets without appropriate filtering or scale strategy
