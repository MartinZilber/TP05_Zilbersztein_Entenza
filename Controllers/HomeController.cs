using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
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
        return View("victoria");
    }
    public IActionResult Ajustes()
    {
        return View("Ajustes");
    }
    public IActionResult Derrota()
    {
        ViewBag.Nombre = Escape.nombre;
        ViewBag.Nivel = Escape.GetNivel();
        return View("derrota");
    }
    public IActionResult Estadisticas()
    {
        int cantIntentosTotales = Escape.CalcularEstadisticas();
        ViewBag.contadorIntentos = cantIntentosTotales;
        return View("estadisticas");
    }
    public IActionResult Comenzar()
    {
        Escape.InicializarJuego();
        return View("FormInicio"); //que sala
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        bool esCorrecto = Escape.ResolverSala(sala, clave);
        ViewBag.Vidas = Escape.GetVidas();
        if (esCorrecto)
        {
            ViewBag.Dato = "";
            if (Escape.GetEstadoJuego() == 9)
            {
                ViewBag.PuntosJugador = Escape.puntosPPTJugador;
                ViewBag.PuntosBot = Escape.puntosPPTBot;
            }
            if (Escape.GetEstadoJuego() >= 10)
                return View("victoria");
        }
        else
            ViewBag.Dato = "Dato incorrecto";
        if (Escape.GetVidas() > 0)
        {
            return View("habitacion" + (Escape.GetEstadoJuego()).ToString());
        }
        else
            return RedirectToAction("derrota");
    }
    public IActionResult ProcesarPPT(int sala, string jugada)
    {
        int ganador = Escape.PiedraPapelTijera(sala, jugada);
        if (Escape.puntosPPTBot == 3)
        {
            ViewBag.Dato = "Perdiste la partida!";
            Escape.puntosPPTBot = 0;
            Escape.puntosPPTJugador = 0;
        }
        else if (ganador == 1)
        ViewBag.Ronda = "Ganaste la ronda!";
        else if (ganador == 2)
        ViewBag.Ronda = "Perdiste la ronda!";
        else
        ViewBag.Ronda = "Han empatado!";
        ViewBag.Vidas = Escape.GetVidas();
        ViewBag.PuntosJugador = Escape.puntosPPTJugador;
        ViewBag.PuntosBot = Escape.puntosPPTBot;
        return View("habitacion" + Escape.GetEstadoJuego());
    }
    public IActionResult GuardarDatos(string nombre, string Nivel)
    {
        ViewBag.Nombre = Escape.GuardarNombre(nombre);
        Escape.GuardarNivel(Nivel);
        ViewBag.Vidas = Escape.GetVidas();
        Escape.InicializarJuego();
        
        return View("habitacion" + Escape.GetEstadoJuego());
    }
    /*public IActionResult Incrementar()
    {
        Escape.Incrementar();
        return View("habitacion" + Escape.GetEstadoJuego());
    }*/
}