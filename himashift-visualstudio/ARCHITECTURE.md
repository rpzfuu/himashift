# ARCHITECTURE - HIMASHIFT VisualStudio

## Runtime Shape

```text
Program.cs
  -> beranda Form
      -> UserControls.beranda  (mahasiswa login)
      -> UserControls.anggota  (public anggota list)
      -> UserControls.admin    (admin login)

UserControls.beranda
  -> dashboard Form
      -> dashboard_profil
      -> dashboard_absensi
      -> dashboard_event
      -> dashboard_sertifikat

UserControls.admin
  -> admindashboard Form
```

## Database

All implemented data access uses MySQL database `himashift` through `MySql.Data 8.0.33`.

Connection string pattern:

```text
Server=localhost;Port=3306;Database=himashift;Uid=root;Pwd=rafumazta;
```

## Main Queries

| Component | Tables |
| --- | --- |
| Mahasiswa login | `mahasiswa` |
| Admin login | `users` |
| Anggota list | `mahasiswa`, `mahasiswa_divisi`, `divisi` |
| Dashboard header | `mahasiswa` |
| Profile | `mahasiswa`, `mahasiswa_divisi`, `divisi` |
| Absensi | `mahasiswa`, `kehadiran`, `absen` |
| Event | `event` |

## Test Architecture

`HIMASHIFT.Tests` is an xUnit project targeting `net6.0-windows`.

It uses a real MySQL database:

```text
himashift_test
```

The test database uses the same schema as the main database and seed data created by the test fixture.

