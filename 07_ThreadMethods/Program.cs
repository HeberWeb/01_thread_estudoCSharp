using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_ThreadMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread Sleep
            Console.WriteLine("Inicio do processo");
            Thread.Sleep(3000);
            Console.WriteLine("Fim do processo");


            //Thread Join
            Thread t1 = new Thread(ThreadRepeticao);
            t1.Start();
            t1.Join(); //Aguarda a Thread acima para realizar o fim da thread atual exibindo os Consoles abaixo

            Console.WriteLine("Fim do processo");
            Console.WriteLine("Fim do processo");
            Console.WriteLine("Fim do processo");
            Console.WriteLine("Fim do processo");
            Console.ReadKey();
        }

        static void ThreadRepeticao(object id)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Thread: " + id + " Num " + i + " Id Interno: " + Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
