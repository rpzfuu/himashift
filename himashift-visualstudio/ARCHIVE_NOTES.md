# ARCHIVE NOTES - HIMASHIFT VisualStudio

These notes are intentional learning artifacts. They are documented, not fully refactored.

## Intentionally Not Refactored

- Connection string is repeated in multiple files.
- No centralized config/helper class for DB access.
- Form and class names keep original casing/naming.
- UI uses MessageBox for login errors.

## Security Learning Notes

- DB password is hardcoded in source and EXE.
- A decompiler can recover connection details from the published binary.
- Mahasiswa passwords are plain text in `mahasiswa.password`.
- Admin desktop login uses a narrow fallback for the current Laravel seed bcrypt hash because no production library was added.
- Desktop app has no central authorization guard; forms can be constructed directly from code.

## Quality Notes

- `.NET 6` reached end-of-support on 2024-11-12.
- Local MySQL Server is 9.7.0 while connector is `MySql.Data 8.0.33`.
- WinForms Designer workload was not detected by `vswhere`, although CLI build works.
- Input validation is minimal; DB constraints catch some invalid values such as NIM length.

## Functional Gaps

- Admin CRUD screens are not implemented in the WinForms archive.
- `admindashboard` has menu buttons, but only `Mahasiswa` has a handler and that handler is empty.
- `dashboard_sertifikat` has UI fields and a Download button but no generation/download logic.
- Live manual click-through and clean-machine VM tests were not executed in this CLI run.

