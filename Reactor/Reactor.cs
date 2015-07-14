using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDojo.Reactor
{
    public class Reactor : IDisposable
    {
        private static Delegate _handler;
        private static Queue<ReactorItem> _queue;

        public ReactorInfo Invoke(Action<object> callback, params object[] parameters)
        {
            ReactorItem item = new ReactorItem(callback, parameters);
            lock(_queue)
            {
                _queue.Enqueue(item);
                return new ReactorInfo() { ItemsInQueue = _queue.Count };
            }
        }

        private void DoPipeline()
        {
            ReactorItem item = null;
            while (_queue != null)
            {
                lock(_queue)
                {
                    if (_queue.Count > 0)
                    {
                        item = _queue.Dequeue();
                    }
                    else
                    {
                        item = null;
                    }
                }

                if (item != null)
                {
                    object result = null;
                    lock(_handler)
                    {
                        result = _handler.DynamicInvoke(item.Parameters);
                    }

                    item.Callback(result);
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Reactor(Action handler)
        {
            _handler = handler;
            _queue = new Queue<ReactorItem>();
            Task pipeline = Task.Factory.StartNew(DoPipeline);
        }

        public class ReactorItem
        {
            public Action<object> Callback { get; private set; }
            public object[] Parameters { get; private set; }

            public ReactorItem(Action<object> callback, params object[] parameters)
            {
                Callback = callback;
                Parameters = parameters;
            }
        }

        public class ReactorInfo
        {
            public int ItemsInQueue { get; set; }

            public ReactorInfo()
            { }
        }
    }
}


