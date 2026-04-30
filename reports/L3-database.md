# L3 - Database Integrity Audit

## Schema dan Migrasi

- `php artisan migrate:status`: semua migration sudah `Ran` di dua app.
- Database aktif: `himashift`.
- Charset database: `utf8mb4`.
- Collation database: `utf8mb4_unicode_ci`.

## Data Setelah Seeder

- Mahasiswa: 82.
- Divisi: 7.
- User admin: 1.
- Event: 8.
- Absen: 0.
- Kehadiran: 0.
- Mahasiswa-divisi: 82.

## Foreign Key

Terverifikasi di `information_schema`:

- `kehadiran.nim` -> `mahasiswa.nim`.
- `kehadiran.id_absen` -> `absen.id_absen`.
- `mahasiswa_divisi.nim` -> `mahasiswa.nim`.
- `mahasiswa_divisi.id_divisi` -> `divisi.id_divisi`.

## Integrity Checks

- Orphan `mahasiswa_divisi`: 0.
- Orphan `kehadiran`: 0.
- Duplicate NIM: 0.
- Cascade delete mahasiswa: PASS, dummy transaction menghasilkan 0 orphan.
- UTF-8/emoji write test: PASS di DB, terminal Windows menampilkan emoji sebagai `??`.

## Index Notes

- `mahasiswa.nim`: primary key.
- `users.email`: unique.
- `event.tanggal`: belum ada index. Dibiarkan sebagai quality/performance note karena data arsip kecil.
- `users.name`: belum ada index walau dipakai login admin. Dibiarkan sebagai quality/performance note.

## Backup

Dump/drop/import tidak dijalankan otomatis karena destruktif untuk DB lokal. Strategi dump dicatat di `DEPLOY.md`.
