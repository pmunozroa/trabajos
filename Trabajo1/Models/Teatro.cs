namespace Trabajo1.Models
{
    internal record Teatro
    {
        public string Nombre { get; set; }
        public List<Trabajador> Trabajadores { get; set; }
        public List<Grupo> Grupos { get; set; }
        public List<Humorista> Humoristas { get; set; }
        public List<Compra> Compras { get; set; }
    }
}
