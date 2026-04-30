# L7 - Integration / Cross-App Data Flow

## Tested

| Scenario | Result |
| --- | --- |
| Admin creates mahasiswa, DB row appears, delete removes related row | PASS |
| Admin creates absen, app creates kehadiran rows for all 82 mahasiswa | PASS |
| Mahasiswa submits kehadiran, admin-shared DB updates status to `Hadir` | PASS |
| Admin updates kehadiran status through custom PATCH route | PASS |
| Admin deletes absen, kehadiran rows cascade to 0 | PASS |
| Mahasiswa generates PDF certificate from own session user | PASS |

## Cross-App DB

Both apps use the same database name `himashift`, so admin-created absen/event/mahasiswa are visible to mahasiswa app.

## Not Run Automatically

- Concurrent admin update.
- MySQL shutdown/recovery.
- Full backup drop/import simulation.

These are documented as manual/deploy checks because they are risky against the local DB.
