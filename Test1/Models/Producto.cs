using System;
using System.Globalization;

namespace Test1.Models
{
    internal record Producto
    {
        public string nombre { get; set; }
        public double precio { get; set; }

        public Producto(string nombre, double precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }
        public string Nombre()
        {
            return this.nombre;
        }

        public double Precio()
        {
            return this.precio;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("====== Información del producto ======");
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Precio: {this.precio.ToString("C", CultureInfo.CurrentCulture)}");
        }
    }
}
