using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimerProyecto
    //Ejercicio de nota de computo y obtencion de nota final de ciclo.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Computo 1 ");
            Console.WriteLine();

            Console.WriteLine("laboratorio 1: ");
            double lab1 = double.Parse(Console.ReadLine());


            Console.WriteLine("laboratorio 2: ");
            double lab2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Parcial 1: ");
            double Parcial1 = double.Parse(Console.ReadLine());

            Console.WriteLine();

            double c1 = lab1 * 30 / 100 + lab2 * 30 / 100 + Parcial1 * 40 / 100;
            Console.WriteLine("La nota de Computo 1 es: {0}", c1);

            Console.WriteLine();

            Console.WriteLine("Computo 2 ");
            Console.WriteLine();

            Console.WriteLine("laboratorio 1: ");
            lab1 = double.Parse(Console.ReadLine());

            Console.WriteLine("laboratorio 2: ");
            lab2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Parcial 2: ");
            Parcial1 = double.Parse(Console.ReadLine());

            Console.WriteLine();

            double c2 = lab1 * 30 / 100 + lab2 * 30 / 100 + Parcial1 * 40 / 100;
            Console.WriteLine("La nota de Computo 2 es: {0}", c2);

            Console.WriteLine();

            Console.WriteLine("Computo 3 ");
            Console.WriteLine();


            Console.WriteLine("laboratorio 1: ");
            lab1 = double.Parse(Console.ReadLine());

            Console.WriteLine("laboratorio 2: ");
            lab2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Parcial 3: ");
            Parcial1 = double.Parse(Console.ReadLine());

            Console.WriteLine();

            double c3 = lab1 * 30 / 100 + lab2 * 30 / 100 + Parcial1 * 40 / 100;
            Console.WriteLine("La nota de Computo 3 es: {0}", c3);

            Console.WriteLine();

            double Final = (c1 + c2 + c3) / 3;
            Console.WriteLine("La nota final es: {0}", Final);

            Console.ReadLine();

        }
    }
}
