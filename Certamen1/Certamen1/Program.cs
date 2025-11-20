using Certamen1.Enums;
using Certamen1.Models;
//Diagrama https://mermaid.live/edit#pako:eNqNVetu0zAUfhXLEhKMtlrXdt2iCSm0BSrRi7rBDxQJufFZZkjsyHGkXehT8Qi8GCex06YlW8mfxOf4fN-554mGigP1aBizLBsLFmmWBJLgU0rIEnSmJCNPVlg8b6fcI9dGCxnVhKvcNEjnKllraFD4KcSx4GrJDGipXrgxe_bGBwjv2JyFIhEgDd4Y41Wr3wSyHsVYaAiN0nthFJYYGnKwpoB8KVQ2uU9BI3oomEeENI3oo7jghzr4q1fkE2jgjDDEXedGZYRDlc1GlEmSxsC42vNxpLiIVKXa9_LAfgmxCPP4P0p1I0weNyV0nOsyJzMhC49rEZfqJSZRqIk0mnH2nmVYV67ydQy1Ox9BgkZs-65juxI0ejTJTM6FOtQdZsgyHw_QOtrg3TxP0Cs_c_3yj-GXtQjLDHjkRqTqmsVsrxhJqlkzo0v-kQgswvEAys6u97Plt33WnEHXIsdSaBM9EhISZhRO-60I1XGHnp3jJRPZQosI5Iu8th3qPP5oNF3Md-fRYjYZT_2dYLzyZ34jWFWaOtx8sZr5n3fnr9Pl7nCzmlx_Hx9guREtRtsKqlV39avd3m6MBpUrQ4OmKkKNYgVx2VCQkfjP7wjbKyOvU9xEav0DcMbe2JvP1CWg3YAShdABPe10TvCwHXOPpFrxPNw64uTWpt1-5762uw_nQWCliqW7i2vP6KokKliqUfNIqLSGLFWSg1_F5drYGp2URl3r3c5OyDDOH5xz1Yas--bicVge0YCr-NHVYrsMX7JgBlE5UtAWjbTg1DM6hxbFGU9YcaRlgwTU3EECAfXwkzP9M6CB3KBNyuQ3pZLKTKs8uqPeLYszPOUpx-lzf8StVBeEeqRyaajX7ZUY1Hui99Tr9S47_W6_f3F2PrwcDnvdFn2g3vC0c9E965-fXgz6vcHgsrdp0ceSFBXDQYsCF1icmfsLF6_NX3ZbRZA


Director director = new Director
{
    RUT = "11.111.111-1",
    Nombre = "Juan",
    ApellidoPaterno = "Pérez",
    ApellidoMaterno = "Gómez",
    FechaNacimiento = new DateTime(1975, 5, 10),
    Nacionalidad = "Chilena",
    Experiencia = 15,
};

EstudioCinematografico estudio = new EstudioCinematografico
{
    Nombre = "Andes Films",
    PaisOrigen = "Chile",
};

List<Pelicula> peliculas = new List<Pelicula>
{
    new Pelicula
    {
        Titulo = "Acción en Santiago",
        DuracionMinutos = 120,
        PrecioEntradaBase = 6000m,
        Genero = Genero.ACCION,
        Director = director,
        DirectorId = director.Id,
        Estudio = estudio,
        EstudioId = estudio.Id,
        Entradas = new List<Entrada>(),
    },
    new Pelicula
    {
        Titulo = "Risas en la Noche",
        DuracionMinutos = 100,
        PrecioEntradaBase = 5500m,
        Genero = Genero.COMEDIA,
        Director = director,
        DirectorId = director.Id,
        Estudio = estudio,
        EstudioId = estudio.Id,
        Entradas = new List<Entrada>(),
    },
    new Pelicula
    {
        Titulo = "Drama en la Cordillera",
        DuracionMinutos = 130,
        PrecioEntradaBase = 6500m,
        Genero = Genero.DRAMA,
        Director = director,
        DirectorId = director.Id,
        Estudio = estudio,
        EstudioId = estudio.Id,
        Entradas = new List<Entrada>(),
    },
};

Cliente cliente = new Cliente
{
    RUT = "22.222.222-2",
    Nombre = "María",
    ApellidoPaterno = "López",
    ApellidoMaterno = "Rojas",
    FechaNacimiento = new DateTime(1995, 3, 20),
    Compras = new List<Compra>(),
};

Empleado empleado = new Empleado
{
    RUT = "33.333.333-3",
    Nombre = "Carlos",
    ApellidoPaterno = "Soto",
    ApellidoMaterno = "Vega",
    FechaNacimiento = new DateTime(1990, 1, 15),
    CodigoEmpleado = "EMP-001",
    ComprasAtendidas = new List<Compra>(),
};

Console.WriteLine("====== Sistema de Compras Cineplanet ======");

bool continuar = true;

while (continuar)
{
    Console.WriteLine();
    Console.WriteLine("====== Cartelera ======");

    for (int i = 0; i < peliculas.Count; i++)
    {
        Pelicula p = peliculas[i];
        Console.WriteLine($"{i + 1} - {p.Titulo} ({p.Genero}) - {p.PrecioEntradaBase} CLP");
    }

    Console.Write("Seleccione una película por número (0 para salir):");
    if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 0 || opcion > peliculas.Count)
    {
        Console.WriteLine("Opción inválida.");
        continue;
    }

    if (opcion == 0)
    {
        Console.WriteLine("Saliendo del sistema...");
        break;
    }

    Pelicula peliculaSeleccionada = peliculas[opcion - 1];

    Console.Write($"¿Cuántas entradas desea comprar para \"{peliculaSeleccionada.Titulo}\"?");
    if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
    {
        Console.WriteLine("Cantidad inválida.");
        continue;
    }

    // Crear compra para esta película
    Compra compra = new Compra(DateTime.Now)
    {
        Cliente = cliente,
        ClienteId = cliente.Id,
        Empleado = empleado,
        EmpleadoId = empleado.Id,
        Entradas = new List<Entrada>(),
    };

    cliente.Compras.Add(compra);
    empleado.ComprasAtendidas.Add(compra);

    for (int i = 1; i <= n; i++)
    {
        Console.Write($"Ingrese número de asiento para la entrada {i}:");
        string? numeroAsiento = Console.ReadLine();

        if (
            string.IsNullOrWhiteSpace(numeroAsiento)
            || !short.TryParse(numeroAsiento, out short asiento)
            || asiento < 1
        )
        {
            Console.WriteLine("Número de asiento inválido. Se cancela la compra actual.");
            compra.Entradas.Clear();
            break;
        }

        Entrada entrada = new Entrada(asiento)
        {
            Precio = peliculaSeleccionada.PrecioEntradaBase,
            Ubicacion = TipoSala.NORMAL,
            Pelicula = peliculaSeleccionada,
            PeliculaId = peliculaSeleccionada.Id,
            Compra = compra,
            CompraId = compra.Id,
        };

        compra.Entradas.Add(entrada);
        peliculaSeleccionada.Entradas.Add(entrada);
    }

    if (compra.Entradas.Count == 0)
    {
        // No se concretó la compra
        continue;
    }

    decimal total = 0m;
    foreach (Entrada entrada in compra.Entradas)
    {
        total += entrada.Precio;
    }

    Console.WriteLine();
    Console.WriteLine("====== Resumen de la Compra ======");
    Console.WriteLine($"Fecha   : {compra.Fecha}");
    Console.WriteLine($"Cliente : {cliente.Nombre} {cliente.ApellidoPaterno}");
    Console.WriteLine($"Empleado: {empleado.Nombre} {empleado.ApellidoPaterno}");
    Console.WriteLine($"Película: {peliculaSeleccionada.Titulo}");
    Console.WriteLine($"Entradas: {compra.Entradas.Count}");
    Console.WriteLine("Asientos:");

    foreach (Entrada entrada in compra.Entradas)
    {
        Console.WriteLine($" - Asiento {entrada.NumeroAsiento}, Precio {entrada.Precio} CLP");
    }

    Console.WriteLine($"TOTAL A PAGAR: {total} CLP");

    Console.WriteLine();
    Console.Write("¿Desea comprar entradas para otra película? (s/n):");
    string? respuesta = Console.ReadLine();

    if (!string.Equals(respuesta, "s", StringComparison.OrdinalIgnoreCase))
    {
        continuar = false;
    }
}

Console.WriteLine("Gracias por usar el sistema de compras Cineplanet.");
