@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-head container-fluid" style="margin-top: 10px;">
                    <div class="row">
                            <h1>Nama : {{ $mahasiswa->nama }}</h1>
                            <h2>NIM : {{ $mahasiswa->nim }}</h2>
                            @foreach ($mahasiswa->divisi as $divisi)
                                <h2>Divisi : {{ $divisi->nama_divisi }}</h2>
                            @endforeach
                    </div>
                </div>
                <div class="panel-body">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>No</th>
                                <th>ABSEN_ID</th>
                                <th>JEN IS_ABSEN</th>
                                <th>MULAI</th>
                                <th>AKHIR</th>
                                <th>STATUS_KEHADIRAN</th>
                                <th>HADIR</th>
                                <th>TIDAK HADIR</th>
                            </tr>
                        </thead>
                        <tbody>
                            @php $i=0 @endphp
                                @foreach ($mahasiswa->absensi as $absensi)
                                <tr>
                                    @php $i=$i+1 @endphp
                                    @php $kehadiran = $absensi->kehadiran->firstWhere('nim', $mahasiswa->nim); @endphp
                                    <td>{{ $i }}</td>
                                    <td>{{ $absensi->id_absen }}</td>
                                    <td>{{ $absensi->jenis_absen }}</td>
                                    <td>{{ $absensi->mulai }}</td>
                                    <td>{{ $absensi->akhir }}</td>
                                    <td>{{ $kehadiran ? $kehadiran->status_kehadiran : '' }}</td>
                                    <td>
                                        <form action="{{ route('kehadiran.status.update', ['nim' => $mahasiswa->nim, 'id_absen' => $absensi->id_absen]) }}" method="post">
                                            {{ csrf_field() }}
                                            <input type="hidden" name="_method" value="PATCH">
                                            <button type="submit" name="status_kehadiran" value="Hadir" class="btn btn-success">HADIR</button>
                                        </form>
                                    </td>
                                    <td>
                                        <form action="{{ route('kehadiran.status.update', ['nim' => $mahasiswa->nim, 'id_absen' => $absensi->id_absen]) }}" method="post">
                                            {{ csrf_field() }}
                                            <input type="hidden" name="_method" value="PATCH">
                                            <button type="submit" name="status_kehadiran" value="Tidak Hadir" class="btn btn-danger">TIDAK HADIR</button>
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
