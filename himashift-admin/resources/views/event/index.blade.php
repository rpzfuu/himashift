@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-head container-fluid" style="margin-top: 10px;">
                    <a href="{{ route('event.create') }}" class="btn btn-primary">Tambah event</a>
                    <div class="pull-right">
                        <p>Data event</p>
                    </div>
                </div>
                <div class="panel-body">
                    <table id="datatable" class="table table-striped">
                        <thead>
                            <tr>
                                <th>No</th>
                                <th>NAMA_ACARA</th>
                                <th>TANGGAL</th>
                                <th>KETUA_PELAKSANA</th>
                                <th>Dibuat Pada</th>
                                <th>Diedit Pada</th>
                                <th>Edit</th>
                                <th>Hapus</th>
                            </tr>
                        </thead>
                        <tbody>
                            @foreach ($event as $i => $m)
                                <tr>
                                    <td>{{ $i+1 }}</td>
                                    <td>{{ $m->nama_acara }}</td>
                                    <td>{{ $m->tanggal }}</td>
                                    <td>{{ $m->ketua_pelaksana }}</td>
                                    <td>{{ $m->created_at }}</td>
                                    <td>{{ $m->updated_at }}</td>   
                                    <td>
                                        <a href="{{ route('event.edit', $m->id_acara) }}" class="btn btn-success">Edit</a>
                                    </td>
                                    <td>
                                        <form action="{{ route('event.destroy', $m->id_acara) }}" method="post">
                                            @csrf
                                            @method('DELETE')
                                            <button class="btn btn-danger" type="submit">Hapus</button>
                                        </form>
                                    </td>
                                </tr>
                            @endforeach
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
@endsection
