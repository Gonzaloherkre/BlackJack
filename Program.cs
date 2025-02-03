class Program {
    static void Main() {
        Blackjack juego = new Blackjack();
        bool seguirJugando = true;

        Console.WriteLine("¡Qué comience el juego!");
        juego.RobarCartaJugador();
        juego.RobarCartaJugador();

        while (seguirJugando) {
            Console.WriteLine("Tienes: " + string.Join(", ", juego.ObtenerManoJugador()));
            Console.WriteLine("¿Quieres otra carta? (S/N)");
            string respuesta = Console.ReadLine();

            if (respuesta == "S") {
                juego.RobarCartaJugador();
                if (juego.CalcularPuntos(juego.ObtenerManoJugador()) > 21) {
                    Console.WriteLine("Te pasaste de 21, pierdes.");
                    return;
                }
            } else {
                seguirJugando = false;
            }
        }

        juego.JugarBanca();
        int puntosJugador = juego.CalcularPuntos(juego.ObtenerManoJugador());
        int puntosBanca = juego.CalcularPuntos(juego.ObtenerManoBanca());

        Console.WriteLine("Mano de la banca: " + string.Join(", ", juego.ObtenerManoBanca()));
        Console.WriteLine("Puntos del jugador: " + puntosJugador);
        Console.WriteLine("Puntos de la banca: " +puntosBanca);

        if (puntosBanca > 21 || puntosJugador > puntosBanca) {
            Console.WriteLine("¡Enhorabuena, has ganado!");
        } else if (puntosJugador == puntosBanca) {
            Console.WriteLine("Empate");
        } else {
            Console.WriteLine("Has perdido. La banca gana");
        }
    }
}