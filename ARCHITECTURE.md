# HIMASHIFT Architecture

## Shape

HIMASHIFT is two Laravel 10 apps sharing one MySQL database.

```text
himashift-admin        himashift-mahasiswa
       |                       |
       +----------+------------+
                  |
              MySQL DB
              himashift
```

## Apps

- `himashift-admin`: admin CRUD for mahasiswa, event, absen, and kehadiran status.
- `himashift-mahasiswa`: public login, anggota page, dashboard, profile, attendance submit, event list, certificate PDF.

## Auth

- Admin login uses `users.name` and Laravel hashed `users.password`.
- Mahasiswa login uses `mahasiswa.nim` and the archive's plain password comparison.
- Sessions are isolated by app name/cookie:
  - `himashift_admin_session`.
  - `himashift_session`.

## Main Data Flow

1. Admin creates mahasiswa and assigns divisi.
2. Admin creates absen.
3. Admin app creates one `kehadiran` row per mahasiswa for that absen.
4. Mahasiswa opens `/dashboard/absensi`.
5. Mahasiswa submits own attendance.
6. Admin can review/update status in `/home/kehadiran`.

## Certificate Flow

1. Mahasiswa opens `/dashboard/sertifikat`.
2. Mahasiswa submits jobdesk, acara, tanggal.
3. TCPDF generates inline PDF response.

## Core Tables

- `users`.
- `mahasiswa`.
- `divisi`.
- `mahasiswa_divisi`.
- `event`.
- `absen`.
- `kehadiran`.
