<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Mahasiswa;
use App\Models\Divisi;
use App\Models\Absensi;
use App\Models\MahasiswaDivisi;
use App\Models\MahasiswaAbsensi;
use App\Models\Kehadiran;

class kehadiranController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $mahasiswa = Mahasiswa::with('divisi')->get();
        return view('kehadiran.index', compact('mahasiswa'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        return redirect()->route('kehadiran.index');
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        return redirect()->route('kehadiran.index');
    }

    /**
     * Display the specified resource.
     */
    public function show(string $nim)
    {
        $mahasiswa = Mahasiswa::where('nim', $nim)->with('absensi')->firstOrFail();
        return view('kehadiran.show', compact('mahasiswa'));
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(string $nim)
    {
        Mahasiswa::where('nim', $nim)->firstOrFail();
        return redirect()->route('kehadiran.show', $nim);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $nim, ?int $id_absen = null)
    {
        if ($id_absen === null) {
            return redirect()->route('kehadiran.index');
        }

        $status_kehadiran = $request->status_kehadiran;
        Kehadiran::where(['nim' => $nim, 'id_absen' => $id_absen])
        ->update([
         'status_kehadiran' => $status_kehadiran
        ]);
        return back();   
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $nim)
    {
        Kehadiran::where('nim',$nim)->delete();
        return redirect()->route('kehadiran.index');
    }
}
