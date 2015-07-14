using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using CodeDojo.Reactor;

namespace ReactorTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Reactor reactor = new Reactor(delegate
            {
                Console.WriteLine($"Reactor thread says: Hello, world!");
            });

            for (int i = 1; i <= 10; i++)
            {
                Thread thread = new Thread(new ThreadStart(delegate
                {
                    while (true)
                    {
                        Console.WriteLine($"Invoking from invoker thread { Thread.CurrentThread.Name }.");
                        Reactor.ReactorInfo info = reactor.Invoke(Callback, null);
                        Console.WriteLine($"There { (info.ItemsInQueue == 1 ? "is" : "are") } { info.ItemsInQueue.ToString() } item{ (info.ItemsInQueue == 1 ? "" : "s") } in the queue to execute.");
                        Thread.Sleep(30000);
                    }
                }));
                thread.Name = i.ToString();
                thread.Start();
            }

            while (true) ;
        }

        private static void Callback(object result)
        {
            Console.WriteLine($"Callback to thread { Thread.CurrentThread.Name } => { result?.ToString() ?? "(null)" }.");
        }
    }
}
