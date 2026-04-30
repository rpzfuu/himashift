<?php

use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "web" middleware group. Make something great!
|
*/


Auth::routes(['register' => false]);
Route::get('/', [App\Http\Controllers\HomeController::class, 'index'])->name('home');

Route::get('/home', [App\Http\Controllers\HomeController::class, 'index']);

Route::middleware(['auth'])->group(function () {
    Route::resource('/home/mahasiswa', 'App\Http\Controllers\mahasiswaController');
    Route::resource('/home/event', 'App\Http\Controllers\eventController');
    Route::resource('/home/absen', 'App\Http\Controllers\absenController');
    Route::resource('/home/kehadiran', 'App\Http\Controllers\kehadiranController');
    Route::patch('/kehadiran/{nim}/{id_absen}', 'App\Http\Controllers\kehadiranController@update')->name('kehadiran.status.update');
});
