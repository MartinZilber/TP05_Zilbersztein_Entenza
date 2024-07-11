using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TP05_Zilbersztein_Entenza.Models;

namespace TP05_Zilbersztein_Entenza.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View("");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult Tutorial()
    {
        return View("tutorial");
    }
    public IActionResult Creditos()
    {
        return View("creditos");
    }
    public IActionResult Victoria()
    {
        int cantIntentosTotales = Escape.CalcularEstadisticas(); 
        ViewBag.contadorIntentos = cantIntentosTotales;
        return View("victoria");
    }
    public IActionResult Comenzar()
    {
        Escape.InicializarJuego();
        return View("FormInicio"); //que sala
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        bool esCorrecto = Escape.ResolverSala(sala, clave);
        if (esCorrecto)
        {
            ViewBag.Dato = "";
            if (Escape.GetEstadoJuego() >= 10)
            return View("victoria");
        }
        else if (Escape.GetVidas() > 0)
        {
            ViewBag.Dato = "Dato incorrecto";
            return View("habitacion" + (Escape.GetEstadoJuego()).ToString());
        }
        return View("derrota");
    }
    public IActionResult GuardarDatos(string nombre, string Nivel)
    {
        ViewBag.Nombre = Escape.GuardarNombre(nombre);
        Escape.GuardarNivel(Nivel);
        ViewBag.Vidas = Escape.vidas;
        return View("habitacion" + Escape.GetEstadoJuego());
    }
    /*public IActionResult Incrementar()
    {
        Escape.contadorPistas++;
        ViewBag.contadorPistas = "Cantidad de veces pistas pedidas: " + Escape.contadorPistas;
        return View(Escape.estadoJuego + "habitacion");
    }*/
}