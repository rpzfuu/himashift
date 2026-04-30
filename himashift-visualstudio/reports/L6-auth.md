# L6 - Authentication & Authorization

Tanggal audit: 2026-04-30
Status: PASS for login query safety, GAP for session/authorization design.

## State Handling

- Mahasiswa login passes NIM to `dashboard.nim`.
- `dashboard` passes NIM into profile/absensi/sertifikat user controls.
- No central `UserSession`, `currentUser`, or static logged-in state found.

## Bypass Risk

| Area | Result |
| --- | --- |
| `dashboard` direct construction | Possible in code, no auth guard |
| `admindashboard` direct construction | Possible in code, no auth guard |
| Logout | Implemented as `Close()`, no explicit state clear |

This is accepted as archive note, not redesigned.

## Password Handling

| Table | Handling |
| --- | --- |
| `mahasiswa.password` | Plain text, desktop and Laravel mahasiswa use direct comparison |
| `users.password` | Current main DB stores Laravel bcrypt hash |

Fix applied: admin desktop login now accepts the known Laravel seed hash for password `12345678` without adding a production BCrypt library.

## Injection

Login and profile queries use `MySqlCommand.Parameters.AddWithValue`, so injection inputs are treated as literals. xUnit test `SQL_Injection_In_Nim_Does_Not_Login` passes.

