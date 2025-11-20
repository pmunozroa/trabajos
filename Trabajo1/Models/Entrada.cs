using Trabajo1.Enum;

namespace Trabajo1.Models
{
    internal record Entrada
    {
        public int NumeroAsiento { get; set; }
        public TipoUbicacionEntrada Ubicacion { get; set; }
        public decimal Precio { get; set; }
    }
}
