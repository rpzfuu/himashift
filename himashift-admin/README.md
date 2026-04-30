# HIMASHIFT Admin

Bahasa: [ID](README.md) | [EN](README_EN.md)

HIMASHIFT Admin adalah aplikasi Laravel 10 untuk mengelola data inti HIMASHIFT, termasuk mahasiswa, event, absen, dan status kehadiran.

Dokumentasi ini ditujukan untuk developer dan operator yang perlu menjalankan, menguji, atau mengembangkan admin panel.

## Peran Dalam Sistem

Admin panel menjadi sumber utama untuk migrasi, seeding, dan pengelolaan data bersama. Aplikasi ini memakai database yang sama dengan `himashift-mahasiswa` dan `himashift-visualstudio`.

## Fitur

- Login admin memakai `users.name`.
- CRUD mahasiswa.
- CRUD event.
- CRUD absen.
- Manajemen status kehadiran.
- Pembuatan data `kehadiran` saat absen dibuat.

## Rute Utama

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

## Setup Pengembangan

Install dependency:

```bash
composer install
pnpm install --frozen-lockfile
```

Siapkan environment:

```bash
cp .env.example .env
php artisan key:generate
```

Konfigurasi database pada `.env`:

```env
DB_CONNECTION=mysql
DB_HOST=127.0.0.1
DB_PORT=3306
DB_DATABASE=himashift
DB_USERNAME=root
DB_PASSWORD=
```

Jalankan migrasi dan seeder:

```bash
php artisan migrate:fresh --seed
```

Build asset dan jalankan server lokal:

```bash
pnpm run build
php artisan serve --host=127.0.0.1 --port=18081
```

Admin panel lokal tersedia di `http://127.0.0.1:18081/login`.

## Database Bersama

`himashift-admin` menjadi sumber migrasi/seeder awal untuk database `himashift`.

Developer yang menjalankan semua aplikasi secara lokal perlu mengarahkan `.env` milik `himashift-mahasiswa` ke database yang sama. Seeder dari app mahasiswa tidak perlu dijalankan untuk database arsip bersama.

## Akun Demo

- Username: `admin`
- Password: `12345678`

Credential demo hanya untuk development, testing, atau demo lokal.

## Testing

```bash
php artisan test
```

Test suite memakai SQLite in-memory dan tidak mengubah database MySQL lokal.

Coverage utama:

- Login admin.
- Register disabled.
- Protected route redirect.
- CRUD mahasiswa.
- CRUD event.
- CRUD absen.
- Cascade delete absen/kehadiran.
- Update status kehadiran.
- Invalid edit route menjadi 404.

## Catatan Developer

- Pertahankan kompatibilitas schema dengan `himashift-mahasiswa` dan desktop WinForms.
- Jalankan `php artisan route:cache` atau simulasi cache sebelum deploy jika mengubah route.
- Jalankan test admin dan mahasiswa setelah mengubah model atau relasi database bersama.
- Jangan commit file `.env` atau credential produksi.

## Dokumentasi Terkait

- [../README.md](../README.md): dokumentasi utama repository.
- [../ARCHITECTURE.md](../ARCHITECTURE.md): arsitektur dan flow data.
- [../DEPLOY.md](../DEPLOY.md): panduan deploy web.
- [../ARCHIVE_NOTES.md](../ARCHIVE_NOTES.md): catatan arsip dan trade-off.
- [../reports/SUMMARY.md](../reports/SUMMARY.md): ringkasan testing.
