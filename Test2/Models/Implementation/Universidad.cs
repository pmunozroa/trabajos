using Test2.Enum;

namespace Test2.Models.Implementation
{
    internal record Universidad
    {
        public string Nombre { get; set; }
        public int AnioFundacion { get; set; }
        public TipoFinanciamiento TipoFinanciamiento { get; set; }
        public List<Facultad> Facultades { get; set; }

        void AgregarFacultad(Facultad facultad)
        {
            if (Facultades == null)
            {
                Facultades = new List<Facultad>();
            }
            Facultades.Add(facultad);
        }
    }
}
