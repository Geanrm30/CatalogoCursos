using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoCursos
{
    class Program
    {
        // Lista estática de cursos con id, nombre y área
        static List<(int id, string name, string area)> Courses = new()
        {
            (1, "Algoritmos I", "CS"),
            (2, "Introducción a la Programación", "CS"),
            (3, "Matemática Discreta", "Math"),
            (4, "Estructuras de Datos", "CS"),
            (5, "Cálculo I", "Math")
        };

        static void Main()
        {
            // Configura el título y color de la consola
            Console.Title = "Catálogo de Cursos - Mini App";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine("      Catálogo de Cursos - Demo        ");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();

            bool salir = false;

            // Menú principal
            while (!salir)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Listar todos los cursos");
                Console.WriteLine("2. Buscar curso por nombre");
                Console.WriteLine("3. Ver cursos con paginación simulada");
                Console.WriteLine("4. Salir");
                Console.Write("\nOpción: ");
                string? opcion = Console.ReadLine();
                Console.WriteLine();

                // Control del menú
                switch (opcion)
                {
                    case "1":
                        ListarCursos();      // Muestra todos los cursos
                        break;
                    case "2":
                        BuscarCurso();       // Permite buscar por texto
                        break;
                    case "3":
                        PaginarCursos();     // Muestra los cursos por páginas
                        break;
                    case "4":
                        salir = true;        // Sale del programa
                        Console.WriteLine("Saliendo del catálogo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                        break;
                }
            }
        }

        // Muestra todos los cursos disponibles
        static void ListarCursos()
        {
            Console.WriteLine("=== Lista de Cursos ===");
            foreach (var c in Courses)
                Console.WriteLine($"[{c.id}] {c.name} - {c.area}");
            Console.WriteLine();
        }

        // Permite buscar cursos por nombre
        static void BuscarCurso()
        {
            Console.Write("Ingrese texto para buscar: ");
            var q = Console.ReadLine() ?? "";

            // Filtra cursos que contengan el texto ingresado (sin importar mayúsculas/minúsculas)
            var results = Courses
                .Where(c => c.name.Contains(q, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine($"\nResultados para \"{q}\":");
            if (results.Count == 0)
            {
                Console.WriteLine("No se encontraron cursos.\n");
                return;
            }

            // Muestra los resultados encontrados
            foreach (var c in results)
                Console.WriteLine($"[{c.id}] {c.name} - {c.area}");
            Console.WriteLine();
        }

        // Simula una paginación simple de los cursos
        static void PaginarCursos()
        {
            // Generado con ayuda de GitHub Copilot: estructura base del método y variables iniciales
            const int pageSize = 2; // Cantidad de cursos por página
            int totalPages = (int)Math.Ceiling((double)Courses.Count / pageSize);
            int page = 1;
            string? input;

            do
            {
                // Generado con ayuda de GitHub Copilot: impresión del encabezado de página
                Console.WriteLine($"\n=== Página {page} de {totalPages} ===");

                // Generado con ayuda de GitHub Copilot: uso de Skip y Take para paginación
                var items = Courses
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // Revisado manualmente: formato de salida de cursos
                foreach (var c in items)
                    Console.WriteLine($"[{c.id}] {c.name} - {c.area}");

                // Generado con ayuda de GitHub Copilot: menú de navegación (n/p/q)
                Console.WriteLine("\n[n] Siguiente | [p] Anterior | [q] Salir");
                Console.Write("Opción: ");
                input = Console.ReadLine();

                // Revisado manualmente: control de flujo y validación de entrada
                if (input == "n" && page < totalPages) page++;
                else if (input == "p" && page > 1) page--;
                else if (input != "q" && input != "")
                    Console.WriteLine("Comando no válido.\n");

            } while (input != "q");

            // Revisado manualmente: salto de línea final para claridad visual
            Console.WriteLine();
        }

    }
}