using DevTask.Services.Airports.Settings;
using DevTask.Services.Http.Airports;
using DevTask.Services.Storage;

namespace DevTask.Services.Airports
{
    public class AirportsService
    {
        protected IAirportsHttpGetService AirportsHttpGetService { get; set; }
        protected IAirportsServiceSettings Settings { get; set; }
        protected IAirportsRepository AirportsRepository { get; set; }

        public AirportsService(IAirportsHttpGetService airportsHttpGetService, IAirportsServiceSettings settings,
            IAirportsRepository airportsRepository)
        {
            AirportsHttpGetService = airportsHttpGetService;
            Settings = settings;
            AirportsRepository = airportsRepository;
        }
    }
}