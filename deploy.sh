#!/usr/bin/env bash
set -euo pipefail

apps=("himashift-admin" "himashift-mahasiswa")

for app in "${apps[@]}"; do
  echo "==> Deploy prep: ${app}"
  cd "${app}"

  composer install --optimize-autoloader --no-dev
  pnpm install --prod=false
  pnpm run build

  php artisan config:cache
  php artisan route:cache
  php artisan view:cache
  php artisan event:cache
  php artisan optimize

  chmod -R 755 storage bootstrap/cache || true
  cd ..
done

echo "Deploy prep complete."
