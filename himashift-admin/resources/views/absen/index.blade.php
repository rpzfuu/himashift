@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-head container-fluid" style="margin-top: 10px;">
                    <a href="{{ route('absen.create') }}" class="btn btn-primary">Tambah absen</a>
                    <div class="pull-right">
                        <p>Data absen</p>
                    </div>
                </div>
                <div class="panel-body">
                    <table id="datatable" class="table table-striped">
                        <thead>
                            <tr>
                                <th>No</th>
                                <th>ABSEN_ID</th>
                                <th>JENIS_ABSEN</th>
                                <th>MULAI</th>
                                <th>AKHIR</th>
                                <th>Dibuat Pada</th>
                                <th>Diedit Pada</th>
                                <th>Edit</th>
                                <th>Hapus</th>
                            </tr>
                        </thead>
                        <tbody>
                            @foreach ($absen as $i => $m)
                                <tr>
                                    <td>{{ $i+1 }}</td>
                                    <td>{{ $m->id_absen }}</td>
                                    <td>{{ $m->jenis_absen }}</td>
                                    <td>{{ $m->mulai }}</td>
                                    <td>{{ $m->akhir }}</td>
                                    <td>{{ $m->created_at }}</td>
                                    <td>{{ $m->updated_at }}</td>   
                                    <td>
                                        <a href="{{ route('absen.edit', $m->id_absen) }}" class="btn btn-success">Edit</a>
                                    </td>
                                    <td>
                                        <form action="{{ route('absen.destroy', $m->id_absen) }}" method="post">
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
