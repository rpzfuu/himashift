# Tutorial Hosting HIMASHIFT Mahasiswa di InfinityFree

Target:

```text
https://himashift.infinityfree.me
```

Tutorial ini khusus untuk deploy app `himashift-mahasiswa` dulu. App admin bisa menyusul setelah app mahasiswa berhasil tampil, login, dan generate sertifikat.

## Catatan Penting

InfinityFree free hosting cocok untuk deploy portfolio, tetapi ada batasan penting:

- Tidak ada SSH/terminal.
- Tidak bisa menjalankan Composer di server.
- Tidak bisa menjalankan `php artisan` di server.
- Dependency harus disiapkan lokal lalu diupload.
- Laravel tidak bisa langsung diarahkan document root-nya ke `public/`, jadi perlu `.htaccess` di `htdocs` untuk rewrite ke folder `public`.

Karena itu workflow deploy-nya adalah:

1. Build dan test di lokal.
2. Export database lokal.
3. Upload project yang sudah siap ke InfinityFree.
4. Import database lewat phpMyAdmin.
5. Pasang `.env` production.
6. Pasang `.htaccess` rewrite.
7. Aktifkan SSL.
8. Smoke test.

## 1. Buat Domain di InfinityFree

Di InfinityFree Client Area:

1. Login ke akun InfinityFree.
2. Klik `Create Account` atau `Add Domain`.
3. Pilih free subdomain.
4. Masukkan:

```text
himashift
```

5. Pilih extension:

```text
infinityfree.me
```

Hasil akhirnya:

```text
himashift.infinityfree.me
```

Tunggu sampai hosting account aktif.

## 2. Buat Database MySQL

Masuk ke Control Panel domain `himashift.infinityfree.me`.

1. Buka menu `MySQL Databases`.
2. Buat database baru, misalnya:

```text
himashift
```

InfinityFree biasanya akan membuat nama database dengan prefix akun, contohnya:

```text
if0_12345678_himashift
```

Catat data berikut dari panel:

```env
DB_HOST=sqlXXX.infinityfree.com
DB_DATABASE=if0_12345678_himashift
DB_USERNAME=if0_12345678
DB_PASSWORD=password_database
```

Jangan pakai:

```env
DB_HOST=127.0.0.1
```

Di InfinityFree, host MySQL harus mengikuti nilai dari Control Panel.

## 3. Siapkan App Mahasiswa di Lokal

Dari root repo:

```bash
cd himashift-mahasiswa
```

Pastikan dependency lengkap:

```bash
composer install --optimize-autoloader --no-dev
pnpm install --frozen-lockfile
pnpm run build
```

Jalankan test:

```bash
php artisan test
```

Expected:

```text
11 tests passed
```

Clear cache lokal sebelum upload:

```bash
php artisan optimize:clear
```

## 4. Siapkan `.env` Production

Di folder `himashift-mahasiswa`, salin:

```text
.env.production.example
```

menjadi:

```text
.env
```

Isi seperti ini, sesuaikan credential database dari InfinityFree:

```env
APP_NAME=HIMASHIFT
APP_ENV=production
APP_KEY=base64:ISI_DENGAN_APP_KEY_YANG_SUDAH_ADA
APP_DEBUG=false
APP_URL=https://himashift.infinityfree.me

LOG_CHANNEL=daily
LOG_LEVEL=warning

DB_CONNECTION=mysql
DB_HOST=sqlXXX.infinityfree.com
DB_PORT=3306
DB_DATABASE=if0_12345678_himashift
DB_USERNAME=if0_12345678
DB_PASSWORD=password_database

BROADCAST_DRIVER=log
CACHE_DRIVER=file
FILESYSTEM_DISK=local
QUEUE_CONNECTION=sync
SESSION_DRIVER=file
SESSION_LIFETIME=120
SESSION_COOKIE=himashift_session
SESSION_SECURE_COOKIE=true
SESSION_SAME_SITE=lax

MAIL_MAILER=smtp
MAIL_HOST=
MAIL_PORT=587
MAIL_USERNAME=
MAIL_PASSWORD=
MAIL_ENCRYPTION=tls
MAIL_FROM_ADDRESS=no-reply@example.com
MAIL_FROM_NAME="${APP_NAME}"
```

Untuk `APP_KEY`, pakai key dari `.env` lokal yang sudah jalan. Jangan kosong.

Kalau belum ada APP_KEY:

```bash
php artisan key:generate
```

lalu copy nilai `APP_KEY` ke `.env` production.

## 5. Export Database Lokal

Database lokal bernama:

```text
himashift
```

Export dengan `mysqldump`:

```bash
mysqldump -u root -p himashift > himashift.sql
```

Kalau user MySQL lokal tidak pakai password:

```bash
mysqldump -u root himashift > himashift.sql
```

File `himashift.sql` ini nanti di-import ke phpMyAdmin InfinityFree.

## 6. Siapkan File `.htaccess` Root

Di folder `himashift-mahasiswa`, buat file `.htaccess` sejajar dengan `artisan`.

Isi:

```apache
<FilesMatch "^\.">
    Require all denied
</FilesMatch>

<IfModule mod_headers.c>
    Header always set X-Frame-Options "SAMEORIGIN"
    Header always set X-Content-Type-Options "nosniff"
    Header always set Strict-Transport-Security "max-age=31536000; includeSubDomains"
</IfModule>

<IfModule mod_rewrite.c>
    RewriteEngine On

    RewriteCond %{HTTPS} !=on
    RewriteRule ^ https://%{HTTP_HOST}%{REQUEST_URI} [L,R=301]

    RewriteRule ^(.*)$ public/$1 [L]
</IfModule>
```

Catatan:

- Kalau SSL belum aktif, bagian redirect HTTPS bisa membuat error.
- Kalau website belum bisa dibuka setelah upload, comment dulu dua baris ini:

```apache
RewriteCond %{HTTPS} !=on
RewriteRule ^ https://%{HTTP_HOST}%{REQUEST_URI} [L,R=301]
```

Setelah SSL aktif, nyalakan lagi.

## 7. Pastikan `.htaccess` di `public/` Ada

Laravel sudah punya file:

```text
public/.htaccess
```

Pastikan file itu ikut terupload.

Isi default Laravel kurang lebih seperti ini:

```apache
<IfModule mod_rewrite.c>
    <IfModule mod_negotiation.c>
        Options -MultiViews -Indexes
    </IfModule>

    RewriteEngine On

    RewriteCond %{HTTP:Authorization} .
    RewriteRule .* - [E=HTTP_AUTHORIZATION:%{HTTP:Authorization}]

    RewriteCond %{REQUEST_FILENAME} !-d
    RewriteCond %{REQUEST_URI} (.+)/$
    RewriteRule ^ %1 [L,R=301]

    RewriteCond %{REQUEST_FILENAME} !-d
    RewriteCond %{REQUEST_FILENAME} !-f
    RewriteRule ^ index.php [L]
</IfModule>
```

## 8. Upload ke InfinityFree

Buka File Manager atau FTP.

Masuk ke folder domain:

```text
himashift.infinityfree.me/htdocs
```

Upload **isi folder** `himashift-mahasiswa` ke `htdocs`.

Struktur akhir harus seperti ini:

```text
htdocs/
|-- app/
|-- bootstrap/
|-- config/
|-- database/
|-- public/
|-- resources/
|-- routes/
|-- storage/
|-- vendor/
|-- .env
|-- .htaccess
|-- artisan
|-- composer.json
`-- composer.lock
```

Jangan upload:

```text
node_modules/
tests/
.git/
```

Folder `vendor/` harus diupload karena InfinityFree free hosting tidak menyediakan Composer/SSH.

Folder `public/build/` harus diupload karena asset sudah dibuild lokal.

## 9. Import Database ke phpMyAdmin

Di InfinityFree Control Panel:

1. Buka `phpMyAdmin`.
2. Pilih database yang tadi dibuat.
3. Klik tab `Import`.
4. Pilih file:

```text
himashift.sql
```

5. Klik `Go`.

Setelah import, cek tabel berikut ada:

```text
mahasiswa
divisi
mahasiswa_divisi
event
absen
kehadiran
users
```

Untuk deploy mahasiswa dulu, tabel `users` tetap boleh ada walaupun dipakai app admin nanti.

## 10. Aktifkan SSL

Di InfinityFree Client Area:

1. Pilih domain `himashift.infinityfree.me`.
2. Buka menu `SSL Certificates`.
3. Buat SSL certificate.
4. Ikuti instruksi verifikasi.
5. Install certificate.
6. Tunggu sampai HTTPS aktif.

Setelah SSL aktif, buka:

```text
https://himashift.infinityfree.me
```

## 11. Smoke Test Mahasiswa

Cek halaman publik:

```text
https://himashift.infinityfree.me/
https://himashift.infinityfree.me/anggota
```

Expected:

- `/` tampil halaman login.
- `/anggota` tampil daftar anggota.

Cek protected route:

```text
https://himashift.infinityfree.me/dashboard
```

Expected:

- redirect ke login.

Login mahasiswa:

```text
NIM: F1E120002
Password: 12345678
```

Setelah login, cek:

```text
/dashboard
/dashboard/profil
/dashboard/absensi
/dashboard/event
/dashboard/sertifikat
```

## 12. Test Sertifikat PDF

Masuk ke:

```text
https://himashift.infinityfree.me/dashboard/sertifikat
```

Isi:

```text
Job Desk: Tester
Nama Acara: Test Portfolio
Tanggal: 2026-04-30
```

Klik download/generate.

Expected:

- Browser membuka PDF.
- PDF tidak kosong.
- Nama mahasiswa muncul.
- Nama acara dan tanggal muncul.

## 13. Cek Error Log

Kalau muncul 500:

1. Pastikan `APP_DEBUG=false` tetap false.
2. Buka file log di:

```text
storage/logs/
```

3. Cek error terbaru.

Penyebab umum:

- `APP_KEY` kosong.
- DB credential salah.
- `vendor/` tidak terupload.
- `public/build/` tidak terupload.
- `.htaccess` root belum ada.
- SSL belum aktif tapi redirect HTTPS sudah dipaksa.

## 14. Cek Security Header

Dari lokal, jalankan:

```bash
curl -I https://himashift.infinityfree.me
```

Minimal header yang diharapkan:

```text
X-Frame-Options: SAMEORIGIN
X-Content-Type-Options: nosniff
Strict-Transport-Security: max-age=31536000; includeSubDomains
```

Kalau header belum ada, cek apakah `.htaccess` root sudah terupload dan apakah `mod_headers` didukung.

## 15. Checklist Browser Manual

Buka Chrome DevTools.

Checklist:

- [ ] Login page tampil.
- [ ] CSS Bootstrap load.
- [ ] Logo/favicon tampil.
- [ ] Tidak ada error merah di Console.
- [ ] Tidak ada asset 404 di Network.
- [ ] Login mahasiswa berhasil.
- [ ] Profil menampilkan NIM yang benar.
- [ ] Event tampil.
- [ ] Absensi tampil.
- [ ] Sertifikat PDF berhasil dibuka.
- [ ] Mobile viewport 375px masih bisa dipakai.

## 16. Setelah Mahasiswa Berhasil

Baru lanjut deploy admin.

Rekomendasi domain admin di InfinityFree free plan:

```text
https://admin-himashift.infinityfree.me
```

Bukan:

```text
https://admin.himashift.infinityfree.me
```

Alasannya: `admin.himashift.infinityfree.me` adalah sub-subdomain, dan pada akun baru InfinityFree biasanya tidak mendukung sub-subdomain.

## Referensi

- InfinityFree menyediakan PHP, MySQL/MariaDB, SSL, dan `.htaccess` support.
- InfinityFree free hosting tidak menyediakan SSH/Composer, jadi Laravel dependency harus disiapkan lokal dan diupload.
- Laravel di InfinityFree perlu `.htaccess` root untuk rewrite request ke `public/`.
- Untuk free subdomain, gunakan domain terpisah seperti `himashift.infinityfree.me`; sub-subdomain seperti `admin.himashift.infinityfree.me` biasanya tidak didukung.
