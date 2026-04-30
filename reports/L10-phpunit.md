# L10 - PHPUnit Feature Test Suite

PHPUnit configured to use SQLite in-memory for both apps.

## Admin

Command:

```bash
php artisan test
```

Result: PASS.

- 12 tests passed.
- 51 assertions.
- Feature coverage added in `tests/Feature/AdminArchiveFlowTest.php`.

Covered:

- Admin login with `name`.
- Register disabled.
- Guest protected-route redirects.
- Auth home redirect.
- Mahasiswa create/update/delete.
- Invalid edit/show 404 instead of 500.
- Event create/update/delete.
- Absen create/delete cascade.
- Kehadiran status update.
- `Kehadiran::absen` relation.

## Mahasiswa

Command:

```bash
php artisan test
```

Result: PASS.

- 11 tests passed.
- 32 assertions.
- Feature coverage added in `tests/Feature/MahasiswaArchiveFlowTest.php`.

Covered:

- Login page/public anggota.
- Register disabled.
- Login with NIM/plain password.
- Wrong password rejected.
- Guest dashboard redirects.
- Authenticated dashboard/profil/absensi/event/sertifikat pages.
- Own attendance submit.
- IDOR attendance blocked.
- PDF certificate generation.

## Warning

PHP 8.5.2 emits a deprecation warning from `nunomaduro/collision`. Tests still pass. PHP 8.2/8.3 recommended for hosting.
