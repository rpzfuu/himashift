# Changelog

## 2026-04-30 - Archive rescue/testing pass

### Fixed

- Disabled admin public registration.
- Fixed duplicate admin `home` route name for route cache.
- Protected admin kehadiran PATCH route with auth middleware.
- Renamed kehadiran status route to avoid collision with resource route.
- Fixed `Kehadiran::absen()` relationship in both apps.
- Added missing mahasiswa password reset route names.
- Fixed certificate generate form route data.
- Returned certificate PDF as Laravel response.
- Blocked mahasiswa attendance IDOR.
- Fixed attendance button time-window logic.
- Removed debug lines from mahasiswa absensi view.
- Converted invalid admin edit/show routes to 404.
- Added Feature tests for admin and mahasiswa archive flows.
- Configured PHPUnit to use SQLite in-memory.
- Removed npm lockfiles so pnpm lockfiles are the single JS dependency source.
- Changed production log template level from `error` to `warning`.
- Verified local production mode smoke with `APP_ENV=production` and `APP_DEBUG=false`.

### Verified

- Composer audit clean.
- Static lint/view cache pass.
- Route/config/view cache pass.
- CRUD/cascade/PDF/IDOR curl checks pass.
- Production Vite build pass.
- PHPUnit full suite pass in both apps.
