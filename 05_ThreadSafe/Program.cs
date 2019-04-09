using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_ThreadSafe
{
    class Program
    {
        static int Rede = 0;
        static object variaveDeControle = 0;
        //IO Input/Output - Lento (Tela, Rede, Armazenamento, Impressora-Rede)
        static void Main(string[] args)
        {
            Console.WriteLine("DataIni: " + DateTime.Now);
            for (int i = 0; i < 5; i++)
            {
                Thread t1 = new Thread(ThreadRepeticao);
                t1.IsBackground = true; //Ex: Interação das threads via utilização do usuário
                t1.Start();
            }

            Console.ReadKey();
        }

        static void ThreadRepeticao()
        {
            //Fila FIFO - First in e First Out
            for (int i = 0; i < 1000; i++)
            {
                lock (variaveDeControle)// Aguarda oque está dentro do lock ser executado para continuar o loop
                {
                    Console.WriteLine("Num " + i);
                    Rede++;
                }
            }
            
            Console.WriteLine("DataTime: " + DateTime.Now);
        }
    }
}
