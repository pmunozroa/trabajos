using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_casino.Models.juegos
{
    internal class Dados:Ijuego
    {
        private int resultado;
        private int apuesta;
        private int valorapostado;

        public Dados(int resultado, int apuesta, int valorapostado)
        {
            this.resultado = resultado;
            this.apuesta = apuesta;
            this.valorapostado = valorapostado;
        }

        public int resultados { get => resultado; set => resultado = value; }
        public int Apuesta { get => apuesta; set => apuesta = value; }
        public int Valorapostado { get => valorapostado; set => valorapostado = value; }
        public string Resultado()
        {
            return $"el valor del dado es {resultado}";
        }
    }
}
