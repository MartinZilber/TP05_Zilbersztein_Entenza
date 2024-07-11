using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

class Escape
{
    static private string[] incognitasSalas { get; set; } = { "0", "10", "izquierda", "ramo", "almohada", "rojo", "piratas", "para elisa", "fuego" };
    static private int estadoJuego { get; set; } = 1;
    static private int contadorIntentos { get; set; } = 0;
    static private int contadorIntentosHabitacion { get; set; } = 0;
    static private int contadorPistas { get; set; } = 0;
    static private int vidas {get;set;}
    static private string nombre { get; set; }
    static private string nivel{get; set; }
    

    public static void InicializarJuego()
    {
        contadorIntentos = 0;
        contadorIntentosHabitacion = 0;
        contadorPistas = 0;
        estadoJuego = 1;
    }
    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static int GetVidas()
    {
        return vidas;
    }
    public static bool ResolverSala(int Sala, string Incognita)
    {
        bool esCorrecto = false;
        if (Sala == estadoJuego)
        {
            if (Incognita == incognitasSalas[Sala - 1])
            {
                esCorrecto = true;
                contadorIntentosHabitacion = 0;
                if (estadoJuego < 9)
                estadoJuego++;
            }
            else
            {
                contadorIntentos++;
                vidas--;
            }
        }
        return esCorrecto;
    }
    public static string GuardarNombre(string Nombre)
    {
        nombre = Nombre;
        return nombre;
    }
    public static void GuardarNivel(string Nivel)
    {
        nivel = Nivel;
        if (nivel == "facil")
        vidas = 10;
        else if (nivel == "medio")
        vidas = 5;
        else
        vidas = 3;
    }
    public static int CalcularEstadisticas()
    {
        return contadorIntentos;
    }
    public static void Incrementar()
    {
        contadorPistas++;
    }
}