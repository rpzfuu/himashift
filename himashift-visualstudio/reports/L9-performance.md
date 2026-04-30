# L9 - Performance & Memory

Tanggal audit: 2026-04-30
Status: PASS for basic scope.

## Query Shape

| Screen | Query Count by Static Review |
| --- | ---: |
| Anggota list | 1 joined query |
| Event list | 1 query |
| Profile | 1 joined query |
| Absensi | 1 joined query |
| Login mahasiswa | 1 scalar query |
| Login admin | 1 scalar query |

No N+1 pattern found for the 82-row anggota list.

## Connection Pool

All MySQL usages are now wrapped in `using`, so connections/commands are disposed.

MySQL process check after tests/smoke:

```text
Threads_connected: 1
```

Only the audit query connection was active.

## Startup

Published self-contained EXE smoke:

```text
Ready: True
MainWindowTitle: beranda
StartupSeconds: 1.76
```

Target `< 3s`: PASS on this machine.

## Memory

Full long-running memory profiling was not performed. No growing MySQL connection count was observed after automated DB tests and smoke runs.

