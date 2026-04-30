<?php

namespace App\Models;

use Illuminate\Notifications\Notifiable;
use Illuminate\Foundation\Auth\User as Authenticatable;

class Mahasiswa extends Authenticatable
{
    use Notifiable;
    
    protected $table = 'mahasiswa';
    /**
     * The primary key associated with the table.
     *
     * @var string
     */
    
    protected $primaryKey = 'nim';

    /**
     * The "type" of the auto-incrementing ID.
     *
     * @var string
     */
    protected $keyType = 'string';

    /**
     * Indicates if the IDs are auto-incrementing.
     *
     * @var bool
     */
    public $incrementing = false;

    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'nim',
        'password',
        'nama',
    ];

    /**
     * The attributes that should be hidden for arrays.
     *
     * @var array
     */
    protected $hidden = [
        'password',
    ];
    public function divisi()
    {
        return $this->belongsToMany(Divisi::class, 'mahasiswa_divisi', 'nim', 'id_divisi');
    }
    public function absensi(){
        return $this->belongsToMany(Absensi::class,'kehadiran','nim','id_absen');
    }
}