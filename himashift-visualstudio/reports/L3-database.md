# L3 - Database Connection & Schema Audit

Tanggal audit: 2026-04-30
Status: PASS, dengan fix TIER 1/TIER 2 diterapkan.

## Connection String

Backup dibuat:

```text
C:\nginx\html\himashift\himashift-visualstudio.bak.20260430
```

Semua connection string `.cs` sudah memakai:

```text
Server=localhost;Port=3306;Database=himashift;Uid=root;Pwd=rafumazta;
```

Catatan archive: connection string tetap sengaja diulang di beberapa file. Tidak direfactor ke helper/config agar bentuk archive pembelajaran tetap terlihat.

## Database

Command:

```powershell
mysql.exe -u root -prafumazta -e "USE himashift; SHOW TABLES;"
```

Tables found: `absen`, `divisi`, `event`, `failed_jobs`, `kehadiran`, `mahasiswa`, `mahasiswa_divisi`, `migrations`, `password_reset_tokens`, `password_resets`, `personal_access_tokens`, `users`.

## Row Counts

| Table | Count |
| --- | ---: |
| mahasiswa | 82 |
| users | 1 |
| event | 8 |
| absen | 0 |
| kehadiran | 0 |

## Query vs Schema

| Code | Query Target | Status |
| --- | --- | --- |
| `dashboard.cs` | `mahasiswa.nama`, `mahasiswa.nim` | VALID |
| `UserControls/beranda.cs` | `mahasiswa.nim`, `mahasiswa.password` | VALID |
| `UserControls/admin.cs` | `users.name`, `users.password` | VALID |
| `UserControls/anggota.cs` | `mahasiswa`, `mahasiswa_divisi`, `divisi` | VALID |
| `UserControls/dashboard_profil.cs` | `mahasiswa`, `mahasiswa_divisi`, `divisi` | VALID |
| `UserControls/dashboard_event.cs` | `event.nama_acara`, `event.tanggal`, `event.ketua_pelaksana` | VALID |
| `UserControls/dashboard_absensi.cs` | `absen.id_absen`, `kehadiran.status_kehadiran` | VALID |

## Notes

- MySQL CLI warning about password on command line is expected for this audit.
- `himashift_test` created for xUnit, schema imported from `himashift`.

