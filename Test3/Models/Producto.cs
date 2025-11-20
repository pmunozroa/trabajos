using System;
using Test3.Enums;

namespace Test3.Models
{
    internal record Producto
    {
        public string Nombre { get; set; }
        public Categoria Categoria { get; set; }
        public int Precio { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
