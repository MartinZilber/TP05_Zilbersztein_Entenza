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

// let cantSegundosRestantes = 10;
// let tiempoRestante = setInterval(temporizador, 1000);
// function temporizador()
// {
//     console.log("quedan " + cantSegundosRestantes + " segundos");
//     if (cantSegundosRestantes == 0)
//         clearInterval(tiempoRestante);
//     cantSegundosRestantes--;
    
// } //Este es un temporizador que empieza en 10 y se detiene en 0. Debería ser usado para realizar uno de los extras.

//Modo oscuro
//   let body = document.querySelector("body");
//   let botonColor = document.querySelector(".tema");
//   botonColor.addEventListener("click", ()=>{
//           body.classList.toggle("modo-oscuro");
//   }) //ESTO ESTÁ COMENTADO PORQUE TIENE QUE APARECER EN CADA VIEW PARA QUE NO SALTE ERROR




 document.addEventListener("DOMContentLoaded", function() {
    let pistas = document.querySelectorAll(".boton");
    pistas.forEach(function(pista) {
        pista.addEventListener("click", function() {
           this.classList.add("mostrada");
        });
    });
 });//Cuándo una pista fue solicitada
 
 
 document.addEventListener("DOMContentLoaded", function() {
    const claves = ["piedra", "papel", "tijera"];
    const formulario = document.getElementById("PPT");
    const jugada = document.getElementById("jugada");
    let jugadaNoValida = document.getElementById("jugadaInvalida");

    formulario.addEventListener("submit", function(event) {
        const inputValue = jugada.value.trim();
        if (!claves.includes(inputValue)) {
            event.preventDefault();
            jugadaNoValida.textContent = "Jugada no válida. Por favor ingrese 'piedra', 'papel' o 'tijera'";
        }
        else
        jugadaNoValida.textContent = "";
    });
});





