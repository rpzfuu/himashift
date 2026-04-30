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
php artisan migrate:fresh --seed
pnpm run build
php artisan serve
```

This app is the source for initial database seeding. The mahasiswa app must point to the same database and should not run its own seeder for the shared archive DB.

## Default Credential

- Username: `admin`.
- Password: `12345678`.

## Tests

```bash
php artisan test
```

The test suite uses SQLite in-memory.

For the full project README, see `../README.md`.
