<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Mahasiswa;
use App\Models\Divisi;
use App\Models\Absensi;
use App\Models\MahasiswaDivisi;
use App\Models\MahasiswaAbsensi;

class mahasiswaController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $mahasiswa = Mahasiswa::with('divisi')->get();
        return view('mahasiswa.index', compact('mahasiswa'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        $divisi = Divisi::all();
        return view('mahasiswa.create',compact('divisi'));
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        Mahasiswa::create([
            'nim' => $request->nim,
            'password' => $request->password,
            'nama' => $request->nama,
        ]);
        MahasiswaDivisi::create([
            'nim' => $request->nim,
            'id_divisi' => $request->divisi,
        ]);
        return redirect()->route('mahasiswa.index');
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
    public function edit(string $nim)
    {
        $mahasiswa = Mahasiswa::where('nim',$nim)->firstOrFail();
        $divisi = Divisi::all();
        $mahasiswadivisi = MahasiswaDivisi::where('nim',$nim)->firstOrFail();
        return view('mahasiswa.edit', compact('mahasiswa', 'divisi','mahasiswadivisi'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $nim)
    {
        Mahasiswa::where('nim',$nim)
        ->update([
            'nim' => $request->nim,
            'password' => $request->password,
            'nama' => $request->nama,
        ]);
        MahasiswaDivisi::where('nim',$nim)
        ->update([
            'nim' => $request->nim,
            'id_divisi' => $request->divisi,
        ]);
        return redirect()->route('mahasiswa.index');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $nim)
    {
        Mahasiswa::where('nim',$nim)->delete();
        MahasiswaDivisi::where('nim',$nim)->delete();
        return redirect()->route('mahasiswa.index');
    }
}
