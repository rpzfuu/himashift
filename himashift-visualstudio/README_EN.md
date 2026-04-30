# HIMASHIFT Desktop

Language: [ID](README.md) | [EN](README_EN.md)

HIMASHIFT Desktop is a Windows Forms application for local HIMASHIFT archive/demo usage. It uses the same MySQL `himashift` database as the two Laravel applications.

This documentation is intended for technical users, demo operators, and developers who need to run, test, build, or distribute the desktop application.

## Status

- Release status: released with archive notes.
- Audit snapshot: 2026-04-30.
- Target framework: `.NET 6.0-windows`.
- UI: Windows Forms.
- DB connector: `MySql.Data 8.0.33`.
- Entry point: `Program.cs -> beranda`.
- Published EXE: `bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe`.
- EXE size: about 161 MB, expected for a self-contained WinForms build.

Note: `.NET 6` has been end-of-support since 2024-11-12. Migrating to a supported target framework is recommended for long-term development.

## Running The Release App

Requirements:

- Windows x64.
- MySQL running at `localhost:3306`.
- A database named `himashift`.

Prepare the demo database:

```powershell
mysql -u root -p -e "CREATE DATABASE IF NOT EXISTS himashift CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;"
mysql -u root -p himashift < .\db\himashift-dump.sql
```

Run the EXE:

```powershell
.\bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe
```

The release build is self-contained, so users do not need to install a separate .NET Runtime to run the EXE.

## Demo Accounts

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

Demo credentials are intended only for development, testing, or local demos.

## Database Configuration

The current desktop connection string points to:

```text
Host: localhost
Port: 3306
Database: himashift
User: root
Password: rafumazta
```

For public distribution, use a limited demo MySQL user, update the connection string, and rebuild the EXE. Do not distribute root or personal credentials.

## Developer Setup

Restore dependencies:

```powershell
dotnet restore
```

Build the project:

```powershell
dotnet build
```

Run tests:

```powershell
dotnet test
```

If the global `dotnet` command does not have the .NET 6 SDK, use the local SDK:

```powershell
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" restore
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" build
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" test
```

## Publish EXE

```powershell
dotnet publish HIMASHIFT.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:PublishTrimmed=false
```

If using the local SDK:

```powershell
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" publish HIMASHIFT.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:PublishTrimmed=false
```

Published artifacts:

- `bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe`
- `db\himashift-dump.sql`

## Test Result

Latest snapshot:

```text
Passed: 13
Failed: 0
Skipped: 0
```

Run `dotnet test` again after changing forms, login validation, database queries, or data access helpers.

## Archive Limitations

Some limitations are intentionally documented to keep the archive nature of the project clear:

- The connection string is still duplicated in several code areas.
- The database password is still hardcoded.
- Student passwords in the archive data are still plain text.
- Admin CRUD and certificate generation are not implemented in the desktop app.
- Target framework `.NET 6` is end-of-support.

## Distribution Notes

Before distributing the EXE to other users:

- Rebuild with limited demo database credentials.
- Include a demo database dump without sensitive data.
- Run `dotnet test`.
- Run an EXE smoke test on Windows x64.
- Run an antivirus reputation scan on the final artifact.

## Related Documentation

- [../README_EN.md](../README_EN.md): main repository documentation.
- [../PROJECT_STATUS.md](../PROJECT_STATUS.md): latest technical status.
- [../ARCHITECTURE.md](../ARCHITECTURE.md): architecture and data flow.
- [../ARCHIVE_NOTES.md](../ARCHIVE_NOTES.md): archive notes and trade-offs.
- [../CHANGELOG.md](../CHANGELOG.md): change history.
- [DEPLOY.md](DEPLOY.md): desktop EXE distribution notes.
