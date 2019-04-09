using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_ThreadId
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread t1 = new Thread(ThreadRepeticao);
                t1.Start(i);
            }

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
