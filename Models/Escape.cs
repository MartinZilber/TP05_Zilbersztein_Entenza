class Escape
{
    static private string[] incognitasSalas { get; set; } = { "0", "izquierda", "piratas", "fuego" };
    static private int estadoJuego { get; set; } = 1;
    static private int contadorIntentos { get; set; } = 0;
    static private int contadorIntentosHabitacion { get; set; } = 0;
    static private int contadorPistas { get; set; } = 0;
    static private string nombre { get; set; }

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
    public static bool ResolverSala(int Sala, string Incognita)
    {
        bool esCorrecto = false;
        if (Sala == estadoJuego)
        {
            if (Incognita == incognitasSalas[Sala - 1])
            {
                estadoJuego++;
                esCorrecto = true;
                contadorIntentosHabitacion = 0;
            }
            else
            {
                contadorIntentosHabitacion++;
                contadorIntentos++;
            }
        }
        return esCorrecto;
    }
    public static string GuardarNombre(string nombre)
    {
        string Nombre = nombre;
        return Nombre;
    }
}