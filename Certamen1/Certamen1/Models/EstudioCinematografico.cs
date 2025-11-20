namespace Certamen1.Models;
public class EstudioCinematografico
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Nombre { get; set; }
    public string PaisOrigen { get; set; }
    public List<Pelicula> Peliculas { get; set; }
}
