using System.Threading;

namespace ThirdTask
{
    public class Mutex : IMutex
    {
        private int _curId = -1;

        public void Lock()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            while (Interlocked.CompareExchange(ref this._curId,
                id, -1) != -1)
            {
                Thread.Sleep(10);
            }
        }

        public void Unlock()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            Interlocked.CompareExchange(ref this._curId,
                -1, id);
        }
    }
}