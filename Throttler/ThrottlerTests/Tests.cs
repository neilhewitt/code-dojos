using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThrottleMatic;

namespace ThrottlerTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CanExecuteSingleCall()
        {
            Throttler throttler = new Throttler();
            bool wasQueued = false;
            try
            {
                Assert.DoesNotThrow(new TestDelegate(() => throttler.Throttle(() => Console.WriteLine(nameof(CanExecuteSingleCall) + ": Hello, world!"), out wasQueued)));
            }
            catch (Exception ex)
            {

            }
        }

        [Test]
        public void SecondCallIsQueuedDuringTimeout()
        {
            bool wasQueued = false;
            Throttler throttler = new Throttler();
            throttler.Throttle(() => Console.WriteLine(nameof(SecondCallIsQueuedDuringTimeout) + ": Hello, world!"), out wasQueued);
            Assert.IsFalse(wasQueued);
            throttler.Throttle(() => Console.WriteLine(nameof(SecondCallIsQueuedDuringTimeout) + ": Hello again, world!"), out wasQueued);
            Assert.IsTrue(wasQueued);
            Thread.Sleep(15000);
        }

        [Test]
        public void CanExecuteMultipleCallsAfterTimeout()
        {
            Throttler throttler = new Throttler();
            bool wasQueued = false;
            throttler.Throttle(() => Console.WriteLine(nameof(CanExecuteMultipleCallsAfterTimeout) + ": Hello, world!"), out wasQueued);
            Assert.IsFalse(wasQueued);
            Thread.Sleep(6000);
            throttler.Throttle(() => Console.WriteLine(nameof(CanExecuteMultipleCallsAfterTimeout) + ": Hello again, world!"), out wasQueued);
            Assert.IsFalse(wasQueued);
        }
    }
}
