using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

class Escape
{

    static private string[] incognitasSalas { get; set; } = { "0", "cartel", "a", "ramo", "almohadon", "infoesgenial", "piratas", "para elisa", "", "fuego" };
    static private int estadoJuego { get; set; } = 1;
    static private string nivel { get; set; }
    static public int contadorIntentos { get; set; } = 1;
    static private int vidas { get; set; }
    static public string nombre { get; set; } = "";
    static public int puntosPPTJugador { get; set; } = 0;
    static public int puntosPPTBot { get; set; } = 0;
    static public List<char> listaAbecedario { get; set; } = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    public static void InicializarJuego()
    {
        contadorIntentos = 0;
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
            jugadaBot = jugadas[generarRandom(0, 3)];
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
            else if (jugada == jugadaBot)
                ganador = 3;
            else
                ganador = 4;
        }
        return ganador;
    }
    public static int generarRandom(int minimo, int maximo)
    {
        Random r = new Random();
        int numero = r.Next(minimo, maximo);
        return numero;
    }
    public static bool GuardarNombre(string Nombre)
    {
        bool nombreCorrecto = false;
        if (Nombre != null && listaAbecedario.IndexOf(Nombre[0]) != -1)
        {
            nombre = Nombre;
            nombreCorrecto = true;
        }
        return nombreCorrecto;
    }
    public static void GuardarNivel(string Nivel)
    {
        nivel = Nivel;
        if (Nivel == "facil")
            vidas = 10;
        else if (Nivel == "medio")
            vidas = 5;
        else if (Nivel == "dificil")
            vidas = 3;
    }
}