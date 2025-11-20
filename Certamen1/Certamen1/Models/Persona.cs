namespace Certamen1.Models;
public class Persona
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string RUT { get; set; }
    public string Nombre { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
