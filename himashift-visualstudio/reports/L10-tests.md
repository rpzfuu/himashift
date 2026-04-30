# L10 - Unit Test Suite

Tanggal audit: 2026-04-30
Status: PASS

## Test Project

Created:

```text
HIMASHIFT.Tests/
```

Configuration:

- xUnit
- Target framework: `net6.0-windows`
- References `../HIMASHIFT.csproj`
- Uses `MySql.Data 8.0.33`
- Test database: `himashift_test`

Main app project excludes `HIMASHIFT.Tests/**/*.cs` from compile to avoid SDK-style recursive include collisions.

## Test Database

Created:

```sql
CREATE DATABASE himashift_test CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
```

Schema imported from `himashift` with `mysqldump --no-data`.

## Test Results

Command:

```powershell
dotnet test /v:normal
```

Result:

```text
Passed! - Failed: 0, Passed: 13, Skipped: 0, Total: 13
Build succeeded.
0 Warning(s)
0 Error(s)
```

## Covered Tests

- Can connect to `himashift_test`
- Wrong DB password throws
- Get mahasiswa by NIM
- Invalid NIM returns null
- Valid mahasiswa credentials pass
- Invalid password fails
- SQL injection literal does not login
- Admin Laravel seed hash fallback works
- Event query returns rows
- Absensi query returns expected count
- Insert kehadiran saves correctly
- Delete mahasiswa cascades to kehadiran
- utf8mb4 name round-trips via `MySql.Data`

