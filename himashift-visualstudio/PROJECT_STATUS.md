# PROJECT STATUS - HIMASHIFT VisualStudio

Tanggal status: 2026-04-30

## Status Singkat

RELEASED WITH ARCHIVE NOTES

Project WinForms sudah bisa build, test, connect ke MySQL lokal, dan dipublish sebagai single-file self-contained EXE.

## Build

```text
dotnet build HIMASHIFT.csproj -c Release
Build succeeded.
0 Warning(s)
0 Error(s)
```

## Tests

```text
dotnet test
Passed: 13
Failed: 0
Skipped: 0
```

## Release Artifact

```text
bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe
```

Size:

```text
161,403,517 bytes
```

## Database

- Main DB: `himashift`
- Test DB: `himashift_test`
- Dump: `db\himashift-dump.sql`
- Local MySQL tested: 9.7.0
- Connector: `MySql.Data 8.0.33`

## Fixed

- DB password updated from empty password to `rafumazta`.
- MySQL connections/commands disposed with `using`.
- Absensi update now targets clicked attendance row by `nim + id_absen`.
- Admin login works against current Laravel seed bcrypt hash.
- Nullable/compiler warnings cleaned.
- xUnit test project added.

## Known Archive Gaps

- Admin CRUD is not implemented in this WinForms archive.
- Sertifikat download/generation is not implemented.
- Connection string remains duplicated by design.
- DB password is hardcoded.
- Mahasiswa password remains plain text.
- .NET 6 is end-of-support.

