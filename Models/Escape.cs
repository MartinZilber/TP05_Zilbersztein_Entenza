using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

class Escape
{

    static private string[] incognitasSalas { get; set; } = { "0", "10", "izquierda", "ramo", "almohadón", "rojo", "piratas", "para elisa", "fuego" };

    static private int estadoJuego { get; set; } = 1;
    static private int contadorIntentos { get; set; } = 0;
    static private int contadorIntentosHabitacion { get; set; } = 0;
    static private int contadorPistas { get; set; } = 0;
    static private int vidas { get; set; }
    static private string nivel { get; set; }
    static public string nombre { get; set; }
    static public int puntosPPTJugador { get; set; } = 0;
    static public int puntosPPTBot { get; set; } = 0;


    public static void InicializarJuego()
    {
        contadorIntentos = 0;
        contadorIntentosHabitacion = 0;
        contadorPistas = 0;
        estadoJuego = 1;
        puntosPPTBot = 0;
        puntosPPTJugador = 0;
    }
    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static int GetVidas()
    {
        return vidas;
    }
    public static string GetNivel()
    {
        return nivel;
    }
    public static bool ResolverSala(int Sala, string Incognita)
    {
        bool esCorrecto = false;
        Incognita = Incognita.ToLower();
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
    public static int PiedraPapelTijera(int sala, string jugada)
    {
        string[] jugadas = { "piedra", "papel", "tijera" };
        string jugadaBot;
        int ganador = 0;
        if (sala == estadoJuego)
        {
            jugadaBot = jugadas[generarRandom(0, 2)];
            if (jugada == "papel" && jugadaBot == "piedra" || jugada == "tijera" && jugadaBot == "papel" || jugada == "piedra" && jugadaBot == "tijera")
            {
                puntosPPTJugador++;
                ganador = 1;
                if (puntosPPTJugador == 3)
                    estadoJuego++;
            }
            else if (jugada != jugadaBot)
            {
                puntosPPTBot++;
                ganador = 2;
                if (puntosPPTBot == 3)
                    vidas--;
            }
            else
                ganador = 3;
        }
        return ganador;
    }
    public static int generarRandom(int minimo, int maximo)
    {
        Random r = new Random();
        int numero = r.Next(minimo, maximo);
        return numero;
    }
    public static string GuardarNombre(string Nombre)
    {
        if (Nombre != null)
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
        else if (nivel == "dificil")
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