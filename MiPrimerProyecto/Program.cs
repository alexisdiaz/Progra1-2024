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
            double[,] matriz = new double[,] {
                {0.01,   472.00,  0, 0}, //Tramo 1
                {472.01, 895.24, 10, 17.67}, //Tramo 2
                {895.25, 2038.10, 20, 60.00}, //Tramo 3
                {2038.11, 99999999, 30, 288.57},//Tramo 4
                
            };
           
                    Console.WriteLine("Sueldo: ");
                    double sueldo = double.Parse(Console.ReadLine());
                    double afp = sueldo * 6.25 / 100;
                   double isss = sueldo * 3 / 100;
           


            sueldo -= afp;
                
            double isr = 0;

                    for (int i = 0; i < 4; i++) {
                        if (sueldo >= matriz[i, 0] && sueldo <= matriz[i, 1])
                        {
                   
                        isr = (sueldo - matriz[i, 0]) * matriz[i, 2]/100 + matriz[i, 3];
                            
                        }
                        Console.WriteLine("\n");
                    }
                    Console.ReadKey();
                    sueldo -= isss;
                    sueldo -= isr;
                    Console.WriteLine("Sueldo Neto: {0}, AFP: {1}, ISSS: {2}, ISR: {3}", Math.Round(sueldo, 2), afp, isss, Math.Round(isr, 2));
                    Console.ReadLine();
                
            

        }

    }
}
// \n\n para salto de linea