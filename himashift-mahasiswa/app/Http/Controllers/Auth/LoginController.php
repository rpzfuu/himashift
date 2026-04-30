<?php

namespace App\Http\Controllers\Auth;

use App\Http\Controllers\Controller;
use App\Models\Mahasiswa;
use App\Providers\RouteServiceProvider;
use Illuminate\Foundation\Auth\AuthenticatesUsers;
use Illuminate\Http\Request;

class LoginController extends Controller
{
    /*
    |--------------------------------------------------------------------------
    | Login Controller
    |--------------------------------------------------------------------------
    |
    | This controller handles authenticating users for the application and
    | redirecting them to your home screen. The controller uses a trait
    | to conveniently provide its functionality to your applications.
    |
    */

    use AuthenticatesUsers;

    /**
     * Where to redirect users after login.
     *
     * @var string
     */
    protected $redirectTo = '/dashboard';

    /**
     * Create a new controller instance.
     *
     * @return void
     */
    public function __construct()
    {
        $this->middleware('guest')->except('logout');
    }
    public function username()
    {
        return 'nim';
    }

    public function showLoginForm()
    {
        return view('beranda.index');
    }

    protected function attemptLogin(Request $request)
    {
        $nim = $request->input($this->username());
        $password = $request->input('password');

        $mahasiswa = Mahasiswa::where('nim', $nim)->first();

        if ($mahasiswa && $mahasiswa->password === $password) {
            $this->guard()->login($mahasiswa, $request->boolean('remember'));
            return true;
        }

        return false;
    }
}