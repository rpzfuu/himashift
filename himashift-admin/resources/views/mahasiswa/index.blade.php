@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-head container-fluid" style="margin-top: 10px;">
                    <a href="{{ route('mahasiswa.create') }}" class="btn btn-primary">Tambah Mahasiswa</a>
                    <div class="pull-right">
                        <p>Data Mahasiswa</p>
                    </div>
                </div>
                <div class="panel-body">
                    <table id="datatable" class="table table-striped">
                        <thead>
                            <tr>
                                <th>No</th>
                                <th>NIM</th>
                                <th>PASSWORD</th>
                                <th>NAMA</th>
                                <th>DIVISI</th>
                                <th>Dibuat Pada</th>
                                <th>Diedit Pada</th>
                                <th>Edit</th>
                                <th>Hapus</th>
                            </tr>
                        </thead>
                        <tbody>
                            @foreach ($mahasiswa as $i => $m)
                                <tr>
                                    <td>{{ $i+1 }}</td>
                                    <td>{{ $m->nim }}</td>
                                    <td>{{ $m->password }}</td>
                                    <td>{{ $m->nama }}</td>
                                    <td>
                                        @foreach ($m->divisi as $divisi)
                                            {{ $divisi->nama_divisi }}<br>
                                        @endforeach
                                    </td>
                                    <td>{{ $m->created_at }}</td>
                                    <td>{{ $m->updated_at }}</td>   
                                    <td>
                                        <a href="{{ route('mahasiswa.edit', $m->nim) }}" class="btn btn-success">Edit</a>
                                    </td>
                                    <td>
                                        <form action="{{ route('mahasiswa.destroy', $m->nim) }}" method="post">
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
