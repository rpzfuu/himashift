<?php

namespace Tests\Feature;

use App\Models\Absensi;
use App\Models\Divisi;
use App\Models\Event;
use App\Models\Kehadiran;
use App\Models\Mahasiswa;
use App\Models\MahasiswaDivisi;
use App\Models\User;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Tests\TestCase;

class AdminArchiveFlowTest extends TestCase
{
    use RefreshDatabase;

    private User $admin;

    protected function setUp(): void
    {
        parent::setUp();

        $this->admin = User::create([
            'name' => 'admin',
            'email' => 'admin@example.test',
            'password' => '12345678',
        ]);

        Divisi::create(['id_divisi' => 'RT', 'nama_divisi' => 'Riset dan Teknologi']);
        Divisi::create(['id_divisi' => 'MI', 'nama_divisi' => 'Media dan Informasi']);
    }

    public function test_admin_can_login_with_name(): void
    {
        $this->post('/login', [
            'name' => 'admin',
            'password' => '12345678',
        ])->assertRedirect('/home');

        $this->assertAuthenticatedAs($this->admin);
    }

    public function test_register_route_is_disabled(): void
    {
        $this->get('/register')->assertNotFound();
    }

    public function test_guest_is_redirected_from_protected_routes(): void
    {
        $this->get('/home/mahasiswa')->assertRedirect('/login');
        $this->get('/home/event')->assertRedirect('/login');
        $this->get('/home/absen')->assertRedirect('/login');
    }

    public function test_authenticated_home_redirects_to_mahasiswa_index(): void
    {
        $this->actingAs($this->admin)
            ->get('/home')
            ->assertRedirect(route('mahasiswa.index'));
    }

    public function test_admin_can_create_update_and_delete_mahasiswa_with_divisi(): void
    {
        $this->actingAs($this->admin)
            ->post(route('mahasiswa.store'), [
                'nim' => 'TST260010',
                'password' => 'test12345',
                'nama' => 'HTTP CRUD TEST Mahasiswa',
                'divisi' => 'RT',
            ])->assertRedirect(route('mahasiswa.index'));

        $this->assertDatabaseHas('mahasiswa', ['nim' => 'TST260010']);
        $this->assertDatabaseHas('mahasiswa_divisi', ['nim' => 'TST260010', 'id_divisi' => 'RT']);

        $this->actingAs($this->admin)
            ->put(route('mahasiswa.update', 'TST260010'), [
                'nim' => 'TST260010',
                'password' => 'test12345',
                'nama' => 'HTTP CRUD UPDATED',
                'divisi' => 'MI',
            ])->assertRedirect(route('mahasiswa.index'));

        $this->assertDatabaseHas('mahasiswa', ['nim' => 'TST260010', 'nama' => 'HTTP CRUD UPDATED']);
        $this->assertDatabaseHas('mahasiswa_divisi', ['nim' => 'TST260010', 'id_divisi' => 'MI']);

        $this->actingAs($this->admin)
            ->delete(route('mahasiswa.destroy', 'TST260010'))
            ->assertRedirect(route('mahasiswa.index'));

        $this->assertDatabaseMissing('mahasiswa', ['nim' => 'TST260010']);
        $this->assertDatabaseMissing('mahasiswa_divisi', ['nim' => 'TST260010']);
    }

    public function test_invalid_edit_routes_return_404_instead_of_500(): void
    {
        $this->actingAs($this->admin)->get('/home/mahasiswa/INVALID/edit')->assertNotFound();
        $this->actingAs($this->admin)->get('/home/absen/999/edit')->assertNotFound();
        $this->actingAs($this->admin)->get('/home/event/999/edit')->assertNotFound();
        $this->actingAs($this->admin)->get('/home/kehadiran/INVALID')->assertNotFound();
    }

    public function test_admin_can_create_update_and_delete_event(): void
    {
        $this->actingAs($this->admin)
            ->post(route('event.store'), [
                'nama_acara' => 'HTTP CRUD TEST Event',
                'tanggal' => '2026-04-30',
                'ketua_pelaksana' => 'Tester',
            ])->assertRedirect(route('event.index'));

        $event = Event::where('nama_acara', 'HTTP CRUD TEST Event')->firstOrFail();

        $this->actingAs($this->admin)
            ->put(route('event.update', $event->id_acara), [
                'nama_acara' => 'HTTP CRUD TEST Event Updated',
                'tanggal' => '2026-05-01',
                'ketua_pelaksana' => 'Tester 2',
            ])->assertRedirect(route('event.index'));

        $this->assertDatabaseHas('event', [
            'id_acara' => $event->id_acara,
            'nama_acara' => 'HTTP CRUD TEST Event Updated',
        ]);

        $this->actingAs($this->admin)
            ->delete(route('event.destroy', $event->id_acara))
            ->assertRedirect(route('event.index'));

        $this->assertDatabaseMissing('event', ['id_acara' => $event->id_acara]);
    }

    public function test_absen_creation_creates_kehadiran_and_delete_cascades(): void
    {
        Mahasiswa::create(['nim' => 'TST260011', 'password' => 'test12345', 'nama' => 'Satu']);
        Mahasiswa::create(['nim' => 'TST260012', 'password' => 'test12345', 'nama' => 'Dua']);

        $this->actingAs($this->admin)
            ->post(route('absen.store'), [
                'jenis_absen' => 'HTTP CRUD TEST Absen',
                'mulai' => '2026-04-30 00:00:00',
                'akhir' => '2026-04-30 23:59:59',
            ])->assertRedirect(route('absen.index'));

        $absen = Absensi::where('jenis_absen', 'HTTP CRUD TEST Absen')->firstOrFail();
        $this->assertSame(2, Kehadiran::where('id_absen', $absen->id_absen)->count());

        $this->actingAs($this->admin)
            ->delete(route('absen.destroy', $absen->id_absen))
            ->assertRedirect(route('absen.index'));

        $this->assertDatabaseMissing('absen', ['id_absen' => $absen->id_absen]);
        $this->assertDatabaseMissing('kehadiran', ['id_absen' => $absen->id_absen]);
    }

    public function test_admin_can_update_kehadiran_status(): void
    {
        Mahasiswa::create(['nim' => 'TST260013', 'password' => 'test12345', 'nama' => 'Peserta']);
        $absen = Absensi::create([
            'jenis_absen' => 'HTTP CRUD TEST Absen',
            'mulai' => '2026-04-30 00:00:00',
            'akhir' => '2026-04-30 23:59:59',
        ]);
        Kehadiran::create([
            'nim' => 'TST260013',
            'id_absen' => $absen->id_absen,
            'status_kehadiran' => 'Tidak Hadir',
        ]);

        $this->actingAs($this->admin)
            ->patch(route('kehadiran.status.update', [
                'nim' => 'TST260013',
                'id_absen' => $absen->id_absen,
            ]), ['status_kehadiran' => 'Hadir'])
            ->assertRedirect();

        $this->assertDatabaseHas('kehadiran', [
            'nim' => 'TST260013',
            'id_absen' => $absen->id_absen,
            'status_kehadiran' => 'Hadir',
        ]);
    }

    public function test_kehadiran_relation_points_to_absensi_model(): void
    {
        Mahasiswa::create(['nim' => 'TST260014', 'password' => 'test12345', 'nama' => 'Peserta']);
        $absen = Absensi::create([
            'jenis_absen' => 'HTTP CRUD TEST Absen',
            'mulai' => '2026-04-30 00:00:00',
            'akhir' => '2026-04-30 23:59:59',
        ]);
        $kehadiran = Kehadiran::create([
            'nim' => 'TST260014',
            'id_absen' => $absen->id_absen,
            'status_kehadiran' => 'Tidak Hadir',
        ]);

        $this->assertTrue($kehadiran->absen->is($absen));
    }
}
