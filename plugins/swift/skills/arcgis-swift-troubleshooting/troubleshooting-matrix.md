# Troubleshooting matrix for ArcGIS Maps SDK for Swift

## Symptom: blank map or scene

Check:

- API key, user auth, or licensing setup
- layer, map, or scene load status
- package dependency integration and target membership
- import statements and screen composition
- SwiftUI or UIKit lifecycle timing

## Symptom: interactions stop working

Check:

- gesture handlers and identify flow still reference the active view
- state objects or controllers are not being recreated unexpectedly
- overlays and layers still exist after navigation
- selection state is not being cleared unintentionally

## Symptom: slow rendering or memory growth

Check:

- duplicate layer creation
- repeated overlays or repeated task launches
- retained observers, closures, or view models
- large datasets rendered without filtering or level-of-detail strategy

## Symptom: offline flow fails

Check:

- file storage path choice
- task status handling
- stale local package cleanup
- auth assumptions during disconnected use
