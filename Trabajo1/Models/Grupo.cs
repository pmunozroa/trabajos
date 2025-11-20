using Trabajo1.Enum;

namespace Trabajo1.Models
{
    internal record Grupo
    {
        private string _nombre;
        private int _cantidadIntegrantes;
        private TipoGrupo _tipo;
        private readonly List<Artista> _integrantes;

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int CantidadIntegrantes
        {
            get => _cantidadIntegrantes;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "La cantidad de integrantes debe ser mayor que cero.");
                _cantidadIntegrantes = value;
            }
        }

        public TipoGrupo Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }

        public List<Artista> Integrantes => _integrantes;

        public Grupo(int cantidadIntegrantes)
        {
            CantidadIntegrantes = cantidadIntegrantes;
            _integrantes = new List<Artista>(cantidadIntegrantes);
        }

        public void AgregarArtista(Artista artista)
        {
            if (artista == null) throw new ArgumentNullException(nameof(artista));
            _integrantes.Add(artista);
        }
    }
}
