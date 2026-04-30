@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-head container-fluid" style="margin-top: 10px;">  
                    <p>Tambah Data Absen</p>
                </div>
                <div class="panel-body">
                    <form class="form-horizontal" action="{{ route('absen.store') }}" method="post">
                        {{ csrf_field() }}     
                        <div class="form-group">
                            <label class="control-label col-sm-2">JENIS_ABSEN</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" name="jenis_absen">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">MULAI</label>
                            <div class="col-sm-10">
                                <input type="datetime-local" class="form-control" name="mulai" id="MULAI">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">AKHIR</label>
                            <div class="col-sm-10">
                                <input type="datetime-local" class="form-control" name="akhir" id="AKHIR">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <button type="submit" class="btn btn-primary">Simpan</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>
<script>
    // Fungsi untuk mengonversi objek Date ke format datetime-local
    function formatDateLocal(date) {
        const pad = (num) => num.toString().padStart(2, '0');
        return `${date.getFullYear()}-${pad(date.getMonth() + 1)}-${pad(date.getDate())}T${pad(date.getHours())}:${pad(date.getMinutes())}`;
    }

    document.addEventListener('DOMContentLoaded', () => {
        const mulaiInput = document.getElementById('MULAI');
        const akhirInput = document.getElementById('AKHIR');
        // Mengatur input MULAI dengan waktu sistem saat ini
        mulaiInput.value = formatDateLocal(new Date());
        akhirInput.value = formatDateLocal(new Date());
    });
</script>
@endsection
