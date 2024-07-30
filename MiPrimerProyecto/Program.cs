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
            //Estructuras de control.
            //1. if, ejercicio. Pedir al usuario la edad si es mayor de edad que diga bienvenido.
            string continuar = "s";
            while (continuar == "s")
            {
                Console.WriteLine();
                Console.WriteLine("*** MENU ***");
                Console.WriteLine("1. Promedio Notas");
                Console.WriteLine("2. Promedio Serie Numeros");
                Console.WriteLine("3. Clasificacion edad");
                Console.WriteLine("4. Tabla Multiplicar");
                Console.WriteLine("5. Salir");
                Console.Write("Opcion: ");
              Console.WriteLine();
               int opcion = int.Parse(Console.ReadLine());
                Console.Clear();//Limpiar la consola.
                switch (opcion)
                {
                    case 1://if (opcion==1)
                        promedio();
                        break;
                    case 2://if (opcion==2)
                        promedioserie();
                        break;
                    case 3://if (opcion==3)
                        clasificacionedad();
                        break;
                    case 4://if (opcion==4)
                        tablaMultiplicar();
                        break;
                    case 5://if (opcion==5)
                        continuar = "n";
                        break;
                    default://else
                        Console.WriteLine("opcion Incorrecta\n\n");
                        break;
                }
                }       
        }
        static void tablaMultiplicar()
        {
            Console.WriteLine("Tabla: ");
            int ntabla = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 10; i++)
            {//i++ => i = i + 1
                Console.WriteLine("{0} x {1} = {2}", ntabla, i, ntabla * i);

            }
        }
        static void promedio()
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
        }
        static void promedioserie()
        {
            int[] serie = new int[] { 5, 4, 6, 8, 9 }; //32
            int suma = 0;
            foreach (int num in serie)
            {
                suma += num;
            }
            double prom = suma / serie.Length;
            Console.Write("La suma es: {0}, el promedio {1}", suma, prom);
        }
        static void clasificacionedad() {
            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());
            if (edad < 0)
            {
                Console.WriteLine("Edad Incorrecta");
            }
            else if (edad <= 2)

            {
                Console.WriteLine("Eres un bebe");
            }
            else if (edad <= 12)

            {
                Console.WriteLine("Eres un niño");
            }
            else
            if (edad <= 18)
            {
                Console.WriteLine("Eres un adolescente");

            }
            else if (edad <= 65)

            {
                Console.WriteLine("Bienvenido al mundo de las responsabilidades.");
            }
            else if (edad <= 80)
            {
                Console.WriteLine("Eres un adulto mayor");
            }
            else
            {
                Console.WriteLine("Larga Vida");
            }
        }

    }
}
// \n\n para salto de linea