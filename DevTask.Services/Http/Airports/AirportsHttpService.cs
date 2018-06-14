using DevTask.Services.Http.Abstract;
using DevTask.Services.Http.Model.Airports;

namespace DevTask.Services.Http.Airports
{
    public class AirportsHttpService : HttpService<AirportsJsonGetResponse>
    {
        public AirportsHttpService(string baseUrl, string url, IHttpGetService<AirportsJsonGetResponse> service) : base(
            baseUrl, url, service)
        {
        }

    }

    public interface IAirportsHttpService : IHttpService<AirportsJsonGetResponse>
    {

    }
}