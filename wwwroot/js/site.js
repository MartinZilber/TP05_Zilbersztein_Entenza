// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function mostrarpaso(paso)
{
    $(".paso").hide();
    $("#paso"+paso).fadeIn();
}
function definirTiempo(nivel){
    if (nivel == facil) return 1;
    if (nivel == medio) return 0,75;
    else return 0,5;
}


function temporizador()
{

}
