# L2 - Static Code Analysis

Tanggal audit: 2026-04-30
Status: PASS, dengan fix TIER 2 diterapkan.

## Commands

- `dotnet build /p:TreatWarningsAsErrors=false /v:normal 2>&1 | Tee-Object -FilePath build-warnings.log`
- `rg -n "TODO|FIXME|HACK|XXX" -g "*.cs"`
- `rg -n "catch\s*\(.*\)\s*\{\s*\}" -g "*.cs"`
- `rg -n "MessageBox\.Show" -g "*.cs"`
- `rg -n "new MySqlConnection|new MySqlCommand|ExecuteReader" -g "*.cs" -C 3`
- `rg -n "[A-Z]:\\\\" -g "*.cs"`
- `rg -n 'SELECT.*\+|INSERT.*\+|UPDATE.*\+|DELETE.*\+|string\.Format.*SELECT' -g "*.cs"`

## Findings

| Finding | Tier | Result |
| --- | --- | --- |
| TODO/FIXME/HACK/XXX | TIER 3 | None found |
| Empty catch block | TIER 2 | None found |
| MessageBox error handling in login | TIER 3 | Found in `UserControls/admin.cs`, `UserControls/beranda.cs`; documented, not refactored |
| Hardcoded absolute paths | TIER 3 | None found in code |
| SQL string concatenation | TIER 2 | None found |
| SQL injection candidate | TIER 2 | No concatenated SQL found; login and profile queries use parameters |
| MySqlConnection/MySqlCommand not disposed | TIER 2 | Fixed with `using` in all DB code paths |
| Nullable warnings | TIER 3 | Fixed; final build has 0 warnings |

## Fixes Applied

- Wrapped `MySqlConnection`, `MySqlCommand`, `MySqlDataReader`, and `MySqlDataAdapter` usage in `using`.
- Set nullable properties/fields to safe defaults where needed.
- Fixed DataGridView column nullability warnings.
- Fixed dashboard absensi update so it updates the clicked `id_absen`, not every kehadiran row for the NIM.
- Added project exclusion so `HIMASHIFT.Tests/**/*.cs` is not compiled by the WinForms app project.

## Final Build

```text
Build succeeded.
0 Warning(s)
0 Error(s)
```

