namespace Blackjack
{
    class Carta
    {
        public string Nombre { get; set; }
        public string Palo { get; set; }
        public int Valor { get; set; }

        public Carta(string nombre, string palo, int valor)
        {
            Nombre = nombre;
            Palo = palo;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"{Nombre} de {Palo}";
        }
    }
}
