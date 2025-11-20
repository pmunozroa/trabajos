using Test1.Models;

List<Producto> productos = new List<Producto>();
int opcion;

do
{
    Console.WriteLine("==== Menú ====");
    Console.WriteLine("1. Crear producto");
    Console.WriteLine("2. Mostrar todos los productos");
    Console.WriteLine("3. Salir");
    Console.Write("Ingrese opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Opción inválida.\n");
        continue;
    }

    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese nombre del producto: ");
            string nombre = Console.ReadLine() ?? string.Empty;

            Console.Write("Ingrese precio del producto: ");
            if (!double.TryParse(Console.ReadLine(), out double precio))
            {
                Console.WriteLine("Precio inválido.\n");
                break;
            }

            var nuevoProducto = new Producto(nombre, precio);
            productos.Add(nuevoProducto);
            Console.WriteLine("Producto creado y agregado a la lista.\n");
            break;

        case 2:
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos creados aún.\n");
            }
            else
            {
                Console.WriteLine("===== Lista de productos =====");
                int i = 1;
                foreach (var p in productos)
                {
                    Console.WriteLine($"Producto #{i++}:");
                    p.MostrarInformacion();
                    Console.WriteLine();
                }
            }
            break;

        case 3:
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción no válida.\n");
            break;
    }

} while (opcion != 3);