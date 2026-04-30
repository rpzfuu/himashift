# HIMASHIFT Desktop

HIMASHIFT Desktop adalah aplikasi Windows Forms untuk arsip/demo lokal HIMASHIFT. Aplikasi ini memakai database MySQL `himashift` yang sama dengan dua aplikasi Laravel.

Dokumentasi ini ditujukan untuk pengguna teknis, operator demo, dan developer yang perlu menjalankan, menguji, membangun, atau mendistribusikan aplikasi desktop.

## Status

- Status rilis: released with archive notes.
- Snapshot audit: 2026-04-30.
- Target framework: `.NET 6.0-windows`.
- UI: Windows Forms.
- DB connector: `MySql.Data 8.0.33`.
- Entry point: `Program.cs -> beranda`.
- Published EXE: `bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe`.
- Ukuran EXE: sekitar 161 MB, wajar untuk build WinForms self-contained.

Catatan: `.NET 6` sudah end-of-support sejak 2024-11-12. Migrasi ke target framework yang masih didukung disarankan untuk pengembangan jangka panjang.

## Menjalankan Aplikasi Rilis

Prasyarat:

- Windows x64.
- MySQL berjalan di `localhost:3306`.
- Database bernama `himashift`.

Siapkan database demo:

```powershell
mysql -u root -p -e "CREATE DATABASE IF NOT EXISTS himashift CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;"
mysql -u root -p himashift < .\db\himashift-dump.sql
```

Jalankan EXE:

```powershell
.\bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe
```

Build rilis bersifat self-contained, sehingga pengguna tidak perlu menginstall .NET Runtime terpisah untuk menjalankan EXE.

## Akun Demo

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

Credential demo hanya untuk development, testing, atau demo lokal.

## Konfigurasi Database

Connection string desktop saat ini mengarah ke:

```text
Host: localhost
Port: 3306
Database: himashift
User: root
Password: rafumazta
```

Untuk distribusi publik, gunakan user MySQL demo dengan hak akses terbatas, ubah connection string, lalu build ulang EXE. Jangan mendistribusikan credential root atau credential personal.

## Setup Developer

Restore dependency:

```powershell
dotnet restore
```

Build project:

```powershell
dotnet build
```

Jalankan test:

```powershell
dotnet test
```

Jika `dotnet` global tidak memiliki SDK .NET 6, gunakan SDK lokal:

```powershell
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" restore
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" build
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" test
```

## Publish EXE

```powershell
dotnet publish HIMASHIFT.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:PublishTrimmed=false
```

Jika memakai SDK lokal:

```powershell
& "$env:LOCALAPPDATA\Microsoft\dotnet\dotnet.exe" publish HIMASHIFT.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:PublishTrimmed=false
```

Artefak publish:

- `bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe`
- `db\himashift-dump.sql`

## Test Result

Snapshot terakhir:

```text
Passed: 13
Failed: 0
Skipped: 0
```

Jalankan ulang `dotnet test` setelah mengubah form, validasi login, query database, atau helper akses data.

## Batasan Arsip

Beberapa batasan sengaja didokumentasikan agar karakter proyek arsip tetap jelas:

- Connection string masih tersebar di beberapa bagian kode.
- Password database masih hardcoded.
- Password mahasiswa pada data arsip masih plain text.
- CRUD admin dan generate sertifikat tidak diimplementasikan di aplikasi desktop.
- Target framework `.NET 6` sudah end-of-support.

## Catatan Distribusi

Sebelum mendistribusikan EXE ke pengguna lain:

- Rebuild dengan credential database demo yang terbatas.
- Sertakan dump database demo tanpa data sensitif.
- Jalankan `dotnet test`.
- Jalankan smoke test EXE di Windows x64.
- Lakukan antivirus reputation scan pada artefak final.

## Dokumentasi Terkait

- [../README.md](../README.md): dokumentasi utama repository.
- [../PROJECT_STATUS.md](../PROJECT_STATUS.md): status teknis terbaru.
- [../ARCHITECTURE.md](../ARCHITECTURE.md): arsitektur dan flow data.
- [../ARCHIVE_NOTES.md](../ARCHIVE_NOTES.md): catatan arsip dan trade-off.
- [../CHANGELOG.md](../CHANGELOG.md): riwayat perubahan.
- [DEPLOY.md](DEPLOY.md): catatan distribusi EXE desktop.
