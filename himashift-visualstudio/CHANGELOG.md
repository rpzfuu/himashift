# CHANGELOG

## 2026-04-30

### Fixed

- Updated MySQL connection strings to use `Pwd=rafumazta`.
- Wrapped MySQL connection/command/data-reader/data-adapter usage in `using`.
- Fixed absensi update to target the selected `id_absen`.
- Fixed admin login for current Laravel seed hash without adding production packages.
- Removed nullable build warnings.
- Excluded `HIMASHIFT.Tests` source files from main WinForms project compile.

### Added

- `HIMASHIFT.Tests` xUnit project with 13 database-backed tests.
- `himashift_test` database for test execution.
- `db\himashift-dump.sql`.
- L1-L12 reports and summary.
- Deployment, architecture, status, archive notes, and release documentation.

### Release

- Published self-contained win-x64 single-file EXE:

```text
bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe
```

