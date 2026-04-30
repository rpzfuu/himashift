# L9 - Performance & Query Audit

## Local Response Times

| URL | Status | Time |
| --- | --- | --- |
| Admin `/login` | 200 | 0.077 s |
| Mahasiswa `/` | 200 | 0.036 s |
| Mahasiswa `/anggota` | 200 | 0.047 s |

Target lokal `< 1s`: PASS.

## Build Assets

Production build succeeded in both apps.

- CSS: `app-070655a4.css`, 227523 bytes.
- JS: `app-8feae5fb.js`, 120429 bytes.
- `manifest.json`: generated.

## Notes

- Sass emits deprecation warnings from Bootstrap/Sass dependencies. Not fatal.
- Admin `mahasiswaController@index` uses `with('divisi')`, so main mahasiswa list avoids obvious divisi N+1.
- Some relation access in Blade still can query lazily, but data size is small and archive principle says do not refactor quality-only issues.
