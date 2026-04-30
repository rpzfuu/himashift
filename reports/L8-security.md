# L8 - Security Surface Test

## Passed

| Check | Result |
| --- | --- |
| POST without CSRF | 419 |
| POST with wrong/foreign NIM attendance | 403 |
| `/register` disabled | 404 |
| `/.env` direct request | 404 |
| `/.git/HEAD` direct request | 404 |
| `/storage/logs/laravel.log` direct request | 404 |
| XSS in mahasiswa name displayed escaped by Blade | PASS |
| SQL injection login payload did not authenticate | PASS, redirected back to login |

## Cookies

Observed locally:

- Session cookies include `HttpOnly`.
- Session cookies include `SameSite=Lax`.
- `Secure` is absent locally because HTTP was used. Production `.env.production.example` sets `SESSION_SECURE_COOKIE=true`.

## Headers

Not present in local Laravel responses:

- `X-Frame-Options`.
- `X-Content-Type-Options`.
- `Strict-Transport-Security`.
- `Content-Security-Policy`.

Klasifikasi: deploy hardening. Untuk shared hosting, tambahkan header ini di nginx/Apache/control panel jika memungkinkan.
`post-deploy-check.sh` sekarang memverifikasi tiga header minimum setelah deploy HTTPS.

## Dependency Security

`pnpm audit` reports Vite/esbuild dev-server advisories. Production build succeeds and dev server should not be exposed publicly.
