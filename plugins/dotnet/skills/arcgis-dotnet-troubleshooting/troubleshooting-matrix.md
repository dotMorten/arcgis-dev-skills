# Troubleshooting matrix

## Symptom: blank map or scene

Check:

- credentials and licensing setup
- layer or map load status
- basemap or operational layer initialization
- whether the control is created before the page is ready
- navigation and disposal timing

## Symptom: feature interactions stop working

Check:

- event handlers were reattached after navigation
- overlays or layers are still present
- selected state is being cleared unexpectedly
- identify logic still points at the active control

## Symptom: slow rendering or memory growth

Check:

- duplicate layer creation
- repeated graphics overlay rebuilds
- leaked event subscriptions
- large datasets rendered without throttling, filtering, or level-of-detail strategy

## Symptom: offline flow fails

Check:

- local storage path choice
- job status handling
- stale package cleanup
- credential assumptions during disconnected use
