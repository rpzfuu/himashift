<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Mahasiswa;
use App\Models\Divisi;
use App\Models\Absensi;
use App\Models\MahasiswaDivisi;
use App\Models\MahasiswaAbsensi;
use App\Models\Kehadiran;

class absenController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $absen = Absensi::all();
        return view('absen.index', compact('absen'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        $absen = Divisi::all();
        return view('absen.create',compact('absen'));
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $absen = Absensi::create([
            'jenis_absen' => $request->jenis_absen,
            'mulai' => $request->mulai,
            'akhir' => $request->akhir,
        ]);
        $mahasiswa = Mahasiswa::all();
        foreach ($mahasiswa as $i => $m){
            Kehadiran::create([
                'nim' => $m->nim,
                'id_absen' => $absen->id_absen,
                'status_kehadiran' => 'Tidak Hadir',
            ]);
        }
        return redirect()->route('absen.index');
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(string $id_absen)
    {
        $absen = Absensi::where('id_absen',$id_absen)->firstOrFail();
        return view('absen.edit', compact('absen'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id_absen)
    {
        Absensi::where('id_absen',$id_absen)
        ->update([
            'jenis_absen' => $request->jenis_absen,
            'mulai' => $request->mulai,
            'akhir' => $request->akhir,
        ]);
        return redirect()->route('absen.index');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id_absen)
    {
        Absensi::where('id_absen',$id_absen)->delete();
        return redirect()->route('absen.index');
    }
}
