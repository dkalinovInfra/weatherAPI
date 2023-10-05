using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherSummaryController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        private IWeatherService weatherService;



        public WeatherSummaryController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            this.weatherService = weatherService;
        }


        [HttpGet]
        public IEnumerable<WeatherSummary> GetAll()
        {
            return weatherService.GetAllSummaries();
        }
    }
}
