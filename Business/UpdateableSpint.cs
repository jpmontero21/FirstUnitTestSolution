using System;
using System.Threading;

namespace Business
{
    public class UpdateableSpint
    {
        private readonly object lockObj = new object();
        private bool shouldWait = true;
        private long executionStartTime;

        public UpdateableSpint()
        {
        }

        public bool Wait(TimeSpan timeSpan, int spinDuration = 0)
        {
            this.UpdateTimeOut();
            while (true)
            {
                lock (lockObj)
                {
                    if (!shouldWait)
                        return true;
                    if (DateTime.UtcNow.Ticks - executionStartTime > timeSpan.Ticks)
                        return false;

                }
                Thread.Sleep(spinDuration);
            }
            
        }

        public void Set()
        {
            lock(lockObj)
            {
                shouldWait = false;
            }
        }

        public void UpdateTimeOut()
        {
            lock (lockObj)
            {
                executionStartTime = DateTime.UtcNow.Ticks;
            }
        }
    }
}
