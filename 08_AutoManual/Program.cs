using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08_AutoManual
{
    class Program
    {
        static ManualResetEvent manual01;
        static AutoResetEvent autoReset01; // Automaticamente utiliza o .Reset()
        static void Main(string[] args)
        {
            manual01 = new ManualResetEvent(false);
            autoReset01 = new AutoResetEvent(false);

            //Thread t1 = new Thread(Executa01);
            //t1.Start();

            Thread t2 = new Thread(Executa02);
            t2.Start();

            Thread.Sleep(5000);
            manual01.Set(); //2 - Libera as proximas mensagens
            manual01.Reset(); // 3 - Reseta da mesma forma que foi instanciado ManualResetEvent(false);

            autoReset01.Set();

            // Liberando o segundo .WaitOne() de Executa01
            Thread.Sleep(5000);
            manual01.Set();
            manual01.Reset();

            autoReset01.Set();

            Console.ReadKey();
        }

        static void Executa01()
        {
            Console.WriteLine("01 - Iniciado Executa01");
            manual01.WaitOne(); // 1 - Espera até houver a chamado no .Set()
            Console.WriteLine("02 - Em Execução 01 Executa01");
            Console.WriteLine("03 - Em Execução 02 Executa01");
            manual01.WaitOne(); // 4 - Com o .Reset() , poderá esperar novamente até ser liberado
            Console.WriteLine("04 - Finalizado 01 Executa01");
        }
        static void Executa02()
        {
            Console.WriteLine("01 - Iniciado Executa02");
            autoReset01.WaitOne();
            Console.WriteLine("02 - Em Execução 01 Executa02");
            autoReset01.WaitOne();
            Console.WriteLine("03 - Em Execução 02 Executa02");
            Console.WriteLine("04 - Finalizado 01 Executa02");
        }
    }
}
