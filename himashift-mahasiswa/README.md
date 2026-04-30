# HIMASHIFT Mahasiswa

Laravel 10 mahasiswa-facing app for the HIMASHIFT archive project.

## Features

- Public login.
- Public anggota list.
- Mahasiswa dashboard.
- Profile view.
- Attendance submit.
- Event list.
- Certificate PDF generation.

## Tech Stack

- PHP 8.1+.
- Laravel 10.
- MySQL/MariaDB.
- Bootstrap/Vite.
- TCPDF.

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

Any seeded NIM uses password `12345678` in the restored archive DB.

Example:

- NIM: `F1E120002`.
- Password: `12345678`.

## Tests

```bash
php artisan test
```

The test suite uses SQLite in-memory.
