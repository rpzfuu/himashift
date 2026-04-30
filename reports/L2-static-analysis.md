# L2 - Static Code Analysis

## Hasil

- `php -l`: PASS pada dua app.
- `php artisan view:cache`: PASS pada dua app.
- Route list berhasil dibuat untuk dua app.
- Asset hardcoded utama di `public/` ditemukan.
- `php artisan route:cache`: PASS pada dua app setelah fix duplicate route name.

## Bug Fatal/Integrity Yang Difix

- Admin `Auth::routes()` membuka `/register`. Diubah ke `Auth::routes(['register' => false])`.
- Admin punya dua route bernama `home`, membuat `route:cache` gagal. `/home` tetap ada, tetapi tidak lagi memakai nama duplikat.
- Admin custom PATCH kehadiran berada di luar middleware `auth`. Dipindahkan ke group `auth`.
- Admin custom PATCH kehadiran memakai nama `kehadiran.update` yang bentrok dengan resource route. Diganti menjadi `kehadiran.status.update`.
- `Kehadiran::absen()` di dua app menunjuk `Absen::class` yang tidak ada. Diganti ke `Absensi::class`.
- Mahasiswa password reset route tidak punya nama `password.email`, `password.request`, `password.reset`, `password.update`, menyebabkan `/password/reset` 500. Nama route ditambahkan.
- Mahasiswa `CertificateController@generate()` membuka view sertifikat tanpa `$mahasiswa`, berpotensi 500. Sekarang memakai user session.
- Admin invalid edit/show route sekarang memakai `firstOrFail()` agar 404, bukan 500.
- Admin `kehadiranController` create/store/edit tidak lagi memberi response kosong atau view tidak ada.

## Catatan Arsip

- Ada unused import seperti `MahasiswaAbsensi`; tidak difix karena tidak fatal.
- Naming controller lowercase (`mahasiswaController`) dibiarkan sebagai bagian arsip.
