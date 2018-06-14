namespace DevTask.Services.Airports.Settings
{
    public class AirportsServiceSettings : IAirportsServiceSettings
    {
        public string GetUrl { get; set; }
    }

    public interface IAirportsServiceSettings
    {
        string GetUrl { get; set; }
    }
}