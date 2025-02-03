class Carta {
    public string Valor { get; }
    public string Palo { get; }

    public Carta(string valor, string palo) {
        Valor = valor;
        Palo = palo;
    }

    public int ObtenerValor() {
        if (Valor == "J" || Valor == "Q" || Valor == "K") return 10;
        if (Valor == "A") return 1;
        return int.Parse(Valor);
    }

    public override string ToString() {
        Console.WriteLine(""+Valor "de" + Palo);
    }
}

class Baraja {
    private List<Carta> cartas;
    private static string[] Palos = { "Corazones", "Tréboles", "Picas", "Diamantes" };
    private static string[] Valores = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public Baraja() {
        cartas = new List<Carta>();
        InicializarBaraja();
        Barajar();
    }

    private void InicializarBaraja() {
        cartas.Clear();
        foreach (var palo in Palos) {
            foreach (var valor in Valores) {
                cartas.Add(new Carta(valor, palo));
            }
        }
    }

    public void Barajar() {
        Random rnd = new Random();
        cartas.Sort((a, b) => rnd.Next(-1, 2));
    }

    public Carta RobarCarta() {
        if (cartas.Count == 0) return null;
        Carta carta = cartas[0];
        cartas.RemoveAt(0);
        return carta;
    }
}

class Blackjack {
    private Baraja baraja;
    private List<Carta> manoJugador;
    private List<Carta> manoBanca;

    public Blackjack() {
        baraja = new Baraja();
        manoJugador = new List<Carta>();
        manoBanca = new List<Carta>();
    }

    public void RobarCartaJugador() {
        manoJugador.Add(baraja.RobarCarta());
    }

    public void JugarBanca() {
        while (CalcularPuntos(manoBanca) < 17) {
            manoBanca.Add(baraja.RobarCarta());
        }
    }

    public int CalcularPuntos(List<Carta> mano) {
        int puntos = 0;
        foreach (var carta in mano) {
            puntos += carta.ObtenerValor();
        }
        return puntos;
    }

    public List<Carta> ObtenerManoJugador() => manoJugador;
    public List<Carta> ObtenerManoBanca() => manoBanca;
}
