using Trabajo1.Models;
using Trabajo1.Enum;
//Diagrama https://mermaid.live/edit#pako:eNqNVVtvmzAU_ivIT1uXVEnIpUVVpSjdukprF03Zy8TLKXapN7DRwUjbsvDbZ8DcgpmGlOBz8TnH3_cBRxJIyohHggjS9I5DiBD7wtFX6XH2DFMpwDlWzuJ6lyrkInS-ZGrofJLxM7Khf5uwKOJU7kExFHI84XGQcKc9Bx4z5wMLXuEJAh5zJpRJOfmiO-8uKmKs6zogPMN3oBJtp9gBhm2pdtfHLJbIU2U9-h1LA-RJwKUYBg88keVuS9UtqrGae5QvLO1XNOlvGghe-hC8tWLwXigE2m_ChXKespih3KYd9MpYMfDXZx5AcZ56c-PoJFKmG0OkR9WLEfxlnOCw9QMdJbQTMOT1SSwjnzQMuRktrw-YWie4xyyRNoAH0iwG24FQnAJ90P209vV_eoZMVa9Ync9j2Mkd--ZtiCwErDmsqYfqbqfuwEDh_01fjtBqO-_ovDdGmVceIq-wGQQbqeet6gdJFbG5IdgOvVVInbPc3DCRxbe3receIoa8o4F9pMXRtSEK5GizAdfDDo9ZqgeKWkcFcWt_bqymQf3Su_kznfbF2Iu0gFuCDZKWmJFC3c6Q7pO5Txyp4z650Kvz8iNpJQb_zDgbZSSrIraeyTzH50mGVEvOdHprVg1gVVbFURW6aAqdQVCLpahiU1G3VJ1TWmRCQuSUeAozNiH6BRdDYZJSFD5RryxmPvH0kgL-8IkvTnpPAuKblHG9DWUWvhLvBaJUW1lCtQjNx7DxIhOU4U5mQhFvPnPLIsQ7kp_aXC0vl9crd61_7mI1v1pMyC_ibTaXs7mOrReue3Xtrk8T8rvsOrvcrGbLq8VqvXRnK3fpbiaEUa4kPprPcXE7_QXVSlTQ
Teatro teatro = new Teatro
{
    Nombre = "Teatro Municipal",
    Grupos = new List<Grupo>(),
};

Console.Write("Ingrese la cantidad de grupos a registrar:");

if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
{
    Console.WriteLine("Cantidad inválida.");
    return;
}

for (int i = 0; i < n; i++)
{
    Console.WriteLine();
    Console.WriteLine($"====== Grupo #{i + 1} ======");
    Console.Write("Nombre del grupo:");

    var nombreGrupo = Console.ReadLine() ?? string.Empty;

    Console.Write("Tipo de grupo (0=Musical, 1=Teatro, 2=Otro):");
    Enum.TryParse(Console.ReadLine(), out TipoGrupo tipoGrupo);

    Console.Write("Cantidad de integrantes:");
    if (!int.TryParse(Console.ReadLine(), out int cantIntegrantes) || cantIntegrantes <= 0)
    {
        Console.WriteLine("Cantidad inválida, omitido.");
        continue;
    }

    Grupo grupo = new Grupo(cantIntegrantes)
    {
        Nombre = nombreGrupo,
        Tipo = tipoGrupo
    };

    for (int j = 0; j < cantIntegrantes; j++)
    {
        Console.WriteLine($"  - Artista #{j + 1}");
        Console.Write("\tNombre: ");

        string? nombreArtista = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nombreArtista))
        {
            Console.WriteLine("Nombre invalido");
            return;
        }
        Console.Write("\tApellido paterno:");

        string? apePat = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(apePat))
        {
            Console.WriteLine("Apellido invalido");
            return;
        }
        Console.Write("\tProfesión:");

        string? profesion = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(profesion))
        {
            Console.WriteLine("Profesion invalida");
            return;
        }

        Console.Write("\tFecha nacimiento (yyyy-MM-dd):");
        if (!DateTime.TryParse(Console.ReadLine(), out var fechaNacimiento))
        {
            Console.WriteLine("Fecha no valida");
            return;
        }

        Artista artista = new Artista(fechaNacimiento)
        {
            Nombre = nombreArtista,
            ApellidoPaterno = apePat,
            Profesion = profesion
        };
        grupo.AgregarArtista(artista);
    }
    teatro.Grupos.Add(grupo);
}

int totalIntegrantes = 0;
foreach (Grupo grupo in teatro.Grupos)
{
    totalIntegrantes += grupo.CantidadIntegrantes;
}

Console.WriteLine();
Console.WriteLine("======================================");
Console.WriteLine($"Total de grupos registrados : {teatro.Grupos.Count}");
Console.WriteLine($"Suma total de integrantes de todos los grupos: {totalIntegrantes}");
Console.WriteLine("======================================");
Console.WriteLine("Presione una tecla para finalizar...");
Console.ReadKey();