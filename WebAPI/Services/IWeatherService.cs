using WebAPI.Data;

namespace WebAPI.Services
{
    public interface IWeatherService
    {
        public WeatherForecast? Get(int id);
        public IEnumerable<WeatherForecast> GetAll();

        public IEnumerable<WeatherSummary> GetAllSummaries();
        public WeatherForecast? Upsert(WeatherForecast forecast);
        public void Delete(int id);
    }
}
