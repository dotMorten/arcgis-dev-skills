# Offline workflow checklist

## Questions to answer

- What data must be available with no network?
- Is the content read-only or editable?
- How is offline content versioned or refreshed?
- Where should files live on each platform?
- What should happen when sync partially fails?

## Implementation expectations

- explicit download state
- resumable or retry-friendly job handling where available
- local content discovery on app startup
- safe cleanup of outdated packages and temp artifacts
- clear UX for stale data, sync conflicts, and missing connectivity

## Common failure sources

- assuming online authentication still exists when offline
- not reopening local content correctly after app restart
- mixing temporary and durable storage locations
- not reporting job or sync errors back to the UI
