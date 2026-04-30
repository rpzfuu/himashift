# L1 - Environment & Toolchain Audit

Tanggal eksekusi: 2026-04-30

## Ringkasan

- PHP CLI lokal: 8.5.2.
- Composer schema: valid untuk `himashift-admin` dan `himashift-mahasiswa`.
- Composer audit: tidak ada advisory CVE pada dua app.
- pnpm: 10.17.0.
- `pnpm-lock.yaml`: ada pada dua app.
- `package-lock.json`: removed so pnpm is the single JS lockfile source.

## PHP Extensions

Ada: `pdo_mysql`, `mbstring`, `openssl`, `tokenizer`, `xml`, `ctype`, `json`, `bcmath`, `fileinfo`, `pdo_sqlite`, `zip`.

Tidak ada: `gd`. PDF TCPDF yang diuji tidak memakai image processing dan tetap sukses, tetapi hosting produksi sebaiknya mengaktifkan `gd`.

## Dependency Audit

- Composer: PASS, no advisories.
- pnpm audit: 5 advisory pada Vite/esbuild dev server dependency, severity 2 low dan 3 moderate.
- Klasifikasi: Quality/Security note untuk dev server. Build production tetap sukses. Tidak di-upgrade agar arsip tetap minimal.
- `pnpm install --frozen-lockfile`: PASS pada dua app setelah `package-lock.json` dihapus.

## Env Sanity

- `APP_KEY`: set di dua app lokal.
- `APP_DEBUG`: true lokal.
- DB: dua app memakai database `himashift`.
- Session cookie terpisah lewat `APP_NAME`: `himashift_admin_session` dan `himashift_session`.

## Rekomendasi Hosting

Pakai PHP 8.2 atau 8.3 untuk Laravel 10. PHP 8.5 lokal memunculkan warning deprecation dari package dev (`nunomaduro/collision`), tetapi test tetap pass.
