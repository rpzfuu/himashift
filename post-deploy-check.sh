#!/usr/bin/env bash
set -euo pipefail

ADMIN_URL="${1:-https://admin.example.com}"
MAHASISWA_URL="${2:-https://himashift.example.com}"

check() {
  local label="$1"
  local url="$2"
  local expected="$3"
  local status
  status="$(curl -k -s -o /dev/null -w "%{http_code}" "$url")"
  printf "%-35s expected=%s actual=%s\n" "$label" "$expected" "$status"
  test "$status" = "$expected"
}

check_header() {
  local label="$1"
  local url="$2"
  local header="$3"
  if curl -k -s -I "$url" | grep -qi "^${header}:"; then
    printf "%-35s header=%s present\n" "$label" "$header"
  else
    printf "%-35s header=%s missing\n" "$label" "$header"
    return 1
  fi
}

check "admin login" "${ADMIN_URL}/login" "200"
check "admin protected home" "${ADMIN_URL}/home" "302"
check "mahasiswa login" "${MAHASISWA_URL}/" "200"
check "mahasiswa anggota" "${MAHASISWA_URL}/anggota" "200"
check "mahasiswa protected dashboard" "${MAHASISWA_URL}/dashboard" "302"

check_header "admin anti-clickjacking" "${ADMIN_URL}/login" "X-Frame-Options"
check_header "admin nosniff" "${ADMIN_URL}/login" "X-Content-Type-Options"
check_header "admin hsts" "${ADMIN_URL}/login" "Strict-Transport-Security"
check_header "mahasiswa anti-clickjacking" "${MAHASISWA_URL}/" "X-Frame-Options"
check_header "mahasiswa nosniff" "${MAHASISWA_URL}/" "X-Content-Type-Options"
check_header "mahasiswa hsts" "${MAHASISWA_URL}/" "Strict-Transport-Security"

echo "Post-deploy smoke passed."
