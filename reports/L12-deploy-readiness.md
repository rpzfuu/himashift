# L12 - Production Readiness + Deploy Simulation

## Optimization Commands

Executed in both apps:

```bash
php artisan route:cache
php artisan config:cache
php artisan view:cache
pnpm run build
```

Result: PASS.

Caches were cleared after simulation so local development stays normal.

## Production Mode Local Smoke

Executed with `APP_ENV=production` and `APP_DEBUG=false`.

| App | Path | Expected | Actual |
| --- | --- | --- | --- |
| Admin | `/login` | 200 | 200 |
| Admin | `/home` | 302 | 302 |
| Mahasiswa | `/` | 200 | 200 |
| Mahasiswa | `/anggota` | 200 | 200 |
| Mahasiswa | `/dashboard` | 302 | 302 |
| Mahasiswa | `/password/reset` | 200 | 200 |
| Mahasiswa | `/register` | 404 | 404 |

## Production Env Templates

Created:

- `himashift-admin/.env.production.example`.
- `himashift-mahasiswa/.env.production.example`.

## Deploy Docs/Scripts

Created:

- `DEPLOY.md`.
- `deploy.sh`.
- `post-deploy-check.sh`.

## Production Notes

- Set `APP_DEBUG=false`.
- Set HTTPS `APP_URL`.
- Use `LOG_LEVEL=warning` so warning-level audit signals are retained without enabling verbose debug logging.
- Set `SESSION_SECURE_COOKIE=true`.
- Prefer PHP 8.2/8.3 for Laravel 10.
- Enable `gd` if certificate design later uses images.
- Add security headers at web server/control panel layer.
