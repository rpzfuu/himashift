<?php

namespace Tests\Feature;

use App\Models\Absensi;
use App\Models\Divisi;
use App\Models\Event;
use App\Models\Kehadiran;
use App\Models\Mahasiswa;
use App\Models\MahasiswaDivisi;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Tests\TestCase;

class MahasiswaArchiveFlowTest extends TestCase
{
    use RefreshDatabase;

    private Mahasiswa $mahasiswa;
    private Absensi $absen;

    protected function setUp(): void
    {
        parent::setUp();

        Divisi::create(['id_divisi' => 'RT', 'nama_divisi' => 'Riset dan Teknologi']);

        $this->mahasiswa = Mahasiswa::create([
            'nim' => 'F1E120002',
            'password' => '12345678',
            'nama' => 'Tarisa',
        ]);

        MahasiswaDivisi::create([
            'nim' => $this->mahasiswa->nim,
            'id_divisi' => 'RT',
        ]);

        $this->absen = Absensi::create([
            'jenis_absen' => 'HTTP CRUD TEST Absen',
            'mulai' => '2026-04-30 00:00:00',
            'akhir' => '2026-04-30 23:59:59',
        ]);

        Kehadiran::create([
            'nim' => $this->mahasiswa->nim,
            'id_absen' => $this->absen->id_absen,
            'status_kehadiran' => 'Tidak Hadir',
        ]);

        Event::create([
            'nama_acara' => 'HTTP CRUD TEST Event',
            'tanggal' => '2026-04-30',
            'ketua_pelaksana' => 'Tester',
        ]);
    }

    public function test_register_route_is_disabled(): void
    {
        $this->get('/register')->assertNotFound();
    }

    public function test_guest_can_view_public_pages(): void
    {
        $this->get('/')->assertOk();
        $this->get('/anggota')->assertOk();
    }

    public function test_mahasiswa_can_login_with_nim_and_plain_password(): void
    {
        $this->post('/', [
            'nim' => 'F1E120002',
            'password' => '12345678',
        ])->assertRedirect('/dashboard');

        $this->assertAuthenticatedAs($this->mahasiswa);
    }

    public function test_wrong_password_does_not_login(): void
    {
        $this->post('/', [
            'nim' => 'F1E120002',
            'password' => 'wrong',
        ])->assertRedirect('/');

        $this->assertGuest();
    }

    public function test_guest_is_redirected_from_dashboard_routes(): void
    {
        $this->get('/dashboard')->assertRedirect('/');
        $this->get('/dashboard/profil')->assertRedirect('/');
        $this->get('/dashboard/absensi')->assertRedirect('/');
    }

    public function test_authenticated_mahasiswa_can_view_dashboard_pages(): void
    {
        $this->actingAs($this->mahasiswa)->get('/dashboard')->assertOk();
        $this->actingAs($this->mahasiswa)->get('/dashboard/profil')->assertOk();
        $this->actingAs($this->mahasiswa)->get('/dashboard/absensi')->assertOk();
        $this->actingAs($this->mahasiswa)->get('/dashboard/event')->assertOk();
        $this->actingAs($this->mahasiswa)->get('/dashboard/sertifikat')->assertOk();
        $this->actingAs($this->mahasiswa)->get('/dashboard/sertifikat/generate')->assertOk();
    }

    public function test_mahasiswa_can_submit_own_kehadiran(): void
    {
        $this->actingAs($this->mahasiswa)
            ->post(route('absensi.update', [
                'nim' => $this->mahasiswa->nim,
                'id_absen' => $this->absen->id_absen,
            ]))
            ->assertRedirect();

        $this->assertDatabaseHas('kehadiran', [
            'nim' => $this->mahasiswa->nim,
            'id_absen' => $this->absen->id_absen,
            'status_kehadiran' => 'Hadir',
        ]);
    }

    public function test_mahasiswa_cannot_submit_kehadiran_for_other_nim(): void
    {
        $other = Mahasiswa::create([
            'nim' => 'F1E120057',
            'password' => '12345678',
            'nama' => 'Ragyl',
        ]);

        Kehadiran::create([
            'nim' => $other->nim,
            'id_absen' => $this->absen->id_absen,
            'status_kehadiran' => 'Tidak Hadir',
        ]);

        $this->actingAs($this->mahasiswa)
            ->post(route('absensi.update', [
                'nim' => $other->nim,
                'id_absen' => $this->absen->id_absen,
            ]))
            ->assertForbidden();

        $this->assertDatabaseHas('kehadiran', [
            'nim' => $other->nim,
            'id_absen' => $this->absen->id_absen,
            'status_kehadiran' => 'Tidak Hadir',
        ]);
    }

    public function test_mahasiswa_can_generate_certificate_pdf(): void
    {
        $response = $this->actingAs($this->mahasiswa)
            ->post('/dashboard/sertifikat/generate', [
                'jdesk' => 'Tester',
                'acara' => 'HTTP CRUD TEST Event',
                'tanggal' => '2026-04-30',
            ]);

        $response->assertOk();
        $this->assertSame('application/pdf', $response->headers->get('content-type'));
        $this->assertStringStartsWith('%PDF', $response->getContent());
    }
}
