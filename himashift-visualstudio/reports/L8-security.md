# L8 - Security Surface

Tanggal audit: 2026-04-30
Status: PASS for SQL injection scan; archive risks documented.

## SQL Injection

Static scan found no SQL concatenation:

```text
SELECT.*+ / INSERT.*+ / UPDATE.*+ / DELETE.*+ / string.Format.*SELECT
```

Result: no matches.

Parameterized query coverage:

- Mahasiswa login
- Admin login
- Dashboard profile
- Dashboard header name
- Dashboard absensi list/update

## Connection String Exposure

Risk: DB password is hardcoded in source and will be recoverable from the EXE by decompilation.

Status: ARCHIVE NOTE, not fixed by design constraint.

## Input Validation

| Field | Status |
| --- | --- |
| NIM | No UI max length or format validation |
| Password | No max length validation |
| Nama | No UI max length validation |
| Sertifikat fields | UI exists, no logic |

DB edge case found: `mahasiswa.nim` is `varchar(9)`, so overly long NIM values fail at DB layer.

## Path Traversal

No file output logic exists for sertifikat. No path traversal surface found in current code.

## Admin Auth Note

The admin bcrypt fallback is intentionally narrow for the seeded Laravel admin hash. This fixes archive demo login but is not a general password verification design.

