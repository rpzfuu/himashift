# HIMASHIFT

Bahasa: [ID](README.md) | [EN](README_EN.md)

HIMASHIFT adalah aplikasi arsip untuk Himpunan Mahasiswa Sistem Informasi. Repository ini berisi dua aplikasi web Laravel dan satu aplikasi desktop Windows Forms yang memakai database MySQL yang sama.

Dokumentasi ini ditujukan untuk pengguna teknis, operator, dan developer yang ingin menjalankan, menguji, mengembangkan, atau mendistribusikan ulang HIMASHIFT.

## Status Proyek

HIMASHIFT dipertahankan sebagai proyek arsip. Struktur utama, gaya kode lama, dan perilaku historis tetap dijaga, sementara bug fatal, bug keamanan, dan bug integritas data yang menghambat penggunaan telah diperbaiki.

Verifikasi terakhir: 2026-04-30.

- Admin PHPUnit: 12 tests passed, 51 assertions.
- Mahasiswa PHPUnit: 11 tests passed, 32 assertions.
- Desktop xUnit: 13 tests passed.
- Desktop EXE smoke: aplikasi start dan membuka window `beranda`.
- Composer audit: no advisories.
- `pnpm install --frozen-lockfile`: pass di dua app Laravel.
- `pnpm run build`: pass di dua app Laravel.
- Route/config/view cache simulation: pass di dua app Laravel.
- Local production smoke dengan `APP_ENV=production` dan `APP_DEBUG=false`: pass.
- HTTP CRUD/cascade/PDF/IDOR smoke: pass.

Status teknis terbaru dicatat di [PROJECT_STATUS.md](PROJECT_STATUS.md).

## Komponen Repository

```text
himashift/
|-- himashift-admin/        # Admin panel Laravel
|-- himashift-mahasiswa/    # Aplikasi mahasiswa dan halaman publik Laravel
|-- himashift-visualstudio/ # Aplikasi desktop Windows Forms
|-- reports/                # Laporan testing L1-L12
|-- DEPLOY.md               # Panduan deploy web
|-- ARCHITECTURE.md         # Arsitektur teknis
|-- ARCHIVE_NOTES.md        # Catatan arsip dan trade-off
|-- CHANGELOG.md            # Riwayat perubahan rescue/testing
`-- PROJECT_STATUS.md       # Status terbaru repository
```

## Aplikasi

### HIMASHIFT Admin

Admin panel digunakan untuk mengelola data inti organisasi dan absensi.

Fitur utama:

- Login admin.
- CRUD mahasiswa.
- CRUD event.
- CRUD absen.
- Melihat daftar kehadiran per mahasiswa.
- Mengubah status kehadiran mahasiswa.

Rute utama:

- `/login`
- `/home/mahasiswa`
- `/home/event`
- `/home/absen`
- `/home/kehadiran`

Dokumentasi khusus app tersedia di [himashift-admin/README.md](himashift-admin/README.md).

### HIMASHIFT Mahasiswa

Aplikasi mahasiswa menyediakan halaman publik, dashboard mahasiswa, absensi, event, dan sertifikat.

Fitur utama:

- Login mahasiswa memakai NIM.
- Halaman publik anggota.
- Dashboard mahasiswa.
- Profil mahasiswa.
- Daftar event.
- Daftar absensi.
- Submit kehadiran sendiri.
- Generate sertifikat PDF.

Rute utama:

- `/`
- `/anggota`
- `/dashboard`
- `/dashboard/profil`
- `/dashboard/absensi`
- `/dashboard/event`
- `/dashboard/sertifikat`

Dokumentasi khusus app tersedia di [himashift-mahasiswa/README.md](himashift-mahasiswa/README.md).

### HIMASHIFT Desktop

Aplikasi desktop Windows Forms disediakan sebagai artefak arsip/demo lokal untuk Windows x64.

Detail rilis:

- Target: `.NET 6.0-windows`.
- Runtime: Windows x64.
- Published EXE: `himashift-visualstudio/bin/Release/net6.0-windows/win-x64/publish/HIMASHIFT.exe`.
- Build: self-contained single-file.
- Database: MySQL `himashift`.

Dokumentasi khusus desktop tersedia di [himashift-visualstudio/README.md](himashift-visualstudio/README.md).

## Arsitektur Data

Dua aplikasi web dan aplikasi desktop memakai database yang sama bernama `himashift`.

```text
himashift-admin        himashift-mahasiswa        HIMASHIFT Desktop
       |                       |                         |
       +----------+------------+-------------------------+
                  |
              MySQL DB
              himashift
```

Tabel inti:

- `users`
- `mahasiswa`
- `divisi`
- `mahasiswa_divisi`
- `event`
- `absen`
- `kehadiran`

Flow utama:

1. Admin membuat data mahasiswa dan divisi.
2. Admin membuat data absen.
3. Sistem membuat row `kehadiran` untuk semua mahasiswa pada absen tersebut.
4. Mahasiswa login dan membuka halaman absensi.
5. Mahasiswa submit kehadiran miliknya sendiri.
6. Admin melihat atau mengubah status kehadiran.
7. Mahasiswa membuat sertifikat PDF dari halaman sertifikat.

Detail arsitektur tersedia di [ARCHITECTURE.md](ARCHITECTURE.md).

## Tech Stack

Web Laravel:

- PHP 8.1+.
- Laravel 10.
- MySQL/MariaDB.
- Bootstrap.
- Vite.
- pnpm.
- TCPDF untuk sertifikat PDF.
- PHPUnit untuk automated tests.

Runtime hosting yang direkomendasikan: PHP 8.2 atau 8.3.

Desktop:

- .NET 6.0 Windows.
- Windows Forms.
- MySql.Data 8.0.33.
- xUnit untuk automated tests.

## Akun Demo

Credential berikut tersedia pada data seed/demo. Ganti credential sebelum memakai aplikasi untuk lingkungan publik atau produksi.

Admin web:

- Username: `admin`
- Password: `12345678`

Mahasiswa web:

- NIM contoh: `F1E120002`
- Password: `12345678`

Desktop:

- Admin name: `admin`
- Admin password: `12345678`
- NIM contoh mahasiswa: `F1E120057`
- Password mahasiswa: `12345678`

## Setup Pengembangan Web

Prasyarat:

- PHP dengan extension umum Laravel: `pdo_mysql`, `mbstring`, `openssl`, `tokenizer`, `xml`, `ctype`, `json`, `bcmath`, `fileinfo`, `zip`.
- MySQL/MariaDB.
- Composer.
- pnpm.

Install dependency:

```bash
cd himashift-admin
composer install
pnpm install --frozen-lockfile

cd ../himashift-mahasiswa
composer install
pnpm install --frozen-lockfile
```

Buat database:

```sql
CREATE DATABASE himashift CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
```

Siapkan `.env` pada `himashift-admin` dan `himashift-mahasiswa` dari `.env.example`, lalu arahkan keduanya ke database yang sama:

```env
DB_CONNECTION=mysql
DB_HOST=127.0.0.1
DB_PORT=3306
DB_DATABASE=himashift
DB_USERNAME=root
DB_PASSWORD=
```

Generate application key:

```bash
cd himashift-admin
php artisan key:generate

cd ../himashift-mahasiswa
php artisan key:generate
```

Jalankan migrasi dan seeder dari `himashift-admin` saja:

```bash
cd himashift-admin
php artisan migrate:fresh --seed
```

`himashift-admin` menjadi sumber migrasi/seeder awal karena dua app memakai database yang sama. Menjalankan seeder dari dua app dapat menghasilkan data duplikat atau data demo yang tidak konsisten.

Build asset:

```bash
cd himashift-admin
pnpm run build

cd ../himashift-mahasiswa
pnpm run build
```

Jalankan server lokal:

```bash
cd himashift-admin
php artisan serve --host=127.0.0.1 --port=18081
```

```bash
cd himashift-mahasiswa
php artisan serve --host=127.0.0.1 --port=18082
```

URL lokal:

- Admin: `http://127.0.0.1:18081/login`
- Mahasiswa: `http://127.0.0.1:18082/`

## Testing

Test Laravel:

```bash
cd himashift-admin
php artisan test

cd ../himashift-mahasiswa
php artisan test
```

PHPUnit memakai SQLite in-memory, sehingga test tidak mengubah database MySQL lokal.

Coverage perilaku utama:

- Login admin dan mahasiswa.
- Register disabled.
- Protected route redirect.
- CRUD mahasiswa, event, dan absen.
- Cascade delete absen/kehadiran.
- Update status kehadiran.
- Submit kehadiran mahasiswa.
- Proteksi IDOR submit kehadiran.
- Generate sertifikat PDF.
- Invalid edit/show route menjadi 404, bukan 500.

Laporan testing lengkap tersedia di folder [reports](reports/).

## Deploy Web

Panduan deploy lengkap tersedia di [DEPLOY.md](DEPLOY.md).

Ringkasan deploy:

1. Siapkan hosting, domain, dan SSL.
2. Upload `himashift-admin` dan `himashift-mahasiswa`.
3. Arahkan document root masing-masing domain/subdomain ke folder `public/`.
4. Siapkan `.env` production dari `.env.production.example`.
5. Jalankan install dependency, build asset, migrasi, dan cache command.
6. Pasang security headers di hosting.
7. Jalankan `post-deploy-check.sh`.
8. Jalankan browser checklist L11.
9. Lakukan restore drill sebelum URL publik disebar.

Contoh document root:

- `admin.example.com` -> `himashift-admin/public`
- `himashift.example.com` -> `himashift-mahasiswa/public`

## Desktop Build dan Distribusi

Build desktop memakai .NET SDK:

```powershell
cd himashift-visualstudio
dotnet restore
dotnet build
dotnet test
dotnet publish HIMASHIFT.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:PublishTrimmed=false
```

Artefak rilis utama:

- `himashift-visualstudio/bin/Release/net6.0-windows/win-x64/publish/HIMASHIFT.exe`
- `himashift-visualstudio/db/himashift-dump.sql`

Catatan distribusi:

- Desktop tetap membutuhkan database MySQL `himashift`.
- Connection string desktop saat ini mengarah ke `localhost:3306`, user `root`, password `rafumazta`.
- Untuk distribusi publik, gunakan user database demo yang terbatas lalu rebuild EXE.
- `.NET 6` sudah end-of-support; migrasi target framework disarankan untuk pengembangan jangka panjang.

## Catatan Keamanan dan Arsip

Perbaikan yang sudah dilakukan:

- IDOR submit kehadiran.
- Password reset mahasiswa yang menghasilkan 500.
- Duplicate route name yang membuat `route:cache` gagal.
- Relasi model `Kehadiran::absen()` yang salah.
- Admin register exposure.
- Route custom kehadiran yang belum terlindungi auth.
- Certificate PDF response.
- Invalid edit/show route yang berisiko 500.

Perilaku arsip yang sengaja dipertahankan:

- Password mahasiswa pada database arsip masih plain text.
- Validasi form masih minimal.
- Naming controller lama tetap digunakan.
- Dua aplikasi Laravel tetap dipisah.
- UI Bootstrap lama tetap dipertahankan.
- Beberapa warning dependency/deprecation yang tidak fatal masih terdokumentasi.

Catatan lengkap tersedia di [ARCHIVE_NOTES.md](ARCHIVE_NOTES.md).

## Panduan Kontribusi

Saat mengembangkan HIMASHIFT:

- Pertahankan kompatibilitas schema database bersama antara admin, mahasiswa, dan desktop.
- Jalankan migrasi/seeder awal dari `himashift-admin`.
- Jalankan test pada dua app Laravel setelah mengubah model, controller, route, atau policy terkait database bersama.
- Jalankan test desktop setelah mengubah kode WinForms atau akses database desktop.
- Dokumentasikan perubahan perilaku di [CHANGELOG.md](CHANGELOG.md).
- Hindari commit file `.env`, credential produksi, atau dump database berisi data sensitif.

## Dokumentasi Terkait

- [PROJECT_STATUS.md](PROJECT_STATUS.md): status teknis terbaru.
- [DEPLOY.md](DEPLOY.md): panduan deploy dan rollback web.
- [ARCHITECTURE.md](ARCHITECTURE.md): arsitektur dua app dan flow data.
- [ARCHIVE_NOTES.md](ARCHIVE_NOTES.md): filosofi arsip dan trade-off.
- [CHANGELOG.md](CHANGELOG.md): riwayat perubahan.
- [reports/SUMMARY.md](reports/SUMMARY.md): ringkasan testing L1-L12.
- [reports/L11-browser-checklist.md](reports/L11-browser-checklist.md): checklist manual sebelum publikasi.
- [himashift-admin/README.md](himashift-admin/README.md): dokumentasi admin panel.
- [himashift-mahasiswa/README.md](himashift-mahasiswa/README.md): dokumentasi aplikasi mahasiswa.
- [himashift-visualstudio/README.md](himashift-visualstudio/README.md): dokumentasi desktop WinForms.
- [himashift-visualstudio/DEPLOY.md](himashift-visualstudio/DEPLOY.md): catatan distribusi EXE desktop.
