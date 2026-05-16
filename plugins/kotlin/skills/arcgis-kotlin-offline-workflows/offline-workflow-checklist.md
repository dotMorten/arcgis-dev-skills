# Offline workflow checklist for Kotlin apps

## Questions to answer

- What content must be available with no network?
- Is the data read-only or editable?
- How should local content be refreshed or invalidated?
- Where should files live under scoped storage?
- What should happen when a sync partially fails?

## Implementation expectations

- explicit download state
- retry-friendly task handling where appropriate
- local content discovery on launch
- safe cleanup of outdated packages and temporary artifacts
- clear UI for stale data, sync conflicts, and missing connectivity

## Common failure sources

- assuming online auth remains available when the app is offline
- not reopening local content correctly after app restart
- mixing temporary and durable storage locations
- not surfacing task or sync errors to the UI
