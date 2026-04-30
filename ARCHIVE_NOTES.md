# HIMASHIFT Archive Notes

## Philosophy

This is a learning archive. The rescue pass intentionally fixes only fatal deploy blockers, broken flows, and data/security integrity issues.

## Fixed During Rescue

- Fatal route/view issues.
- Route cache blockers.
- Register exposure.
- Attendance IDOR.
- Broken model relationship.
- Certificate response robustness.
- Password reset route-name crash.
- Missing 404 behavior for invalid edit/show routes.

## Intentionally Preserved

- Plain text mahasiswa password behavior.
- Minimal validation.
- Lowercase controller naming.
- Simple Blade views and inline debug-era style.
- Small-table performance trade-offs.
- Bootstrap/Sass deprecation warnings.

## What I Would Do Differently Today

- Merge admin and mahasiswa into one Laravel app with roles/policies.
- Hash all passwords and migrate old plain passwords.
- Add request validation classes.
- Use policies for attendance ownership.
- Add factories/seeders as first-class test fixtures.
- Add production security headers centrally.
- Keep one JS package manager and one lockfile.
