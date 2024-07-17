using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimerProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio de suma de dos numeros introducidos por el usuario.

            Console.WriteLine("Num1: ");
            double num1 = double.Parse(Console.ReadLine());  //"5" -> 5  
            
            Console.WriteLine("Num2: ");
            double num2 = double.Parse(Console.ReadLine()); 
            //
            double respuesta = num1 + num2;
            Console.WriteLine("La suma de {0} + {1} = {2}", num1, num2, respuesta);

            //Pausa
            Console.ReadLine();
        }
    }
}
