# L11 - Distribution Test

Tanggal audit: 2026-04-30
Status: PASS locally, clean-machine/VM test not executed.

## Publish

Command:

```powershell
dotnet publish HIMASHIFT.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:PublishTrimmed=false
```

Output:

```text
bin\Release\net6.0-windows\win-x64\publish\HIMASHIFT.exe
```

Size:

```text
161,403,517 bytes
```

## Smoke

Published EXE starts:

```text
ProcessName: HIMASHIFT
MainWindowTitle: beranda
StartupSeconds: 1.76
```

## Clean Machine Test

Not executed in this environment. Expected distribution assumptions:

- The EXE is self-contained and should not require .NET runtime installation.
- The app still requires access to MySQL database `himashift`.
- Current connection string expects local MySQL root password `rafumazta`.

## Antivirus

VirusTotal check not executed. Self-contained single-file Windows EXEs can trigger false positives; documented in `DEPLOY.md`.

