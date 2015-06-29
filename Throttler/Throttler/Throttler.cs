using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace ThrottleMatic
{
    public class Throttler
    {
        private int _callDelayInSeconds;
        private Timer _timer;
        private bool _started;
        private object _padlock = new object();
        private IList<Action> _queuedActions;

        public void Throttle(Action action, out bool wasQueued)
        {
            if (!_started)
            {
                action();
                _started = true;
                wasQueued = false;

                _timer.Interval = _callDelayInSeconds * 1000;
                _timer.Elapsed += TimerCallback;
                _timer.Enabled = true;
                _timer.Start();
            }
            else
            {
                _queuedActions.Add(action);
                wasQueued = true;
                //throw new Exception("Your call cannot execute as the throttle limit has not been reached.");
            }
        }

        private void TimerCallback(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            _started = false;
            foreach (Action action in _queuedActions)
            {
                action();
            }
        } 

        public Throttler(int callDelayInSeconds = 5)
        {
            _timer = new Timer();
            _queuedActions = new List<Action>();
            _callDelayInSeconds = callDelayInSeconds;
        }
    }
}
