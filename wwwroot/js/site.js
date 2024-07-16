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

let cantSegundosRestantes = 10;
let tiempoRestante = setInterval(temporizador, 1000);
function temporizador()
{
    console.log("quedan " + cantSegundosRestantes + " segundos");
    if (cantSegundosRestantes == 0)
        clearInterval(tiempoRestante);
    cantSegundosRestantes--;
    
} //Este es un temporizador que empieza en 10 y se detiene en 0. Debería ser usado para realizar uno de los extras.

//Modo oscuro
let body = document.querySelector("body");
let botonColor = document.querySelector(".tema");
botonColor.addEventListener("click", ()=>{
    body.classList.toggle("modo-oscuro");
})
