using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine("SERIE FIBONACCI POR DIEGO CERON");
            Console.WriteLine("El enésimo numero de la secuencia de Fibonacci es: " + GetNumberFibonaci(7));
            Console.WriteLine("(PRESIONE ENTER PARA CONTINUAR)");
            Console.ReadKey();
            Console.WriteLine("Te gustaria probar con otro numero: ");

            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n > 0)
                {
                    Console.WriteLine("El posición del numero " + n + " de la secuencia de Fibonacci es: " + GetNumberFibonaci(n));
                    Console.WriteLine("(LA APLICACION FINALIZO)");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("CARACTER NO ADMITIDO. (LA APLICACION FINALIZO)");
                Console.ReadKey();
            }

        }


        public static int GetNumberFibonaci(int poisition)
        {
            int a, b, i, auxiliar;

            a = 0;
            b = 1;
            for (i = 0; i < poisition; i++)
            {
                auxiliar = a;
                a = b;
                b = auxiliar + a;
            }

            return a;
        }
    }
}
