namespace Trabajo1.Models
{
    internal record Compra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<Entrada> Entradas { get; set; } = new();
    }
}
