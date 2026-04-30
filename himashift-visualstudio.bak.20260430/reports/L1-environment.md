# L1 - Toolchain & Environment Audit

Tanggal audit: 2026-04-30
Project: `C:\nginx\html\himashift\himashift-visualstudio`

## Ringkasan

Status L1: PASS WITH WARNINGS

- Project dapat di-restore dan di-build memakai .NET SDK 6.0.428 yang dipasang lokal-user.
- Visual Studio Community 2022 terdeteksi, tetapi workload `.NET desktop development` tidak terdeteksi lewat `vswhere`.
- MySQL Server lokal versi 9.7.0 terdeteksi dan dapat dihubungi dengan password root `rafumazta`.
- Package `MySql.Data` versi 8.0.33 sudah ter-restore.
- Catatan arsip: target `net6.0-windows` memakai .NET 6, yang sudah end-of-support sejak 2024-11-12.

## L1.1 - .NET 6 SDK

Perintah:

```powershell
dotnet --list-sdks
dotnet --info
```

Hasil awal:

```text
.NET SDKs installed:
  No SDKs were found.

.NET runtimes installed:
  Microsoft.NETCore.App 8.0.20
  Microsoft.NETCore.App 10.0.1
  Microsoft.WindowsDesktop.App 8.0.20
  Microsoft.WindowsDesktop.App 10.0.1
```

Tindakan:

- Installed .NET SDK 6.0.428 memakai official `dotnet-install.ps1`.
- Install location: `C:\Users\Arpeezy\AppData\Local\Microsoft\dotnet`

Verifikasi setelah install:

```powershell
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" --list-sdks
```

Output:

```text
6.0.428 [C:\Users\Arpeezy\AppData\Local\Microsoft\dotnet\sdk]
```

Status: PASS

Catatan:

- Default `dotnet` global di `C:\Program Files\dotnet` masih tidak memiliki SDK. Untuk command berikutnya gunakan `C:\Users\Arpeezy\AppData\Local\Microsoft\dotnet\dotnet.exe` atau tambahkan path tersebut ke user PATH.
- .NET 6 sudah EOL. Microsoft mencatat end-of-support .NET 6 pada 2024-11-12.
  Source: https://devblogs.microsoft.com/dotnet/dotnet-6-end-of-support/

## L1.2 - Visual Studio 2022 Desktop Workload

Perintah:

```powershell
vswhere -all -products * -format json
vswhere -all -products * -requires Microsoft.VisualStudio.Workload.ManagedDesktop -format json
```

Hasil:

```text
Visual Studio Community 2022
17.14.36518.9
```

Workload check:

```text
[]
```

Status: WARNING

Catatan:

- Visual Studio Community 2022 ada.
- Workload `.NET desktop development` tidak terdeteksi oleh `vswhere`.
- CLI build tetap berhasil dengan SDK lokal. Namun untuk WinForms Designer di Visual Studio, workload ini kemungkinan perlu dipasang dari Visual Studio Installer.

## L1.3 - Restore NuGet Packages

Perintah:

```powershell
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" restore
```

Output final:

```text
Determining projects to restore...
All projects are up-to-date for restore.
```

Package verification:

```text
obj\project.assets.json: MySql.Data/8.0.33
```

Status: PASS

Catatan:

- Ada satu percobaan awal yang gagal karena `restore` dan `build` berjalan bersamaan dan berebut file NuGet/MSBuild. Restore diulang secara tunggal dan berhasil.

## L1.4 - Build Pertama Tanpa Run

Perintah:

```powershell
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" build
```

Output penting:

```text
Build succeeded.
18 Warning(s)
0 Error(s)
```

Verifikasi incremental setelah restore:

```powershell
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" build --no-restore
```

Output:

```text
Build succeeded.
0 Warning(s)
0 Error(s)
```

Status: PASS

Catatan:

- Warning build pertama mayoritas nullable reference warning dan event handler nullability. Detail diklasifikasikan di L2.

## L1.5 - MySQL Connector vs MySQL Server

Local MySQL command:

```powershell
& "C:\Program Files\MySQL\MySQL Server 9.7\bin\mysql.exe" --version
& "C:\Program Files\MySQL\MySQL Server 9.7\bin\mysql.exe" -u root -prafumazta -e "SELECT VERSION() AS version;"
```

Output:

```text
C:\Program Files\MySQL\MySQL Server 9.7\bin\mysql.exe  Ver 9.7.0 for Win64 on x86_64 (MySQL Community Server - GPL)

version
9.7.0
```

Project connector:

```xml
<PackageReference Include="MySql.Data" Version="8.0.33" />
```

Compatibility notes:

- Oracle MySQL compatibility matrix lists MySQL Connectors 9 as compatible with MySQL Server 9 and recommends Connector 9 for that server family.
  Source: https://www.mysql.com/support/supportedplatforms/compatibility.html
- MySQL Connector/NET download page states Connector/NET 8.0+ is compatible with MySQL versions starting from 5.7, while recommending the latest Connector/NET for MySQL Server 8.0+.
  Source: https://dev.mysql.com/downloads/connector/net/8.0.html
- MySQL Connector/NET Developer Guide lists Connector/NET 8.0.33 for .NET 6/VS 2022 and recommends minimum server versions MySQL 8.0.33 or MySQL 5.7.42 for that archived connector.
  Source: https://dev.mysql.com/doc/connector-net/en/connector-net-versions.html

Status: WARNING

Catatan arsip:

- MySQL Server lokal 9.7.0 lebih baru dari connector `MySql.Data 8.0.33`.
- Untuk arsip, tetap pakai connector project saat ini. Risiko kompatibilitas dicatat; jangan upgrade package di L1.

## Kesimpulan L1

L1 selesai. Tidak ada TIER 1 project bug dari L1 karena project berhasil build.

Open items sebelum L2:

- Tambahkan SDK lokal ke user PATH bila ingin command `dotnet` biasa langsung menemukan SDK 6.0.428.
- Pasang workload `.NET desktop development` di Visual Studio Installer bila WinForms Designer akan dipakai.
- Warning build pertama masuk daftar audit L2.
