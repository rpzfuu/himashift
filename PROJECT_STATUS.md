# HIMASHIFT Project Status

Last updated: 2026-04-30

## Current State

HIMASHIFT is code/config deploy-ready for a public portfolio deployment.

The earlier archive state is no longer accurate: both apps now have installed dependencies, working `.env` files, production env templates, reproducible pnpm lockfiles, reports, deploy docs, and passing automated tests.

## Verified

- Admin PHPUnit: 12 tests passed, 51 assertions.
- Mahasiswa PHPUnit: 11 tests passed, 32 assertions.
- Composer audit: no advisories.
- `pnpm install --frozen-lockfile`: pass in both apps.
- `pnpm run build`: pass in both apps.
- Route/config/view cache simulation: pass in both apps.
- Local production smoke with `APP_ENV=production` and `APP_DEBUG=false`: pass.
- HTTP CRUD/cascade/PDF/IDOR smoke: pass.
- `package-lock.json` removed; `pnpm-lock.yaml` is the single JS lockfile source.
- Production templates use `LOG_LEVEL=warning`.
- `post-deploy-check.sh` verifies status codes and minimum security headers.

## Remaining External Tasks

These cannot be fully completed until the target hosting/domain exists:

1. L11 browser click-through on production domain.
2. Restore drill from production dump into staging/dummy database.
3. Security header verification after HTTPS is active.

## Deploy Order

1. Buy/setup hosting, domain, and Let's Encrypt SSL.
2. Upload both apps and point document roots to each app's `public/`.
3. Run optimization commands from `DEPLOY.md`.
4. Run `post-deploy-check.sh`; expect header checks to fail until headers are configured.
5. Add security headers in nginx/Apache/control panel.
6. Re-run `post-deploy-check.sh`; all checks must pass.
7. Run L11 browser click-through.
8. Run restore drill before sharing the portfolio URL.
