namespace Certamen1.Models;
public class Pelicula
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Titulo { get; set; }
    public int DuracionMinutos { get; set; }
    public decimal PrecioEntradaBase { get; set; }
    public Genero Genero { get; set; }
    public string DirectorId { get; set; }
    public Director Director { get; set; }
    public string EstudioId { get; set; }
    public EstudioCinematografico Estudio { get; set; }
    public List<Entrada> Entradas { get; set; }
}
