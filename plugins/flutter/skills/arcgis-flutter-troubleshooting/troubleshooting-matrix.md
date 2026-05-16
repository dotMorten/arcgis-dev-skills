# Troubleshooting matrix for ArcGIS Maps SDK for Flutter

## Symptom: blank map or scene

Check:

- API key, user auth, or licensing setup
- layer, map, or scene load status
- `arcgis_maps_core` installation
- Android minimum SDK and permission configuration
- widget lifecycle timing

## Symptom: interactions stop working

Check:

- tap handling still references the active view or controller
- controllers or state holders are not being recreated unexpectedly
- overlays and layers still exist after screen changes
- selection state is not being cleared unintentionally

## Symptom: slow rendering or memory growth

Check:

- duplicate layer creation
- repeated overlays or repeated async tasks
- leaked listeners, callbacks, or retained controllers
- large datasets rendered without filtering or level-of-detail strategy

## Symptom: offline flow fails

Check:

- file storage path choice
- task status handling
- stale local package cleanup
- auth assumptions during disconnected use
