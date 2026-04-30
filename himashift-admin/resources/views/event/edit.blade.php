@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-head container-fluid" style="margin-top: 10px;">
                    <p>Edit Data event</p>
                </div>
                <div class="panel-body">
                    <form class="form-horizontal" action="{{ route('event.update', $event->id_acara) }}" method="post">
                        {{ csrf_field() }}
                        <input type="hidden" name="_method" value="PUT">
                        <div class="form-group">
                            <label class="control-label col-sm-2">NAMA_ACARA</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" name="nama_acara" value="{{ $event->nama_acara }}">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">TANGGAL</label>
                            <div class="col-sm-10">
                                <input type="date" class="form-control" name="tanggal" value="{{ $event->tanggal }}">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">KETUA_PELAKSANA</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" name="ketua_pelaksana" value="{{ $event->ketua_pelaksana }}">
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
