# Troubleshooting matrix for ArcGIS Maps SDK for Qt

## Symptom: blank map or scene

Check:

- API key, user auth, or licensing setup
- layer, map, or scene load status
- Qt kit, compiler, and SDK integration
- qmake or CMake project configuration
- QML or Widgets lifecycle timing

## Symptom: interactions stop working

Check:

- click or tap handling still references the active view
- backing models or controllers are not being recreated unexpectedly
- overlays and layers still exist after screen changes
- selection state is not being cleared unintentionally

## Symptom: slow rendering or memory growth

Check:

- duplicate layer creation
- repeated overlays or repeated async tasks
- leaked signal connections, callbacks, or retained backing objects
- large datasets rendered without filtering or level-of-detail strategy

## Symptom: offline flow fails

Check:

- file storage path choice
- task status handling
- stale local package cleanup
- auth assumptions during disconnected use
