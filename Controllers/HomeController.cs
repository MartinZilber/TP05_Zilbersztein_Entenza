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
        return View("habitacion" + Escape.GetEstadoJuego().ToString()); //que sala
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
        else
        ViewBag.Dato = "Dato incorrecto";
        ViewBag.Sala = sala;
        return View("habitacion" + (Escape.GetEstadoJuego()).ToString());
    }
    public IActionResult GuardarNombre(string nombre)
    {
        ViewBag.Nombre = Escape.GuardarNombre(nombre);
        return View("index");
    }
    /*public IActionResult Incrementar()
    {
        Escape.contadorPistas++;
        ViewBag.contadorPistas = "Cantidad de veces pistas pedidas: " + Escape.contadorPistas;
        return View(Escape.estadoJuego + "habitacion");
    }*/
}