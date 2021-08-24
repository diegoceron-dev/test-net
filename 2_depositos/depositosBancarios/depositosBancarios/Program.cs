using depositosBancarios.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace depositosBancarios
{
    class Program
    {
        static int tableWidth = 75;

        static void Main(string[] args)
        {
            Console.WriteLine("Los datos de depositos son: ");

            IEnumerable<Deposito> depositosBancarios = DataBuild();
            PrintLine();
            PrintRow("Titular", "Monto");
            PrintLine();
            foreach (var item in depositosBancarios)
            {
                PrintRow(item.Name, "$" + item.Amount.ToString());
            }
            PrintLine();

            Console.WriteLine("Se desea conocer el Nombre del Titular, el monto mínimo depositado, el monto máximo depositado, el número de depósitos realizados y el promedio de ellos de todos los usuarios que tuvieron más deun depósito y que el promedio de depósitos realizados supero los $50");
            Console.WriteLine("Desea mostrar reporte (PRESIONE ENTER)");
            Console.ReadKey();
            GenerataReport(depositosBancarios, false);
            Console.WriteLine("Desea mostrar el reporte sin filtros (PRESIONE ENTER)");
            Console.ReadKey();
            GenerataReport(depositosBancarios, true);
            Console.ReadKey();
            Console.WriteLine("La aplicación finalizo (PRESIONE ENTER)");
            Console.ReadKey();
        }


        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        static IEnumerable<Deposito> DataBuild()
        {
            List<Deposito> data = new List<Deposito>();
            Deposito deposito = new Deposito();

            deposito.ID = 1;
            deposito.Name = "Ana";
            deposito.Amount = 50;
            data.Add(deposito);

            deposito = new Deposito();
            deposito.ID = 2;
            deposito.Name = "Paco";
            deposito.Amount = 10;
            data.Add(deposito);

            deposito = new Deposito();
            deposito.ID = 1;
            deposito.Name = "Ana";
            deposito.Amount = 20;
            data.Add(deposito);

            deposito = new Deposito();
            deposito.ID = 3;
            deposito.Name = "Jorge";
            deposito.Amount = 55;
            data.Add(deposito);

            deposito = new Deposito();
            deposito.ID = 4;
            deposito.Name = "Laura";
            deposito.Amount = 75;
            data.Add(deposito);

            deposito = new Deposito();
            deposito.ID = 4;
            deposito.Name = "Laura";
            deposito.Amount = 3;
            data.Add(deposito);

            deposito = new Deposito();
            deposito.ID = 4;
            deposito.Name = "Laura";
            deposito.Amount = 50;
            data.Add(deposito);

            return data.AsEnumerable();
        }

        static void GenerataReport(IEnumerable<Deposito> depositosBancarios, bool filter)
        {
            var customerList = depositosBancarios.GroupBy(
                    customer => customer.ID
                );

            if(!filter)
                customerList = customerList.Where(c => c.Count() > 1 && c.Average(d => d.Amount) > 50);

            PrintLine();
            PrintRow("Titular", "Monto mínimo", "Monto máximo", "N. depositos", "Promedio");

            foreach (var customer in customerList)
            {
                decimal min = customer.Min(d => d.Amount);
                decimal max = customer.Max(d => d.Amount);
                int quan = 0;
                decimal prom = 0;
                string name = "";
                int id = 0;

                foreach (var item in customer)
                {
                    quan = quan + 1;
                    name = item.Name;
                    id = item.ID;
                    prom = prom + item.Amount;
                }

                prom = prom / quan;
                prom = decimal.Round(prom, 2);
                PrintRow(name, min.ToString(), max.ToString(), quan.ToString(), prom.ToString());
            }

            if (customerList.ToList().Count() == 0)
            {
                PrintLine();
                Console.WriteLine(" NO HAY RESULTADOS POR MORSTRAR. NINGUN CLIENTE CUMPLE CON LOS REQUISITOS");
            }

            PrintLine();
        }
    }
}
