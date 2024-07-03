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
    public IActionResult Tutorial(){

        return RedirectToAction("","");
    }
    public IActionResult Comenzar(){
        //como se que habitacion la persona?
        return View(Escape.GetEstadoJuego().ToString() + "habitacion"); //que sala
    }
    public IActionResult Habitacion(int sala, string clave){
        bool esCorrecto = Escape.ResolverSala(sala, clave);
        if (esCorrecto)
        {
            Escape.contadorIntentos = 0;
            return View(Escape.estadoJuego + "habitacion");
        }
        else if (Escape.contadorIntentos < 0)
        {
            ViewBag.Dato = "Dato incorrecto";
        }  
        Escape.contadorIntentos++;      
        return View(Escape.estadoJuego + "habitacion");
    }
}
