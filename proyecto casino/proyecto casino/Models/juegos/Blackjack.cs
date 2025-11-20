using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_casino.Models.juegos
{
    internal class Blackjack:Ijuego
    {
        private List<carta> cartaList;
        private List<carta> mano_cliente;
        private List<carta> mano_crupier;
        private int apuesta;

        internal List<carta> CartaList { get => cartaList; set => cartaList = value; }
        internal List<carta> Mano_cliente { get => mano_cliente; set => mano_cliente = value; }
        internal List<carta> Mano_crupier { get => mano_crupier; set => mano_crupier = value; }
        public int Apuesta { get => apuesta; set => apuesta = value; }

        public Blackjack(List<carta> cartaList, int apuesta)
        {
            CartaList = cartaList;
            Mano_cliente= new List<carta>();
            Mano_crupier= new List<carta>();
            Apuesta = apuesta;
        }
        public string Resultado()
        {
            return $"";
        }
    }
}
