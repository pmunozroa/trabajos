namespace Test2.Models.Implementation
{
    internal record Facultad
    {
        public string Nombre { get; set; }
        public double Financiamiento { get; set; }
        public int CantidadFuncionarios { get; set; }
        public List<Profesor> Profesores { get; set; }

        void AgregarProfesor(Profesor profesor)
        {
            if (Profesores == null)
            {
                Profesores = new List<Profesor>();
            }
            Profesores.Add(profesor);
        }
    }
}
