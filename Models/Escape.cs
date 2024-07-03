class Escape
{
    static public string[] incognitasSalas { get; set; } = { "0", "hola" };
    static public int estadoJuego{get;set;} = 1;
    static public int contadorIntentos{get;set;} = 0;

    private static void InicializarJuego(){
        
    }
    public static int GetEstadoJuego(){
        return estadoJuego;
    }
    public static bool ResolverSala(int Sala, string Incognita){
        bool esCorrecto = false;
        if (Incognita == incognitasSalas[Sala]){
            estadoJuego++;
            esCorrecto = true;
        }
        return esCorrecto;
    }
}