# L7 - Data Flow Integration Test

Tanggal audit: 2026-04-30
Status: PARTIAL PASS

## Shared DB

The WinForms app connects to the same `himashift` MySQL database used by Laravel.

Validated:

- `mahasiswa`: 82 rows available to desktop.
- `event`: 8 rows available to desktop.
- `users`: admin row available, password hash handled by desktop fallback.
- FK relations match app queries.

## Transaction Simulation

A rollback transaction inserted temporary mahasiswa, divisi membership, absen, and kehadiran rows, then updated kehadiran using the fixed `nim + id_absen` condition.

Result:

```text
updated_status: Hadir
kehadiran_after_delete: 0
temp_after_rollback: 0
```

## Cascade Delete

Foreign keys:

| Constraint | Delete Rule |
| --- | --- |
| `kehadiran_nim_foreign` | CASCADE |
| `kehadiran_id_absen_foreign` | CASCADE |
| `mahasiswa_divisi_nim_foreign` | CASCADE |
| `mahasiswa_divisi_id_divisi_foreign` | CASCADE |

Result: PASS.

## Charset

CLI mysql display showed mojibake for `Müller açai`, but xUnit via `MySql.Data` round-tripped the string correctly in `himashift_test`. Result: PASS for application connector path.

## Not Executed

Live Laravel browser workflow was not run in this CLI pass. DB-level shared integration was validated directly.

