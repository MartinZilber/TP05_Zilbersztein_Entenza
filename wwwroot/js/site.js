// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function mostrarpaso(paso)
{
    $(".paso").hide();
    $("#paso"+paso).fadeIn();
}
 
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









