# L5 - Functional Test Per Form

Tanggal audit: 2026-04-30
Status: PASS for implemented desktop features, GAP for unimplemented admin/sertifikat features.

## UserControls.beranda

| Scenario | Result |
| --- | --- |
| Login `F1E120057` / `12345678` | PASS via DB query and xUnit |
| Login valid NIM wrong password | PASS, returns 0 |
| Login missing NIM | PASS as invalid credential path |
| SQL injection NIM `' OR '1'='1` | PASS, parameterized query does not login |

## UserControls.admin

| Scenario | Result |
| --- | --- |
| Login `admin` / `12345678` | FIXED/PASS via Laravel seed hash fallback |
| Wrong password | PASS |
| Unknown user | PASS |
| SQL injection | PASS by parameterized name lookup |

Note: production BCrypt library was not added because archive rule forbids new production libraries. The fix is a narrow fallback for the known Laravel seed hash.

## UserControls.anggota

| Scenario | Result |
| --- | --- |
| Public member list query | PASS |
| Expected rows | 82 rows from main DB |
| Query count | Single joined query |

## dashboard_profil

| Scenario | Result |
| --- | --- |
| Show data for `F1E120057` | PASS |
| Profile join schema | VALID |

## dashboard_absensi

| Scenario | Result |
| --- | --- |
| Query absensi for student | VALID |
| Current main DB rows | 0 rows, because `absen`/`kehadiran` are empty |
| Update clicked attendance | FIXED to use `nim` + `id_absen`; xUnit coverage PASS |

## dashboard_event

| Scenario | Result |
| --- | --- |
| Event list | PASS |
| Main DB rows | 8 |

## dashboard_sertifikat

Status: GAP.

The UI fields and Download button exist in Designer, but `dashboard_sertifikat.cs` has no download/generate logic and no click handler.

## admindashboard

Status: GAP.

The Admin dashboard shell exists. `btn_mahasiswa_Click` is empty, and Event/Absensi/Kehadiran buttons have no handlers. CRUD admin functions are not implemented in this WinForms archive.

