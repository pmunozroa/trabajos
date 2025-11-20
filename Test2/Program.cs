using System.Globalization;
using Test2.Enum;
using Test2.Models.Implementation;
//Rector
Rector rector = new Rector
{
    Nombre = "Juan",
    Apellido = "Pérez",
    AnioInicio = 2020,
    AnioFin = 2024
};
//Facultad 1
Facultad facultadIngenieria = new Facultad
{
    Nombre = "Ingeniería",
    Financiamiento = 1500000,
    CantidadFuncionarios = 120,
    Profesores = new List<Profesor>
    {
        new Profesor { Nombre = "Ana",  Apellido = "Gómez" },
        new Profesor { Nombre = "Luis", Apellido = "Díaz" }
    }
};
//Facultad 2
Facultad facultadMedicina = new Facultad
{
    Nombre = "Medicina",
    Financiamiento = 2000000,
    CantidadFuncionarios = 200,
    Profesores = new List<Profesor>
    {
        new Profesor { Nombre = "María",  Apellido = "López" },
        new Profesor { Nombre = "Carlos", Apellido = "Soto" }
    }
};
//Universidad
Universidad universidad = new Universidad
{
    Nombre = "Universidad Nacional",
    AnioFundacion = 1950,
    TipoFinanciamiento = TipoFinanciamiento.Publica,
    Facultades = new List<Facultad>
    {
        facultadIngenieria,
        facultadMedicina
    }
};

Console.WriteLine("========= Universidad =========");
Console.WriteLine($"Nombre: {universidad.Nombre}");
Console.WriteLine($"Año fundación: {universidad.AnioFundacion}");
Console.WriteLine($"Tipo financiamiento: {universidad.TipoFinanciamiento}");
Console.WriteLine();
Console.WriteLine("========= Rector =========");
Console.WriteLine($"Nombre: {rector.Nombre} {rector.Apellido}");
Console.WriteLine($"Periodo: {rector.AnioInicio} - {rector.AnioFin}");
Console.WriteLine();
Console.WriteLine("========= Facultades =========");
Console.WriteLine();
foreach (Facultad facultad in universidad.Facultades)
{
    Console.WriteLine("========= Facultad =========");
    Console.WriteLine($"Facultad: {facultad.Nombre}");
    Console.WriteLine($"Financiamiento: {facultad.Financiamiento.ToString("C0", CultureInfo.CurrentCulture)}");
    Console.WriteLine($"Cantidad funcionarios: {facultad.CantidadFuncionarios}");
    Console.WriteLine($"Profesores:");
    if (facultad.Profesores.Count > 0)
    {
        foreach (Profesor profesor in facultad.Profesores)
        {
            Console.WriteLine($"\t- {profesor.Nombre} {profesor.Apellido}");
        }
    }
    else
    {
        Console.WriteLine("\t(Sin profesores)");
    }

    Console.WriteLine();
}

Console.WriteLine("Presione una tecla para finalizar...");
Console.ReadKey();