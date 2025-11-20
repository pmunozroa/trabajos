namespace Trabajo1.Models
{
    internal record Artista : Persona
    {
        private string _profesion;

        public string Profesion
        {
            get => _profesion;
            set => _profesion = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Artista(DateTime fechaNacimiento)
        {
            FechaNacimiento = fechaNacimiento;
        }

        public Artista()
        {
        }
    }
}
