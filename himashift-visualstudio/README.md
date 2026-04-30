# HIMASHIFT VisualStudio

WinForms desktop archive for HIMASHIFT, sharing the same MySQL database as the Laravel HIMASHIFT apps.

## Current Status

Status: RELEASED WITH ARCHIVE NOTES

Snapshot: recovered and audited on 2026-04-30. This is an archive artifact built with `.NET 6`, which reached end-of-support on 2024-11-12.

- Target: `.NET 6.0-windows`
- UI: Windows Forms
- DB connector: `MySql.Data 8.0.33`
- Database: MySQL `himashift`
- Entry point: `Program.cs -> beranda`
- Published EXE: `bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe`
- Published EXE size: about 161 MB, expected for a self-contained WinForms build.

## Quick Start

1. Ensure MySQL is running locally.
2. Import `db\himashift-dump.sql` into database `himashift`.
3. Run:

```powershell
.\bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe
```

## Credentials

Mahasiswa:

```text
NIM: F1E120057
Password: 12345678
```

Admin:

```text
Name: admin
Password: 12345678
```

## Developer Commands

Use the local .NET 6 SDK if the global `dotnet` has no SDK:

```powershell
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" restore
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" build
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" test
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" publish HIMASHIFT.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:PublishTrimmed=false
```

## Test Result

```text
Passed: 13
Failed: 0
Skipped: 0
```

## Important Docs

- `PROJECT_STATUS.md`
- `DEPLOY.md`
- `ARCHITECTURE.md`
- `ARCHIVE_NOTES.md`
- `CHANGELOG.md`
- `reports/SUMMARY.md`

## Archive Notes

Some issues are intentionally documented instead of refactored:

- Connection string remains duplicated.
- DB password is hardcoded.
- Mahasiswa passwords are plain text.
- Admin CRUD and sertifikat generation are not implemented in this WinForms archive.
- `.NET 6` is end-of-support.

Before public distribution, rebuild with a limited demo MySQL user instead of a personal/local root password, then run an antivirus reputation scan for the final EXE.
