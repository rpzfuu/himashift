# HIMASHIFT

Language: [ID](README.md) | [EN](README_EN.md)

HIMASHIFT is an archive application for the Information Systems Student Association. This repository contains two Laravel web applications and one Windows Forms desktop application that share the same MySQL database.

This documentation is intended for technical users, operators, and developers who want to run, test, extend, or redistribute HIMASHIFT.

## Project Status

HIMASHIFT is maintained as an archive project. The main structure, legacy coding style, and historical behavior are preserved, while fatal bugs, security issues, and data integrity bugs that affect usage have been fixed.

Last verification: 2026-04-30.

- Admin PHPUnit: 12 tests passed, 51 assertions.
- Mahasiswa PHPUnit: 11 tests passed, 32 assertions.
- Desktop xUnit: 13 tests passed.
- Desktop EXE smoke: the application starts and opens the `beranda` window.
- Composer audit: no advisories.
- `pnpm install --frozen-lockfile`: passes in both Laravel apps.
- `pnpm run build`: passes in both Laravel apps.
- Route/config/view cache simulation: passes in both Laravel apps.
- Local production smoke with `APP_ENV=production` and `APP_DEBUG=false`: passes.
- HTTP CRUD/cascade/PDF/IDOR smoke: passes.

The latest technical status is documented in [PROJECT_STATUS.md](PROJECT_STATUS.md).

## Repository Components

```text
himashift/
|-- himashift-admin/        # Laravel admin panel
|-- himashift-mahasiswa/    # Laravel student-facing and public app
|-- himashift-visualstudio/ # Windows Forms desktop app
|-- reports/                # L1-L12 testing reports
|-- DEPLOY.md               # Web deployment guide
|-- ARCHITECTURE.md         # Technical architecture
|-- ARCHIVE_NOTES.md        # Archive notes and trade-offs
|-- CHANGELOG.md            # Rescue/testing change history
`-- PROJECT_STATUS.md       # Latest repository status
```

## Applications

### HIMASHIFT Admin

The admin panel is used to manage core organization and attendance data.

Main features:

- Admin login.
- Mahasiswa CRUD.
- Event CRUD.
- Absen CRUD.
- View attendance records per student.
- Update student attendance status.

Main routes:

- `/login`
- `/home/mahasiswa`
- `/home/event`
- `/home/absen`
- `/home/kehadiran`

App-specific documentation is available in [himashift-admin/README_EN.md](himashift-admin/README_EN.md).

### HIMASHIFT Mahasiswa

The student-facing app provides public pages, student dashboards, attendance, events, and certificates.

Main features:

- Student login using NIM.
- Public member page.
- Student dashboard.
- Student profile.
- Event list.
- Attendance list.
- Submit own attendance.
- Generate PDF certificates.

Main routes:

- `/`
- `/anggota`
- `/dashboard`
- `/dashboard/profil`
- `/dashboard/absensi`
- `/dashboard/event`
- `/dashboard/sertifikat`

App-specific documentation is available in [himashift-mahasiswa/README_EN.md](himashift-mahasiswa/README_EN.md).

### HIMASHIFT Desktop

The Windows Forms desktop application is provided as an archive/local demo artifact for Windows x64.

Release details:

- Target: `.NET 6.0-windows`.
- Runtime: Windows x64.
- Published EXE: `himashift-visualstudio/bin/Release/net6.0-windows/win-x64/publish/HIMASHIFT.exe`.
- Build: self-contained single-file.
- Database: MySQL `himashift`.

Desktop-specific documentation is available in [himashift-visualstudio/README_EN.md](himashift-visualstudio/README_EN.md).

## Data Architecture

The two web applications and the desktop application use the same database named `himashift`.

```text
himashift-admin        himashift-mahasiswa        HIMASHIFT Desktop
       |                       |                         |
       +----------+------------+-------------------------+
                  |
              MySQL DB
              himashift
```

Core tables:

- `users`
- `mahasiswa`
- `divisi`
- `mahasiswa_divisi`
- `event`
- `absen`
- `kehadiran`

Main flow:

1. Admin creates student and division data.
2. Admin creates attendance sessions.
3. The system creates `kehadiran` rows for all students in the attendance session.
4. Students log in and open the attendance page.
5. Students submit their own attendance.
6. Admin reviews or updates attendance status.
7. Students generate PDF certificates from the certificate page.

More architecture details are available in [ARCHITECTURE.md](ARCHITECTURE.md).

## Tech Stack

Laravel web apps:

- PHP 8.1+.
- Laravel 10.
- MySQL/MariaDB.
- Bootstrap.
- Vite.
- pnpm.
- TCPDF for PDF certificates.
- PHPUnit for automated tests.

Recommended hosting runtime: PHP 8.2 or 8.3.

Desktop:

- .NET 6.0 Windows.
- Windows Forms.
- MySql.Data 8.0.33.
- xUnit for automated tests.

## Demo Accounts

The following credentials are available in the seed/demo data. Replace them before using the application in a public or production environment.

Web admin:

- Username: `admin`
- Password: `12345678`

Web mahasiswa:

- Example NIM: `F1E120002`
- Password: `12345678`

Desktop:

- Admin name: `admin`
- Admin password: `12345678`
- Example student NIM: `F1E120057`
- Student password: `12345678`

## Web Development Setup

Requirements:

- PHP with common Laravel extensions: `pdo_mysql`, `mbstring`, `openssl`, `tokenizer`, `xml`, `ctype`, `json`, `bcmath`, `fileinfo`, `zip`.
- MySQL/MariaDB.
- Composer.
- pnpm.

Install dependencies:

```bash
cd himashift-admin
composer install
pnpm install --frozen-lockfile

cd ../himashift-mahasiswa
composer install
pnpm install --frozen-lockfile
```

Create the database:

```sql
CREATE DATABASE himashift CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
```

Create `.env` files in `himashift-admin` and `himashift-mahasiswa` from `.env.example`, then point both apps to the same database:

```env
DB_CONNECTION=mysql
DB_HOST=127.0.0.1
DB_PORT=3306
DB_DATABASE=himashift
DB_USERNAME=root
DB_PASSWORD=
```

Generate application keys:

```bash
cd himashift-admin
php artisan key:generate

cd ../himashift-mahasiswa
php artisan key:generate
```

Run migrations and seeders from `himashift-admin` only:

```bash
cd himashift-admin
php artisan migrate:fresh --seed
```

`himashift-admin` is the source for initial migrations and seed data because both apps share the same database. Running seeders from both apps can create duplicate records or inconsistent demo data.

Build assets:

```bash
cd himashift-admin
pnpm run build

cd ../himashift-mahasiswa
pnpm run build
```

Run local servers:

```bash
cd himashift-admin
php artisan serve --host=127.0.0.1 --port=18081
```

```bash
cd himashift-mahasiswa
php artisan serve --host=127.0.0.1 --port=18082
```

Local URLs:

- Admin: `http://127.0.0.1:18081/login`
- Mahasiswa: `http://127.0.0.1:18082/`

## Testing

Laravel tests:

```bash
cd himashift-admin
php artisan test

cd ../himashift-mahasiswa
php artisan test
```

PHPUnit uses SQLite in-memory, so tests do not modify the local MySQL database.

Main behavior coverage:

- Admin and student login.
- Register disabled.
- Protected route redirect.
- Mahasiswa, event, and absen CRUD.
- Cascade delete for absen/kehadiran.
- Attendance status updates.
- Student attendance submission.
- IDOR protection for attendance submission.
- PDF certificate generation.
- Invalid edit/show routes return 404 instead of 500.

Full testing reports are available in the [reports](reports/) folder.

## Web Deployment

The full deployment guide is available in [DEPLOY.md](DEPLOY.md).

Deployment summary:

1. Prepare hosting, domains, and SSL.
2. Upload `himashift-admin` and `himashift-mahasiswa`.
3. Point each domain/subdomain document root to its `public/` folder.
4. Prepare production `.env` files from `.env.production.example`.
5. Install dependencies, build assets, run migrations, and run cache commands.
6. Configure security headers on the hosting server.
7. Run `post-deploy-check.sh`.
8. Run the L11 browser checklist.
9. Perform a restore drill before sharing the public URL.

Example document roots:

- `admin.example.com` -> `himashift-admin/public`
- `himashift.example.com` -> `himashift-mahasiswa/public`

## Desktop Build and Distribution

Build the desktop app with the .NET SDK:

```powershell
cd himashift-visualstudio
dotnet restore
dotnet build
dotnet test
dotnet publish HIMASHIFT.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:PublishTrimmed=false
```

Main release artifacts:

- `himashift-visualstudio/bin/Release/net6.0-windows/win-x64/publish/HIMASHIFT.exe`
- `himashift-visualstudio/db/himashift-dump.sql`

Distribution notes:

- The desktop app still requires the MySQL `himashift` database.
- The current desktop connection string points to `localhost:3306`, user `root`, password `rafumazta`.
- For public distribution, use a limited demo database user and rebuild the EXE.
- `.NET 6` is end-of-support; migrating the target framework is recommended for long-term development.

## Security and Archive Notes

Fixes already applied:

- IDOR in attendance submission.
- Student password reset that returned 500.
- Duplicate route names that broke `route:cache`.
- Incorrect `Kehadiran::absen()` model relationship.
- Admin register exposure.
- Custom attendance routes that were not protected by auth.
- Certificate PDF response.
- Invalid edit/show routes that could return 500.

Archive behavior intentionally preserved:

- Student passwords in the archive database are still plain text.
- Form validation remains minimal.
- Legacy controller naming is still used.
- The two Laravel apps remain separated.
- The old Bootstrap UI is preserved.
- Some non-fatal dependency/deprecation warnings remain documented.

Full notes are available in [ARCHIVE_NOTES.md](ARCHIVE_NOTES.md).

## Contribution Guide

When developing HIMASHIFT:

- Preserve shared database schema compatibility between admin, mahasiswa, and desktop.
- Run initial migrations/seeders from `himashift-admin`.
- Run tests in both Laravel apps after changing models, controllers, routes, or policies related to the shared database.
- Run desktop tests after changing WinForms code or desktop database access.
- Document behavior changes in [CHANGELOG.md](CHANGELOG.md).
- Do not commit `.env` files, production credentials, or database dumps containing sensitive data.

## Related Documentation

- [PROJECT_STATUS.md](PROJECT_STATUS.md): latest technical status.
- [DEPLOY.md](DEPLOY.md): web deployment and rollback guide.
- [ARCHITECTURE.md](ARCHITECTURE.md): architecture and data flow.
- [ARCHIVE_NOTES.md](ARCHIVE_NOTES.md): archive philosophy and trade-offs.
- [CHANGELOG.md](CHANGELOG.md): change history.
- [reports/SUMMARY.md](reports/SUMMARY.md): L1-L12 testing summary.
- [reports/L11-browser-checklist.md](reports/L11-browser-checklist.md): manual checklist before publication.
- [himashift-admin/README_EN.md](himashift-admin/README_EN.md): admin panel documentation.
- [himashift-mahasiswa/README_EN.md](himashift-mahasiswa/README_EN.md): student app documentation.
- [himashift-visualstudio/README_EN.md](himashift-visualstudio/README_EN.md): Windows Forms desktop documentation.
- [himashift-visualstudio/DEPLOY.md](himashift-visualstudio/DEPLOY.md): desktop EXE distribution notes.
