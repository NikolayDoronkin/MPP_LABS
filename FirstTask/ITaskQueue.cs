namespace FirstTask
{
    public interface ITaskQueue
    {
        void DequeueTask();
        void EnqueueTask(Method taskDelegate);
    }
}