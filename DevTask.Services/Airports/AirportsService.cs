using System.Collections.Generic;
using System.Threading.Tasks;
using DevTask.Services.Airports.Model;
using DevTask.Services.Airports.Settings;
using DevTask.Services.Http.Airports;
using DevTask.Services.Http.Model.Airports;
using DevTask.Services.Storage;
using DevTask.Services.Storage.Map;
using DevTask.Services.Storage.Model;

namespace DevTask.Services.Airports
{
    public class AirportsService : IAirportsService
    {
        protected IAirportsHttpService AirportsHttpService { get; set; }
        protected IAirportsServiceSettings Settings { get; set; }
        protected IAirportsRepository AirportsRepository { get; set; }
        protected IMapperFactory MapperFactory { get; set; }

        public AirportsService(IAirportsHttpService airportsHttpService, IAirportsServiceSettings settings,
            IAirportsRepository airportsRepository, IMapperFactory mapperFactory)
        {
            AirportsHttpService = airportsHttpService;
            Settings = settings;
            AirportsRepository = airportsRepository;
            MapperFactory = mapperFactory;
        }

        public async Task<AirportServiceResponse> GetAirports(bool bypassCache = false)
        {
            AirportServiceResponse response;

            if (bypassCache)
            {
                var httpResponseObject = await AirportsHttpService.Get();
                response = MapperFactory.ResolveMapper<AirportsJsonGetResponse, AirportServiceResponse>()
                    .Map(httpResponseObject);
                response.FromCache = false;
                return response;
            }

            var cachedAirports = AirportsRepository.Get();
            response = MapperFactory.ResolveMapper<IEnumerable<IAirportsRepositoryItem>, AirportServiceResponse>()
                .Map(cachedAirports);
            response.FromCache = true;
            return response;
        }
    }

    public interface IAirportsService
    {
        Task<AirportServiceResponse> GetAirports(bool bypassCache = false);
    }
}