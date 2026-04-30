# HIMASHIFT Mahasiswa

Bahasa: [ID](README.md) | [EN](README_EN.md)

HIMASHIFT Mahasiswa adalah aplikasi Laravel 10 untuk halaman publik, login mahasiswa, absensi, event, profil, dan sertifikat PDF.

Dokumentasi ini ditujukan untuk developer dan operator yang perlu menjalankan, menguji, atau mengembangkan aplikasi mahasiswa.

## Peran Dalam Sistem

Aplikasi ini memakai database `himashift` yang sama dengan `himashift-admin` dan aplikasi desktop. Data mahasiswa, event, absen, dan kehadiran dikelola dari admin panel, lalu dibaca atau diperbarui sesuai hak akses mahasiswa.

## Fitur

- Login mahasiswa memakai NIM.
- Halaman publik anggota.
- Dashboard mahasiswa.
- Profil mahasiswa.
- Daftar event.
- Daftar absensi.
- Submit kehadiran milik akun yang sedang login.
- Generate sertifikat PDF.

## Rute Utama

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

Build asset dan jalankan server lokal:

```bash
pnpm run build
php artisan serve --host=127.0.0.1 --port=18082
```

Aplikasi lokal tersedia di `http://127.0.0.1:18082/`.

## Database Bersama

Migrasi dan seeder awal dijalankan dari `himashift-admin`.

Untuk development lokal, jalankan `php artisan migrate:fresh --seed` dari folder `himashift-admin`, lalu pastikan `.env` aplikasi mahasiswa mengarah ke database yang sama.

## Akun Demo

Data seed/demo memakai password mahasiswa `12345678`.

Contoh akun:

- NIM: `F1E120002`
- Password: `12345678`

Credential demo hanya untuk development, testing, atau demo lokal.

## Testing

```bash
php artisan test
```

Test suite memakai SQLite in-memory dan tidak mengubah database MySQL lokal.

Coverage utama:

- Login mahasiswa.
- Protected route redirect.
- Halaman anggota.
- Dashboard mahasiswa.
- Submit kehadiran.
- Proteksi IDOR submit kehadiran.
- Generate sertifikat PDF.
- Invalid route menjadi 404.

## Catatan Developer

- Jangan menjalankan seeder mahasiswa untuk database arsip bersama kecuali perubahan seed memang sedang dikembangkan.
- Pertahankan aturan bahwa mahasiswa hanya dapat mengubah kehadiran miliknya sendiri.
- Jalankan test admin dan mahasiswa setelah mengubah relasi model, tabel bersama, atau flow absensi.
- Jangan commit file `.env` atau credential produksi.

## Dokumentasi Terkait

- [../README.md](../README.md): dokumentasi utama repository.
- [../ARCHITECTURE.md](../ARCHITECTURE.md): arsitektur dan flow data.
- [../DEPLOY.md](../DEPLOY.md): panduan deploy web.
- [../ARCHIVE_NOTES.md](../ARCHIVE_NOTES.md): catatan arsip dan trade-off.
- [../reports/SUMMARY.md](../reports/SUMMARY.md): ringkasan testing.
