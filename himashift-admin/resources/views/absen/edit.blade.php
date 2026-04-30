@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-head container-fluid" style="margin-top: 10px;">
                    <p>Edit Data Absen</p>
                </div>
                <div class="panel-body">
                    <form class="form-horizontal" action="{{ route('absen.update', $absen->id_absen) }}" method="post">
                        {{ csrf_field() }}
                        <input type="hidden" name="_method" value="PUT">
                        <div class="form-group">
                            <label class="control-label col-sm-2">ABSEN_ID</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" readonly name="id_absen" value="{{ $absen->id_absen }}">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">JENIS_ABSEN</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" name="jenis_absen" value="{{ $absen->jenis_absen }}">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">MULAI</label>
                            <div class="col-sm-10">
                                <input type="datetime-local" class="form-control" name="mulai" value="{{ $absen->mulai }}">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">AKHIR</label>
                            <div class="col-sm-10">
                                <input type="datetime-local" class="form-control" name="akhir" value="{{ $absen->akhir }}">
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
