namespace proyecto_casino.Models.persona
{
    internal class Administrador:Persona
    {
        private string nombre;
        private string contraseña;

        public Administrador(string nombre, string contraseña)
        {
            this.nombre = nombre;
            this.contraseña = contraseña;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
    }
}
