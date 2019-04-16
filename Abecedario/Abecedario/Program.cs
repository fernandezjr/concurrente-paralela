using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abecedario
{
    class Program
    {
        static void Main(string[] args)
        {
            Imprimir();
            Console.ReadLine();
        }

        static void Imprimir()
        {
            Dictionary<char, string> abecedario = new Dictionary<char, string>();
            int i = 0;

            Task tarea1 = new Task(() =>
            {
                while (i < 26)
                {
                    if (EsPar(i))
                    {
                        abecedario.Add((char)(i + 65), "Tarea 1");
                        i++;
                    }
                }
            });

            Task tarea2 = new Task(() =>
            {
                while (i < 26)
                {
                    if (!EsPar(i))
                    {
                        abecedario.Add((char)(i + 65), "Tarea 2");
                        i++;
                    }
                }
            });

            Task tarea3 = new Task(() =>
            {
                foreach (KeyValuePair<char, string> par in abecedario)
                {
                    Console.WriteLine(par.Key + "   " + par.Value);
                }
            });

            tarea1.Start();
            tarea2.Start();

            Task.WaitAny(new Task[] { tarea1, tarea2 });

            tarea3.Start();
            tarea3.Wait();            
        }

        static bool EsPar(int numero)
        {
            return (numero % 2 == 0);
        }
    }
}