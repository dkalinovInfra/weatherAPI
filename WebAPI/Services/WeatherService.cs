using WebAPI.Data;

namespace WebAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new string[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] Cities = new string[]
        {
            "New York",
            "Los Angeles",
            "Chicago",
            "Houston",
            "Phoenix",
            "Philadelphia",
            "San Antonio",
            "San Diego",
            "Dallas",
            "San Jose",
            "Austin",
            "Jacksonville",
            "San Francisco",
            "Columbus",
            "Fort Worth",
            "Indianapolis",
            "Charlotte",
            "Seattle",
            "Denver",
            "Washington, D.C."
        };

        private static readonly string[] Regions = new string[]
        {
            "Northeast",
            "Midwest",
            "South",
            "West",
            "New England",
            "Pacific",
            "Mountain",
            "Southwest",
            "Great Lakes",
            "Mid-Atlantic",
            "Southeast",
            "Central",
            "Plains",
            "South Central",
            "Pacific Northwest",
            "Deep South"
        };

        private static readonly string[] StreetNames = new string[]
        {
            "Maple Street",
            "Oak Avenue",
            "Main Street",
            "Elm Road",
            "Cedar Lane",
            "Pine Avenue",
            "Birch Street",
            "Willow Lane",
            "Sycamore Avenue",
            "Cypress Road",
            "Chestnut Street",
            "Spruce Lane",
            "Aspen Avenue",
            "Beech Road",
            "Hickory Street",
            "Magnolia Lane",
            "Poplar Avenue",
            "Walnut Road",
            "Fir Street",
            "Locust Lane"
        };


        private static readonly string[] Icons = new[]
        {
            "https://openweathermap.org/img/wn/01d@2x.png",
            "https://openweathermap.org/img/wn/02d@2x.png",
            "https://openweathermap.org/img/wn/03d@2x.png",
            "https://openweathermap.org/img/wn/04d@2x.png",
            "https://openweathermap.org/img/wn/09d@2x.png",
            "https://openweathermap.org/img/wn/10d@2x.png",
            "https://openweathermap.org/img/wn/11d@2x.png",
            "https://openweathermap.org/img/wn/13d@2x.png",
            "https://openweathermap.org/img/wn/50d@2x.png",
        };

        private static List<WeatherForecast> _forecasts = Enumerable.Range(1, 15).Select(index => new WeatherForecast
        {
            Id = index,
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            TemperatureF = Random.Shared.Next(-30, 75),
            Rating = Random.Shared.Next(0, 6),
            Image = Icons[Random.Shared.Next(Icons.Length)],
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            Addresses = Enumerable.Range(1, Random.Shared.Next(2, 10)).Select( _ =>
                new Address()
                {
                    Street = StreetNames[Random.Shared.Next(StreetNames.Length)],
                    City = new RegionAndCity()
                    {
                        Region = Regions[Random.Shared.Next(Regions.Length)],
                        City = Cities[Random.Shared.Next(Cities.Length)]
                    }
                }).ToList()
        }).ToList();

        public void Delete(int id)
        {
            _forecasts = _forecasts.Where(f => f.Id != id).ToList();
        }

        public WeatherForecast? Get(int id)
        {
            return _forecasts.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return _forecasts;
        }

        public IEnumerable<WeatherSummary> GetAllSummaries()
        {
            return Summaries.Select((s, i) => new WeatherSummary() { Id = i, Name = s });
        }

        public WeatherForecast? Upsert(WeatherForecast newForecast)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == newForecast.Id);
            if (forecast == null)
            {
                newForecast.Id = _forecasts.Max(f => f.Id) + 1;
                _forecasts.Add(newForecast);
            }
            else
            {
                forecast.TemperatureC = newForecast.TemperatureC;
                forecast.TemperatureF = newForecast.TemperatureF;
                forecast.Rating = newForecast.Rating;
                forecast.Summary = newForecast.Summary;
                forecast.Date = newForecast.Date;
            }

            return forecast;
        }
    }
}