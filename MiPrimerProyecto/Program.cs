using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimerProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conversores objconversor = new Conversores();
            string continuar = "s";
            while (continuar == "s")
            {
                Console.WriteLine("....MENU....");
                Console.WriteLine("1. Monedas");
                Console.WriteLine("2. Longitud");
                Console.WriteLine("3. Masa");
                Console.WriteLine("4. Tiempo");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Opcion: ");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 0)
                {
                    continuar = "n";
                }
                else
                {
                    Console.Clear();
                   for (int i = 1; i < objconversor.etiquetas[opcion].Length; i++) {
                        Console.WriteLine("{0}. {1}", i, objconversor.etiquetas[opcion][i]);
                    }
                    Console.WriteLine("De: ");
                    int de = int.Parse(Console.ReadLine());

                    Console.WriteLine("A: ");
                    int a = int.Parse(Console.ReadLine());

                    Console.WriteLine("Cantidad: ");
                    double cantidad = double.Parse(Console.ReadLine()); 

                    Console.WriteLine("{0} \n", objconversor.convertir(de, a, cantidad, opcion));
                }
            }

        }
    }
}