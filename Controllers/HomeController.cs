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
        Escape.estadoJuego = 1;
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
    public IActionResult creditos()
    {
        return View("creditos");
    }
    public IActionResult victoria()
    {
        ViewBag.contadorIntentos = Escape.contadorIntentos;
        ViewBag.nombre = Escape.nombre;
        return View("victoria");
    }
    public IActionResult Comenzar()
    {
        //como se que habitacion la persona?
        Escape.contadorIntentos = 0;
        Escape.contadorIntentosHabitacion = 0;
        Escape.contadorPistas = 0;
        return View(Escape.GetEstadoJuego().ToString() + "habitacion"); //que sala
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        bool esCorrecto = Escape.ResolverSala(sala, clave);
        ViewBag.contadorIntentosHabitacion = Escape.contadorIntentosHabitacion;
        if (esCorrecto)
        {
            Escape.contadorIntentosHabitacion = 0;
            ViewBag.Dato = "";
            if (Escape.estadoJuego == 5) return View("victoria");
        }
        else
        {
            if (Escape.contadorIntentosHabitacion >= 0)
            {
                ViewBag.Dato = "Dato incorrecto";
            }
            Escape.contadorIntentosHabitacion++;
            Escape.contadorIntentos++;
        }
        return View(Escape.estadoJuego + "habitacion");
    }
    
    public IActionResult GuardarNombre(string nombre){
        Escape.nombre = nombre;
        ViewBag.nombre = Escape.nombre;
        return View("Index");
    }
    public IActionResult Incrementar()
    {
        Escape.contadorPistas++;
        ViewBag.contadorPistas = "Cantidad de veces pistas pedidas: " + Escape.contadorPistas;
        return View(Escape.estadoJuego + "habitacion");
    }
}