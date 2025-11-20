using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_casino.Models.juegos
{
    internal class tragamonedas:Ijuego
    {
        private List<carta> cartas;

        internal List<carta> Cartas { get => cartas; set => cartas = value; }

        public tragamonedas(List<carta> cartas)
        {
            Cartas = cartas;
        }
        public string Resultado()
        {
            return $"";
        }
    }
}
