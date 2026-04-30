# HIMASHIFT

HIMASHIFT adalah aplikasi arsip untuk Himpunan Mahasiswa Sistem Informasi. Project ini mencakup dua aplikasi web Laravel dan satu aplikasi desktop Windows Forms yang memakai database MySQL yang sama.

Aplikasi ini membantu pengelolaan data anggota, divisi, agenda/event, absensi, status kehadiran, dan pembuatan sertifikat sederhana untuk mahasiswa.

Project ini dipertahankan sebagai archive proses belajar. Kode aslinya tidak dirombak total; perbaikan difokuskan pada bug fatal, bug integrity, dan bug security yang membuat aplikasi tidak aman atau tidak siap dipresentasikan sebagai portofolio publik.

## Status

Code/config web Laravel sudah deploy-ready untuk portofolio publik. Versi desktop WinForms juga sudah dipublish sebagai Windows x64 self-contained EXE.

Verifikasi terakhir: 2026-04-30.

- Admin PHPUnit: 12 tests passed, 51 assertions.
- Mahasiswa PHPUnit: 11 tests passed, 32 assertions.
- Desktop xUnit: 13 tests passed.
- Desktop EXE smoke: aplikasi start dan membuka window `beranda`.
- Composer audit: no advisories.
- `pnpm install --frozen-lockfile`: pass di dua app.
- `pnpm run build`: pass di dua app.
- Route/config/view cache simulation: pass di dua app.
- Local production smoke dengan `APP_ENV=production` dan `APP_DEBUG=false`: pass.
- HTTP CRUD/cascade/PDF/IDOR smoke: pass.
- JS dependency memakai satu lockfile: `pnpm-lock.yaml`.

Status terbaru repo dicatat di [PROJECT_STATUS.md](PROJECT_STATUS.md).

## Aplikasi

Repo ini berisi dua Laravel app dan satu WinForms desktop archive yang memakai satu database MySQL yang sama.

```text
himashift/
|-- himashift-admin/       # Admin panel
|-- himashift-mahasiswa/   # Aplikasi mahasiswa/public
|-- himashift-visualstudio/ # Aplikasi desktop Windows Forms
|-- reports/               # Laporan testing L1-L12
|-- DEPLOY.md              # Panduan deploy
|-- ARCHITECTURE.md        # Arsitektur teknis
|-- ARCHIVE_NOTES.md       # Catatan arsip dan trade-off
|-- CHANGELOG.md           # Perubahan rescue/testing
`-- PROJECT_STATUS.md      # Status terbaru repo
```

### Himashift Admin

Admin panel untuk pengelolaan data inti.

Fitur:

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

### Himashift Mahasiswa

Aplikasi untuk mahasiswa dan halaman publik.

Fitur:

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

### HIMASHIFT Desktop

Aplikasi desktop Windows Forms untuk arsip/demo lokal HIMASHIFT.

Status rilis:

- Target: `.NET 6.0-windows`.
- Runtime: Windows x64.
- Published EXE: `himashift-visualstudio/bin/Release/net6.0-windows/win-x64/publish/HIMASHIFT.exe`.
- Ukuran EXE: sekitar 161 MB.
- Build: self-contained single-file, sehingga pengguna normal tidak perlu install .NET Runtime terpisah.

Catatan penting:

- Tetap membutuhkan database MySQL `himashift`.
- Connection string desktop saat ini mengarah ke `localhost:3306`, user `root`, password `rafumazta`.
- File dump database desktop tersedia di `himashift-visualstudio/db/himashift-dump.sql`.
- Untuk rilis publik sungguhan, jangan pakai credential root/personal; buat user demo terbatas lalu rebuild EXE.

## Arsitektur

Dua app web dan aplikasi desktop memakai database yang sama bernama `himashift`.

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
7. Mahasiswa bisa membuat sertifikat PDF dari halaman sertifikat.

Detail tambahan ada di [ARCHITECTURE.md](ARCHITECTURE.md).

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

Runtime yang direkomendasikan untuk hosting: PHP 8.2 atau 8.3.

Desktop:

- .NET 6.0 Windows.
- Windows Forms.
- MySql.Data 8.0.33.
- xUnit untuk automated tests.

## Credential Default

### Web Laravel

Admin:

- Username: `admin`
- Password: `12345678`

Mahasiswa:

- NIM contoh: `F1E120002`
- Password: `12345678`

### Desktop WinForms

Admin:

- Name: `admin`
- Password: `12345678`

Mahasiswa:

- NIM contoh: `F1E120057`
- Password: `12345678`

Catatan archive: password mahasiswa pada database arsip masih plain text. Ini sengaja tidak diubah agar perilaku project lama tetap terjaga. Security bug yang berdampak langsung, seperti IDOR submit absensi, sudah difix.

## Instalasi Lokal Web Laravel

Pastikan sudah tersedia:

- PHP dengan extension umum Laravel: `pdo_mysql`, `mbstring`, `openssl`, `tokenizer`, `xml`, `ctype`, `json`, `bcmath`, `fileinfo`, `zip`.
- MySQL/MariaDB.
- Composer.
- pnpm.

### 1. Install Dependency

```bash
cd himashift-admin
composer install
pnpm install --frozen-lockfile

cd ../himashift-mahasiswa
composer install
pnpm install --frozen-lockfile
```

### 2. Siapkan Database

Buat database:

```sql
CREATE DATABASE himashift CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
```

### 3. Siapkan `.env`

Di dua app, salin `.env.example` menjadi `.env`, lalu sesuaikan DB:

```env
DB_CONNECTION=mysql
DB_HOST=127.0.0.1
DB_PORT=3306
DB_DATABASE=himashift
DB_USERNAME=root
DB_PASSWORD=
```

Generate key di dua app:

```bash
cd himashift-admin
php artisan key:generate

cd ../himashift-mahasiswa
php artisan key:generate
```

### 4. Migrasi dan Seeder

Jalankan migrasi dan seeder dari `himashift-admin` saja:

```bash
cd himashift-admin
php artisan migrate:fresh --seed
```

Kenapa hanya dari admin app?

- Dua app memakai database yang sama.
- Seeder admin menghasilkan data mahasiswa yang cocok dengan login archive.
- Menjalankan seeder dari dua app dapat membuat duplicate data atau perilaku login yang tidak sesuai archive.

### 5. Build Asset

```bash
cd himashift-admin
pnpm run build

cd ../himashift-mahasiswa
pnpm run build
```

### 6. Jalankan Lokal

Terminal 1:

```bash
cd himashift-admin
php artisan serve --host=127.0.0.1 --port=18081
```

Terminal 2:

```bash
cd himashift-mahasiswa
php artisan serve --host=127.0.0.1 --port=18082
```

URL lokal:

- Admin: `http://127.0.0.1:18081/login`
- Mahasiswa: `http://127.0.0.1:18082/`

## Testing Web Laravel

Jalankan test di masing-masing app:

```bash
cd himashift-admin
php artisan test

cd ../himashift-mahasiswa
php artisan test
```

PHPUnit memakai SQLite in-memory, jadi test tidak mengubah database MySQL lokal.

Coverage perilaku utama:

- Login admin.
- Login mahasiswa.
- Register disabled.
- Protected route redirect.
- CRUD mahasiswa.
- CRUD event.
- CRUD absen.
- Cascade delete absen/kehadiran.
- Update status kehadiran.
- Submit kehadiran mahasiswa.
- Proteksi IDOR submit kehadiran.
- Generate sertifikat PDF.
- Invalid edit route menjadi 404, bukan 500.

Laporan testing lengkap ada di folder [reports](reports/).

## Deploy Web Laravel

Panduan deploy lengkap ada di [DEPLOY.md](DEPLOY.md).

Urutan ringkas:

1. Setup hosting, domain, dan SSL.
2. Upload `himashift-admin` dan `himashift-mahasiswa`.
3. Arahkan document root masing-masing domain/subdomain ke folder `public/`.
4. Siapkan `.env` production dari `.env.production.example`.
5. Jalankan install dependency, build asset, migrate, dan cache command.
6. Pasang security headers di hosting.
7. Jalankan `post-deploy-check.sh`.
8. Jalankan browser checklist L11.
9. Lakukan restore drill sebelum URL portofolio disebar.

Contoh document root:

- `admin.example.com` -> `himashift-admin/public`
- `himashift.example.com` -> `himashift-mahasiswa/public`

## Rilis Desktop EXE

Untuk GitHub Release desktop, gunakan input berikut:

- Tag: `v1.0.0`.
- Target: `main`.
- Release title: `HIMASHIFT Desktop v1.0.0`.
- Asset utama: `himashift-visualstudio/bin/Release/net6.0-windows/win-x64/publish/HIMASHIFT.exe`.
- Asset tambahan yang disarankan: `himashift-visualstudio/db/himashift-dump.sql`, selama tidak ada data sensitif.

Release notes yang disarankan:

```md
## HIMASHIFT Desktop v1.0.0

Rilis pertama aplikasi desktop HIMASHIFT berbasis Windows Forms.

### Isi rilis
- Aplikasi desktop Windows x64.
- Build self-contained, jadi tidak perlu install .NET Runtime terpisah.
- Terhubung ke database MySQL `himashift`.
- Mendukung login mahasiswa dan admin.

### Cara menjalankan
1. Download `HIMASHIFT.exe` dari bagian Assets.
2. Pastikan MySQL berjalan di `localhost:3306`.
3. Import `himashift-dump.sql` ke database bernama `himashift`.
4. Jalankan `HIMASHIFT.exe`.

### Akun demo
Mahasiswa:
- NIM: `F1E120057`
- Password: `12345678`

Admin:
- Name: `admin`
- Password: `12345678`

### Catatan
- Aplikasi ini masih membutuhkan database MySQL lokal.
- Build ini cocok sebagai arsip/demo desktop HIMASHIFT.
- Versi ini dibuat dengan `.NET 6.0-windows`.
```

## Production Notes

Gunakan `.env.production.example` di masing-masing app sebagai template.

Nilai penting:

```env
APP_ENV=production
APP_DEBUG=false
LOG_CHANNEL=daily
LOG_LEVEL=warning
SESSION_SECURE_COOKIE=true
```

Security header minimum yang dicek oleh `post-deploy-check.sh`:

- `X-Frame-Options`
- `X-Content-Type-Options`
- `Strict-Transport-Security`

Contoh nginx:

```nginx
add_header X-Frame-Options "SAMEORIGIN" always;
add_header X-Content-Type-Options "nosniff" always;
add_header Strict-Transport-Security "max-age=31536000; includeSubDomains" always;
```

## Archive Philosophy

Prinsip rescue project ini:

- Test seluas mungkin.
- Fix seminim mungkin.
- Fix hanya bug fatal, data integrity, dan security yang berdampak.
- Quality issues yang merupakan karakter archive didokumentasikan, bukan dirombak.

Yang difix:

- IDOR submit kehadiran.
- Password reset mahasiswa yang 500.
- Duplicate route name yang membuat `route:cache` gagal.
- Relasi model `Kehadiran::absen()` yang salah.
- Admin register exposure.
- Route custom kehadiran yang belum terlindungi auth.
- Certificate PDF response.
- Invalid edit/show route yang berisiko 500.

Yang sengaja dipertahankan:

- Plain text password mahasiswa.
- Validasi form minimal.
- Naming controller lama.
- Struktur dua app terpisah.
- UI Bootstrap lama.
- Beberapa warning dependency/deprecation yang tidak fatal.

Catatan lengkap ada di [ARCHIVE_NOTES.md](ARCHIVE_NOTES.md).

## Dokumentasi Tambahan

- [PROJECT_STATUS.md](PROJECT_STATUS.md): status terbaru project.
- [DEPLOY.md](DEPLOY.md): panduan deploy dan rollback.
- [ARCHITECTURE.md](ARCHITECTURE.md): arsitektur dua app dan flow data.
- [ARCHIVE_NOTES.md](ARCHIVE_NOTES.md): filosofi archive dan trade-off.
- [CHANGELOG.md](CHANGELOG.md): perubahan yang dilakukan saat rescue.
- [reports/SUMMARY.md](reports/SUMMARY.md): ringkasan testing L1-L12.
- [reports/L11-browser-checklist.md](reports/L11-browser-checklist.md): checklist manual sebelum publikasi.
- [himashift-visualstudio/README.md](himashift-visualstudio/README.md): panduan desktop WinForms.
- [himashift-visualstudio/DEPLOY.md](himashift-visualstudio/DEPLOY.md): catatan distribusi EXE desktop.

## Portfolio Story

Project ini dapat dipresentasikan sebagai:

> Project awal dari masa belajar yang kemudian direstore, diaudit 12 lapisan, diperbaiki pada bug fatal/security/integrity, ditambah automated tests, dan dipersiapkan untuk deploy publik tanpa menghilangkan identitas kode aslinya.

Angle teknis yang menonjol:

- Restore legacy/archive Laravel app.
- Rescue dan distribusi desktop WinForms archive.
- Audit environment, routing, database, security, performance, dan deploy readiness.
- Fix security bug IDOR.
- Fix production blocker `route:cache`.
- Tambah 23 automated tests proporsional.
- Dokumentasi deploy dan rollback.
- Publish desktop self-contained EXE untuk demo lokal.
