using System.ComponentModel;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
namespace Blackjack{

// Clase principal del juego
    class Juego{
    private List<Carta> baraja;
    private int puntajeJugador;
    private int puntajeBanca;

// Constructor que inicializa la baraja y la mezcla
    public Juego(){
        baraja = CrearBaraja();
        Barajar();
    }

// Método principal que inicia el juego
    public void Iniciar(){
        puntajeJugador = TurnoJugador();
        if(puntajeJugador > 21){
            Console.WriteLine("Has perdido!! Te has pasado de 21!!");
        } else{
            puntajeBanca = TurnoBanca();
            DeterminarGanador();
        }
    }

// Método que crea una baraja de cartas
    private List<Carta> CrearBaraja(){
        string[] palos = {"Corazones","Tréboles","Picas","Diamantes"};
        string[] figuras = {"J","Q","K"};
        List<Carta> nuevaBaraja = new List<Carta>();
    
        foreach(string palo in palos){

            for(int i=1; i <= 10; i++){
                nuevaBaraja.Add(new Carta(i.ToString(), palo, i));
            }
            foreach(string figura in figuras){
                nuevaBaraja.Add(new Carta(figura, palo, 10));
            }
        }
        return nuevaBaraja;
    } 

// Método para barajar la baraja, usando el algoritmo de Fisher-Yates.
    private void Barajar()
    {
        Random random = new Random();

        for (int i = baraja.Count - 1; i > 0; i--){
            int j = random.Next(i + 1);
            Carta temp = baraja[i];
            baraja[i] = baraja[j];
            baraja[j] = temp;
        }
    }

// Método que maneja el turno del jugador
    private int TurnoJugador(){
        int puntaje = 0;
        int cartasRecibidas = 0;

        while(true){
            Carta carta = baraja[0];
            baraja.RemoveAt(0);
            puntaje += carta.Valor;
            cartasRecibidas++;

            Console.WriteLine($"Has sacado: {carta}");
            Console.WriteLine($"Tu puntuaje actual es: {puntaje}");

            if(cartasRecibidas == 2 && puntaje == 21){
                Console.WriteLine("Blackjack natural!! Has ganado!!");
                return puntaje;
            }

            if(puntaje > 21){
                return puntaje;
            }

            Console.WriteLine("Quieres otra carta? (s/n)");
            string respuesta = Console.ReadLine()?.ToLower()??"";

            if(respuesta != "s"){
                break;
            }
        }
        return puntaje;
    }

// Método que maneja el turno de la banca
    private int TurnoBanca(){
        int puntaje = 0;
        Console.WriteLine("Turno de la banca....");

        while(puntaje < 17){
                    Carta carta = baraja[0];
        baraja.RemoveAt(0);
        puntaje += carta.Valor;
        Console.WriteLine($"La banca saca: {carta}");
        Console.WriteLine($"Puntaje de la banca: {puntaje}");
        }
        return puntaje;
    }

// Método que determina el ganador
    private void DeterminarGanador(){
        Console.WriteLine($"Puntaje final del jugador: {puntajeJugador}");
        Console.WriteLine($"Puntuaje final de la banca: {puntajeBanca}");

        if(puntajeBanca > 21 || puntajeJugador > puntajeBanca){
            Console.WriteLine("Felicidades!! Has ganado!!");
        }else if(puntajeJugador < puntajeBanca){
            Console.WriteLine("Que pena!! La banca gana!!");

        }else{
            Console.WriteLine("Es un empate!!");
        }
    }

    }
}
