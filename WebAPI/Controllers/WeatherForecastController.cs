using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private IWeatherService weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return weatherService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<WeatherForecast> Get(int id)
        {
            var forecast = weatherService.Get(id);
            if (forecast == null)
            {
                return NotFound();
            }

            return forecast;
        }
        
        [HttpGet]
        [Route("GetString")]
        public ActionResult<WeatherForecast> GetString(string id)
        {
            var forecast = weatherService.Get(int.Parse(id));
            if (forecast == null)
            {
                return NotFound();
            }

            return forecast;
        }

        [HttpGet]
        [Route("GetWithBody")]
        public ActionResult<WeatherForecast> Update(WeatherForecast weather)
        {
            var forecast = weatherService.Upsert(weather);
            return Ok(forecast);
        }

        [HttpPost(Name = "UpdateWeatherForecast")]
        public ActionResult<WeatherForecast> Post(WeatherForecast weather)
        {
            var forecast = weatherService.Upsert(weather);
            return Ok(forecast);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<WeatherForecast> Delete(int id)
        {
            weatherService.Delete(id);
            return Ok();
        }
    }
}