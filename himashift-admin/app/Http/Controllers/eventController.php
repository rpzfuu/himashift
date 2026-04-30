<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Event;

class eventController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $event = Event::all();
        return view('event.index', compact('event'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        $event = Event::all();
        return view('event.create',compact('event'));
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        Event::create([
            'nama_acara' => $request->nama_acara,
            'tanggal' => $request->tanggal,
            'ketua_pelaksana' => $request->ketua_pelaksana,
        ]);
        return redirect()->route('event.index');
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
    public function edit(string $id_acara)
    {
        $event = Event::where('id_acara',$id_acara)->firstOrFail();
        return view('event.edit', compact('event'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id_acara)
    {
        Event::where('id_acara',$id_acara)
        ->update([
            'nama_acara' => $request->nama_acara,
            'tanggal' => $request->tanggal,
            'ketua_pelaksana' => $request->ketua_pelaksana,
        ]);
        return redirect()->route('event.index');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id_acara)
    {
        Event::where('id_acara',$id_acara)->delete();
        return redirect()->route('event.index');
    }
}
