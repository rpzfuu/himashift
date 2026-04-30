# L6 - Authentication & Authorization

## Auth Checks

| Case | Result |
| --- | --- |
| Admin login with `name=admin` and valid password | PASS |
| Mahasiswa login with valid NIM/password | PASS |
| Guest redirected from admin protected routes | PASS |
| Guest redirected from mahasiswa dashboard routes | PASS |
| Admin `/register` disabled | PASS |
| Mahasiswa `/register` disabled | PASS |
| Logout route exists in both apps | PASS via route map |
| CSRF missing on POST | PASS, 419 |

## IDOR

Mahasiswa logged in as `F1E120002` attempted:

`POST /dashboard/absensi/update/F1E120057/{id_absen}`

Result: 403. Fixed in `dashboardController@update`.

## Session Isolation

Cookie names observed:

- Admin: `himashift_admin_session`.
- Mahasiswa: `himashift_session`.

This supports separate sessions for the two apps.

## Not Fully Exercised

- Password reset email delivery: route renders, but actual mail transport was not tested because local mail is not configured for production delivery.
- Remember-me browser persistence: not manually exercised.
