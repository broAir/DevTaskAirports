using System.Threading.Tasks;

namespace DevTask.AirportsWorker
{
    public interface IWorkerTask<TResult>
    {
        Task<TResult> Execute();
    }
    
    public interface IWorkerTask
    {
        Task Execute();
    }
}