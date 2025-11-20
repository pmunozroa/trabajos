namespace Test2.Models.Implementation
{
    internal record Profesor : Persona
    {
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
