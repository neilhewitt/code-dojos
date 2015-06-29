using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThrottleMatic;

namespace Throttler.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool wasQueued = false;
            ThrottleMatic.Throttler throttler = new ThrottleMatic.Throttler();
            throttler.Throttle(() => Console.WriteLine(nameof(SecondCallIsQueuedDuringTimeout) + ": Hello, world!"), out wasQueued);
            throttler.Throttle(() => Console.WriteLine(nameof(SecondCallIsQueuedDuringTimeout) + ": Hello again, world!"), out wasQueued);
        }
    }
}
