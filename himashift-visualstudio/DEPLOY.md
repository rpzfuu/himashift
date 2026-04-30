# DEPLOY - HIMASHIFT VisualStudio

## Requirements

For the current archive build:

- Windows x64
- MySQL Server reachable at `localhost:3306`
- Database name: `himashift`
- MySQL user: `root`
- MySQL password: `rafumazta`

The published EXE is self-contained, so .NET runtime install should not be required for normal use.

## Import Database

From the project root:

```powershell
& "C:\Program Files\MySQL\MySQL Server 9.7\bin\mysql.exe" -u root -prafumazta -e "CREATE DATABASE IF NOT EXISTS himashift CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;"
& "C:\Program Files\MySQL\MySQL Server 9.7\bin\mysql.exe" -u root -prafumazta himashift < db\himashift-dump.sql
```

## Run App

```powershell
.\bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe
```

## Demo Credentials

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

## Distribution Options

Option A, portfolio demo:

- Host MySQL remotely.
- Update all hardcoded connection strings to remote host/user/password.
- Rebuild and republish.

Option B, local demo:

- Install MySQL locally.
- Import `db\himashift-dump.sql`.
- Keep current connection string.

## Notes

- Single-file self-contained EXE can be large and may trigger antivirus false positives.
- Current EXE size is about 161 MB.
- DB password is embedded in the EXE and should not be used for a real public deployment.
- `.NET 6` is end-of-support; future modernization should target .NET 8 or newer.
- Before publishing to a public portfolio, create a limited MySQL demo user and rebuild the EXE with that demo credential instead of `root` / `rafumazta`.
