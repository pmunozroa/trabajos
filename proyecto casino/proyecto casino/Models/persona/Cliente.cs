namespace proyecto_casino.Models.persona
{
    internal class Cliente : Persona
    {
        private string nombre;
        private string contrasena;

        public Cliente(string nombre, string contrasena)
        {
            this.Nombre = nombre;
            this.Contrasena = contrasena;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}
