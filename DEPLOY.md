# HIMASHIFT Deploy Guide

## Recommended Runtime

- PHP 8.2 or 8.3.
- MySQL/MariaDB with `utf8mb4_unicode_ci`.
- Extensions: `pdo_mysql`, `mbstring`, `openssl`, `tokenizer`, `xml`, `ctype`, `json`, `bcmath`, `fileinfo`, `zip`, and preferably `gd`.

## Pre-Deploy

1. Backup database:

```bash
mysqldump -u DB_USER -p himashift > himashift-predeploy.sql
```

2. Run local checks:

```bash
cd himashift-admin && php artisan test && pnpm run build
cd ../himashift-mahasiswa && php artisan test && pnpm run build
```

3. Prepare `.env` from each `.env.production.example`.
4. Confirm only `pnpm-lock.yaml` is used for JS dependency installs.

## Upload

Upload both app folders to hosting. Point each domain/subdomain document root to the app's `public/` directory:

- Admin domain -> `himashift-admin/public`.
- Mahasiswa domain -> `himashift-mahasiswa/public`.

## Recommended Deploy Order

1. Buy/setup hosting, domain, and Let's Encrypt SSL.
2. Upload both apps and point document roots to each app's `public/`.
3. Run the production commands below.
4. Run `post-deploy-check.sh`.
5. Add security headers if the script reports them missing.
6. Re-run `post-deploy-check.sh` until it passes.
7. Run the L11 browser checklist on the production domain.
8. Run a restore drill into staging before sharing the portfolio URL.

## Production Commands

Run inside each app:

```bash
composer install --optimize-autoloader --no-dev
pnpm install --prod=false
pnpm run build
php artisan key:generate --force
php artisan migrate --force
php artisan config:cache
php artisan route:cache
php artisan view:cache
php artisan event:cache
```

On Linux hosting:

```bash
chmod -R 755 storage bootstrap/cache
```

## Post-Deploy Smoke

Run:

```bash
./post-deploy-check.sh https://admin.example.com https://himashift.example.com
```

Expected:

- Admin `/login`: 200.
- Admin `/home`: 302.
- Mahasiswa `/`: 200.
- Mahasiswa `/anggota`: 200.
- Mahasiswa `/dashboard`: 302.
- Security headers present on both public entry pages:
  - `X-Frame-Options`.
  - `X-Content-Type-Options`.
  - `Strict-Transport-Security`.

Example nginx header config after HTTPS is active:

```nginx
add_header X-Frame-Options "SAMEORIGIN" always;
add_header X-Content-Type-Options "nosniff" always;
add_header Strict-Transport-Security "max-age=31536000; includeSubDomains" always;
```

## Rollback

1. Restore previous uploaded folder backup.
2. Restore DB:

```bash
mysql -u DB_USER -p himashift < himashift-predeploy.sql
```

3. Clear caches:

```bash
php artisan optimize:clear
```
