using System.Collections.Generic;
using System.Threading;

namespace FirstTask
{ 
    public class TaskQueue : ITaskQueue
    {
        private Thread[] ThreadPool { get; }
        private Queue<Method> Tasks;
        
        public TaskQueue(int counter)
        {
            ThreadPool = new Thread[counter];
            Tasks = new Queue<Method>();
            for (var index = 0; index < ThreadPool.Length; index++)
            {
                ThreadPool[index] = Thread.CurrentThread;
            }
        }

        public void EnqueueTask(Method taskDelegate)
        {
            Tasks.Enqueue(taskDelegate);
        }
        
        public void DequeueTask()
        {
            for (var index = 0; index < ThreadPool.Length; index++)
            {
                if ((ThreadPool[index].ThreadState & ThreadState.Aborted) == 0)
                {
                    ThreadPool[index] = new Thread(new ThreadStart(Tasks.Dequeue()));
                    ThreadPool[index].Start();
                    break;
                }
            }
        }

    }
}