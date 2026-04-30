# L4 - HTTP Smoke Test

Server sementara:

- Admin: `http://127.0.0.1:18081`.
- Mahasiswa: `http://127.0.0.1:18082`.

Server sudah dimatikan setelah test.

## Public Routes

| App | Method | Path | Expected | Actual |
| --- | --- | --- | --- | --- |
| Mahasiswa | GET | `/` | 200 | 200 |
| Mahasiswa | GET | `/anggota` | 200 | 200 |
| Mahasiswa | GET | `/dashboard` | 302 | 302 |
| Mahasiswa | GET | `/password/reset` | 200 | 200 |
| Mahasiswa | GET | `/register` | 404 | 404 |
| Admin | GET | `/login` | 200 | 200 |
| Admin | GET | `/home` | 302 | 302 |
| Admin | GET | `/register` | 404 | 404 |
| Admin | DELETE | `/` | 405 | 405 |
| Mahasiswa | POST | `/dashboard/absensi/update/F1E120002/1` tanpa CSRF | 419 | 419 |

## Authenticated Routes

Admin login dan mahasiswa login sukses 302.

| App | Path | Expected | Actual |
| --- | --- | --- | --- |
| Admin | `/home/mahasiswa` | 200 | 200 |
| Admin | `/home/mahasiswa/create` | 200 | 200 |
| Admin | `/home/event` | 200 | 200 |
| Admin | `/home/absen` | 200 | 200 |
| Admin | `/home/kehadiran` | 200 | 200 |
| Admin | `/home/mahasiswa/F1E120057/edit` | 200 | 200 |
| Admin | `/home/mahasiswa/INVALID/edit` | 404 | 404 |
| Admin | `/home/kehadiran/F1E120057` | 200 | 200 |
| Admin | `/home/kehadiran/F1E120057/edit` | 302 | 302 |
| Mahasiswa | `/dashboard` | 200 | 200 |
| Mahasiswa | `/dashboard/profil` | 200 | 200 |
| Mahasiswa | `/dashboard/absensi` | 200 | 200 |
| Mahasiswa | `/dashboard/event` | 200 | 200 |
| Mahasiswa | `/dashboard/sertifikat` | 200 | 200 |
| Mahasiswa | `/dashboard/sertifikat/generate` | 200 | 200 |
