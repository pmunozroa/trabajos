namespace Certamen1.Models;
public class Entrada
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public decimal Precio { get; set; }
    public int NumeroAsiento { get; set; }
    public TipoSala Ubicacion { get; set; }
    public string CompraId { get; set; }
    public Compra Compra { get; set; }
    public string PeliculaId { get; set; }
    public Pelicula Pelicula { get; set; }

    public Entrada(int numeroAsiento)
    {
        NumeroAsiento = numeroAsiento;
    }
}
