# L4 - Form Lifecycle Smoke Test

Tanggal audit: 2026-04-30
Status: PARTIAL PASS

## Automated Smoke

Final published executable:

```text
bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe
```

Smoke result:

```text
ProcessName     : HIMASHIFT
Ready           : True
MainWindowTitle : beranda
StartupSeconds  : 1.76
```

Result: PASS. App starts and opens the `beranda` form without crashing.

## Navigation Matrix

| Area | Button/Menu | Automated Result |
| --- | --- | --- |
| `beranda` form | initial load | PASS, main window opens |
| `beranda` form | `btn_beranda` | Code creates `UserControls.beranda`; static check PASS |
| `beranda` form | `btn_anggota` | Code creates `UserControls.anggota`; DB query validated |
| `beranda` form | `btn_admin` | Code creates `UserControls.admin`; login logic fixed |
| `beranda` form | `btn_exit` | Calls `Close()` |
| `dashboard` form | Profil/Absensi/Event/Sertifikat | Code creates corresponding UserControls |
| `admindashboard` form | Mahasiswa | Handler exists but empty |
| `admindashboard` form | Event/Absensi/Kehadiran | Buttons exist but no click handlers |

## Limitation

Manual click-by-click UI testing was not executed because this run was done from CLI automation. The process/window lifecycle was tested, and DB-backed query paths were covered by xUnit and direct DB checks.

