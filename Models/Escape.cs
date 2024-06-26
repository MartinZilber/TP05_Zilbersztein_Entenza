class Escape
{
    static private string[] incognitasSalas { get; set; } = { "bla,", "hola" };
    static private int estadoJuego{get;set;} = 1;

    private static void InicializarJuego(){

    }
    public static int GetEstadoJuego(){
        return 1; //cambiar
    }
    public static bool ResolverSala(int Sala, string Incognita){
        bool esCorrecto = false;
        if (Incognita == incognitasSalas[Sala]){
            estadoJuego++;
            esCorrecto = true;
        }
        else if (incognitasSalas.Length == 0){
            InicializarJuego();
        }
        return esCorrecto;
    }
}