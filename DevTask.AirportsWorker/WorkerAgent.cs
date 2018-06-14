using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevTask.AirportsWorker
{
    public class WorkerAgent : IWorkerAgent
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        protected IWorkerTask Task { get; set; }
        protected IWorkerSettings Settings { get; set; }

        protected WorkerAgent(IWorkerTask task)
        {
            Task = task;
        }

        public async Task SheduleAgent(IWorkerSettings settings)
        {
            while (!_tokenSource.Token.IsCancellationRequested)
            {
                await Task.Execute().ContinueWith(x =>
                    System.Threading.Tasks.Task.Delay(TimeSpan.FromMinutes(settings.IntervalMin), _tokenSource.Token));
            }
        }
    }

    public interface IWorkerAgent
    {
        Task SheduleAgent(IWorkerSettings settings);
    }
}