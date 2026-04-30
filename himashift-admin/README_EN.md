# HIMASHIFT Admin

Language: [ID](README.md) | [EN](README_EN.md)

HIMASHIFT Admin is a Laravel 10 application for managing HIMASHIFT core data, including students, events, attendance sessions, and attendance status.

This documentation is intended for developers and operators who need to run, test, or extend the admin panel.

## Role In The System

The admin panel is the main source for migrations, seeding, and shared data management. This application uses the same database as `himashift-mahasiswa` and `himashift-visualstudio`.

## Features

- Admin login using `users.name`.
- Mahasiswa CRUD.
- Event CRUD.
- Absen CRUD.
- Attendance status management.
- Creation of `kehadiran` records when an attendance session is created.

## Main Routes

- `/login`
- `/home/mahasiswa`
- `/home/event`
- `/home/absen`
- `/home/kehadiran`

## Tech Stack

- PHP 8.1+.
- Laravel 10.
- MySQL/MariaDB.
- Bootstrap.
- Vite.
- pnpm.
- PHPUnit.

## Development Setup

Install dependencies:

```bash
composer install
pnpm install --frozen-lockfile
```

Prepare the environment:

```bash
cp .env.example .env
php artisan key:generate
```

Configure the database in `.env`:

```env
DB_CONNECTION=mysql
DB_HOST=127.0.0.1
DB_PORT=3306
DB_DATABASE=himashift
DB_USERNAME=root
DB_PASSWORD=
```

Run migrations and seeders:

```bash
php artisan migrate:fresh --seed
```

Build assets and start the local server:

```bash
pnpm run build
php artisan serve --host=127.0.0.1 --port=18081
```

The local admin panel is available at `http://127.0.0.1:18081/login`.

## Shared Database

`himashift-admin` is the source for the initial migrations and seeders for the `himashift` database.

Developers running all applications locally should point the `himashift-mahasiswa` `.env` file to the same database. The mahasiswa app seeder does not need to be run for the shared archive database.

## Demo Account

- Username: `admin`
- Password: `12345678`

Demo credentials are intended only for development, testing, or local demos.

## Testing

```bash
php artisan test
```

The test suite uses SQLite in-memory and does not modify the local MySQL database.

Main coverage:

- Admin login.
- Register disabled.
- Protected route redirect.
- Mahasiswa CRUD.
- Event CRUD.
- Absen CRUD.
- Cascade delete for absen/kehadiran.
- Attendance status updates.
- Invalid edit routes return 404.

## Developer Notes

- Preserve schema compatibility with `himashift-mahasiswa` and the WinForms desktop app.
- Run `php artisan route:cache` or a cache simulation before deployment when changing routes.
- Run both admin and mahasiswa tests after changing shared database models or relationships.
- Do not commit `.env` files or production credentials.

## Related Documentation

- [../README_EN.md](../README_EN.md): main repository documentation.
- [../ARCHITECTURE.md](../ARCHITECTURE.md): architecture and data flow.
- [../DEPLOY.md](../DEPLOY.md): web deployment guide.
- [../ARCHIVE_NOTES.md](../ARCHIVE_NOTES.md): archive notes and trade-offs.
- [../reports/SUMMARY.md](../reports/SUMMARY.md): testing summary.
