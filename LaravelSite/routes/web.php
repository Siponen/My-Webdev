<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

Route::get('foo', function() {
    return 'Hello world';
});

Route::get('user/{id}', function($id) {
    return 'User '.$id;
});

Route::get('car','CarController@index');
Route::get('car/create','CarController@create');
Route::post('car/create','CarController@store');

Route::get('car','CarController@index');
Route::get('edit/{id}','CarController@edit');
Route::post('edit/{id}','CarController@update');
Route::delete('{id}','CarController@delete');
