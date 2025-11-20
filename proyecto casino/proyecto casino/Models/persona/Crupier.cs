namespace proyecto_casino.Models.persona
{
    internal class Crupier : Persona
    {
        private string nombre;
        private string apellidos;
        private int edad;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }

        public Crupier(string nombre, string apellidos, int edad)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
        }


    }
}
