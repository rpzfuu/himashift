# HIMASHIFT Admin

Laravel 10 admin panel for the HIMASHIFT archive project.

## Features

- Admin login with `users.name`.
- Mahasiswa CRUD.
- Event CRUD.
- Absen CRUD.
- Kehadiran status management.

## Tech Stack

- PHP 8.1+.
- Laravel 10.
- MySQL/MariaDB.
- Bootstrap/Vite.

## Local Setup

```bash
composer install
pnpm install
cp .env.example .env
php artisan key:generate
php artisan migrate --seed
pnpm run build
php artisan serve
```

## Default Credential

- Username: `admin`.
- Password: `12345678`.

## Tests

```bash
php artisan test
```

The test suite uses SQLite in-memory.
