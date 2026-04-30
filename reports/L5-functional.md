# L5 - Functional CRUD Test

## Admin

Semua data dummy memakai prefix `HTTP CRUD TEST` atau NIM `TST260010`, lalu dibersihkan.

| Case | Result |
| --- | --- |
| Admin login | PASS |
| Mahasiswa create | PASS |
| Mahasiswa read/list contains NIM | PASS |
| Mahasiswa update | PASS |
| Mahasiswa delete + cascade `mahasiswa_divisi`/`kehadiran` | PASS |
| Event create | PASS |
| Event update | PASS |
| Event delete | PASS |
| Absen create | PASS |
| Absen create generates 82 kehadiran rows | PASS |
| Absen update | PASS |
| Admin update kehadiran status | PASS |
| Absen delete cascades kehadiran rows | PASS |

## Mahasiswa

| Case | Result |
| --- | --- |
| Mahasiswa login | PASS |
| Submit own kehadiran | PASS |
| Submit kehadiran for other NIM | PASS, forbidden 403 |
| Generate certificate PDF | PASS, `application/pdf`, 7048 bytes |

## Cleanup Verification

Setelah test:

- `TST260010`: 0 row.
- Test event: 0 row.
- Test absen: 0 row.
- Test kehadiran by test absen: 0 row.
- Final DB counts tetap 82 mahasiswa, 7 divisi, 8 event, 0 absen, 0 kehadiran.
