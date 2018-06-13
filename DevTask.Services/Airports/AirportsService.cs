using DevTask.Services.Airports.Settings;
using DevTask.Services.Http.Airports;

namespace DevTask.Services.Airports
{
    public class AirportsService
    {
        protected IAirportsHttpGetService AirportsHttpGetService { get; set; }
        protected IAirportsServiceSettings Settings { get; set; }

        public AirportsService(IAirportsServiceSettings settings, IAirportsHttpGetService airportsHttpGetService)
        {
            AirportsHttpGetService = airportsHttpGetService;
            Settings = settings;
        }
    }
}