@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-head container-fluid" style="margin-top: 10px;">
                    <p>Edit Data mahasiswa</p>
                </div>
                <div class="panel-body">
                    <form class="form-horizontal" action="{{ route('mahasiswa.update', $mahasiswa->nim) }}" method="post">
                        {{ csrf_field() }}
                        <input type="hidden" name="_method" value="PUT">
                        <div class="form-group">
                            <label class="control-label col-sm-2">NIM</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" readonly name="nim" value="{{ $mahasiswa->nim }}">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">PASSWORD</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" name="password" value="{{ $mahasiswa->password }}">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">NAMA</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" name="nama" value="{{ $mahasiswa->nama }}">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">DIVISI</label>
                            <div class="col-sm-10">
                                <select class="form-control" name="divisi">
                                    <option value="">Pilih DIVISI</option>
                                    @foreach ($divisi as $k)
                                        <option value="{{ $k->id_divisi }}" @if ($mahasiswadivisi->id_divisi==$k->id_divisi) selected @endif>{{ $k->nama_divisi }}</option>
                                    @endforeach
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <button type="submit" class="btn btn-primary">Perbaharui Data</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>
@endsection
