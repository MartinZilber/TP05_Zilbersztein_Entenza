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
    public IActionResult creditos()
    {
        return View("creditos");
    }
    public IActionResult victoria()
    {
        return View("victoria");
    }
    public IActionResult Comenzar()
    {
        Escape.InicializarJuego();
        return View(Escape.GetEstadoJuego().ToString() + "habitacion"); //que sala
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        bool esCorrecto = Escape.ResolverSala(sala, clave);
        if (esCorrecto)
        {
            ViewBag.Dato = "";
            if (sala == 5)
            return View("victoria");
            else
            sala++;
        }
        else
        {
            ViewBag.Dato = "Dato incorrecto";
        }
        return View((sala).ToString() + "habitacion");

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