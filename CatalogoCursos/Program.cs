using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoCursos
{
    class Program
    {
        // Datos de ejemplo (3–5 registros)
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
            Console.Title = "Catálogo de Cursos - Mini App";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine("      Catálogo de Cursos - Demo        ");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();

            bool salir = false;

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

                switch (opcion)
                {
                    case "1":
                        ListarCursos();
                        break;
                    case "2":
                        BuscarCurso();
                        break;
                    case "3":
                        PaginarCursos();
                        break;
                    case "4":
                        salir = true;
                        Console.WriteLine("Saliendo del catálogo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                        break;
                }
            }
        }
        static void ListarCursos()
        {
            Console.WriteLine("=== Lista de Cursos ===");
            foreach (var c in Courses)
                Console.WriteLine($"[{c.id}] {c.name} - {c.area}");
            Console.WriteLine();
        }
        static void BuscarCurso()
        {
            Console.Write("Ingrese texto para buscar: ");
            var q = Console.ReadLine() ?? "";
            var results = Courses
                .Where(c => c.name.Contains(q, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine($"\nResultados para \"{q}\":");
            if (results.Count == 0)
            {
                Console.WriteLine("No se encontraron cursos.\n");
                return;
            }

            foreach (var c in results)
                Console.WriteLine($"[{c.id}] {c.name} - {c.area}");
            Console.WriteLine();
        }

    }
}
