namespace Certamen1.Models;
public class Empleado : Persona
{
    public string CodigoEmpleado { get; set; }
    public List<Compra> ComprasAtendidas { get; set; }
}
