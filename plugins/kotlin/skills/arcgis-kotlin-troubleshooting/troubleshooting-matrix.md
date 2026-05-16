# Troubleshooting matrix for ArcGIS Maps SDK for Kotlin

## Symptom: blank map or scene

Check:

- API key, user auth, or licensing setup
- layer, map, or scene load status
- Gradle repository and dependency integration
- manifest permissions and GL feature declarations
- Compose lifecycle timing

## Symptom: interactions stop working

Check:

- input handling and identify flow still reference the active screen state
- view models or state holders are not being recreated unexpectedly
- overlays and layers still exist after navigation
- selection state is not being cleared unintentionally

## Symptom: slow rendering or memory growth

Check:

- duplicate layer creation
- repeated overlays or repeated coroutine launches
- retained observers, callbacks, or state containers
- large datasets rendered without filtering or level-of-detail strategy

## Symptom: offline flow fails

Check:

- file storage path choice
- task status handling
- stale local package cleanup
- auth assumptions during disconnected use
