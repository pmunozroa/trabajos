namespace Certamen1.Models;

public class Compra
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime Fecha { get; set; }
    public string ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public string EmpleadoId { get; set; }
    public Empleado Empleado { get; set; }
    public List<Entrada> Entradas { get; set; }

    public Compra(DateTime fecha)
    {
        Fecha = fecha;
    }
}
