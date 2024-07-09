class Escape
{
    static public string[] incognitasSalas { get; set; } = { "0", "izquierda", "piratas", "fuego" };
    static public int estadoJuego { get; set; } = 1;
    static public int contadorIntentos { get; set; } = 0;
    static public int contadorIntentosHabitacion { get; set; } = 0;
    static public int contadorPistas { get; set; } = 0;
    static public string nombre { get; set; }

    private static void InicializarJuego()
    {
    }
    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static bool ResolverSala(int Sala, string Incognita)
    {
        bool esCorrecto = false;
        /*if (Sala == estadoJuego)
        {

        }PREGUNTAR*/
        if (Incognita == incognitasSalas[estadoJuego - 1])
        {
            estadoJuego++;
            esCorrecto = true;
        }
        return esCorrecto;
    }
}