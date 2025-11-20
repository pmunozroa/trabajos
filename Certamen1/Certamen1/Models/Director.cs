namespace Certamen1.Models;
public class Director : Persona
{
    public string Nacionalidad { get; set; }
    public int Experiencia { get; set; }
    public List<Pelicula> Peliculas { get; set; }
}
