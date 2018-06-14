using System.Threading.Tasks;
using DevTask.Services.Http.Airports;
using DevTask.Services.Http.Model.Airports;
using DevTask.Services.Storage;
using DevTask.Services.Storage.Map;
using DevTask.Services.Storage.Model;

namespace DevTask.AirportsWorker
{
    public class AirportsTask : IWorkerTask
    {
        protected IAirportsRepository AirportsRepository { get; set; }
        protected IAirportsHttpService AirportsHttpService { get; set; }
        protected IMapperFactory MapperFactory { get; set; }

        public Task Execute()
        {
            return AirportsHttpService.Get()
                .ContinueWith(x => AirportsRepository.Put(
                                        MapperFactory.ResolveMapper<AirportsJsonGetResponse, AirportsRepositoryItem>()
                                            .Map(x.Result)));
        }
    }
}