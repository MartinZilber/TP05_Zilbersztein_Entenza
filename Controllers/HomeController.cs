using System.Diagnostics;
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
    public IActionResult Tutorial(){

        return RedirectToAction("","");
    }
    public IActionResult Comenzar(){
        //como se que habitacion la persona?
        return View(Escape.GetEstadoJuego().ToString() + "habitacion"); //que sala
    }
    public IActionResult Habitacion(int sala, string clave){
        bool esCorrecto = Escape.ResolverSala(sala, clave);
        int contador = 0;
        if (esCorrecto)
        {
            return View(sala+2 + "habitacion");
            Escape.estadoJuego++;
        }
        else
        {
            if (contador != 0)
            ViewBag.Dato = "Dato incorrecto";
            contador++;
            return View(sala+1 + "habitacion");
        }
    }
}
