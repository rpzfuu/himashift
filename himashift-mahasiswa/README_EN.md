# HIMASHIFT Mahasiswa

Language: [ID](README.md) | [EN](README_EN.md)

HIMASHIFT Mahasiswa is a Laravel 10 application for public pages, student login, attendance, events, profiles, and PDF certificates.

This documentation is intended for developers and operators who need to run, test, or extend the student-facing application.

## Role In The System

This application uses the same `himashift` database as `himashift-admin` and the desktop application. Student, event, attendance session, and attendance status data are managed from the admin panel, then read or updated according to student permissions.

## Features

- Student login using NIM.
- Public member page.
- Student dashboard.
- Student profile.
- Event list.
- Attendance list.
- Submit attendance for the currently logged-in account.
- Generate PDF certificates.

## Main Routes

- `/`
- `/anggota`
- `/dashboard`
- `/dashboard/profil`
- `/dashboard/absensi`
- `/dashboard/event`
- `/dashboard/sertifikat`

## Tech Stack

- PHP 8.1+.
- Laravel 10.
- MySQL/MariaDB.
- Bootstrap.
- Vite.
- pnpm.
- TCPDF.
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

Build assets and start the local server:

```bash
pnpm run build
php artisan serve --host=127.0.0.1 --port=18082
```

The local application is available at `http://127.0.0.1:18082/`.

## Shared Database

Initial migrations and seeders are run from `himashift-admin`.

For local development, run `php artisan migrate:fresh --seed` from the `himashift-admin` folder, then make sure this app's `.env` points to the same database.

## Demo Account

Seed/demo data uses `12345678` as the student password.

Example account:

- NIM: `F1E120002`
- Password: `12345678`

Demo credentials are intended only for development, testing, or local demos.

## Testing

```bash
php artisan test
```

The test suite uses SQLite in-memory and does not modify the local MySQL database.

Main coverage:

- Student login.
- Protected route redirect.
- Member page.
- Student dashboard.
- Attendance submission.
- IDOR protection for attendance submission.
- PDF certificate generation.
- Invalid routes return 404.

## Developer Notes

- Do not run the mahasiswa seeder for the shared archive database unless seed data changes are being developed.
- Preserve the rule that students can only update their own attendance.
- Run both admin and mahasiswa tests after changing model relationships, shared tables, or the attendance flow.
- Do not commit `.env` files or production credentials.

## Related Documentation

- [../README_EN.md](../README_EN.md): main repository documentation.
- [../ARCHITECTURE.md](../ARCHITECTURE.md): architecture and data flow.
- [../DEPLOY.md](../DEPLOY.md): web deployment guide.
- [../ARCHIVE_NOTES.md](../ARCHIVE_NOTES.md): archive notes and trade-offs.
- [../reports/SUMMARY.md](../reports/SUMMARY.md): testing summary.
