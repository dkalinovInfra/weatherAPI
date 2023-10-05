namespace WebAPI.Data
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }
        public int TemperatureF { get; set; }
        public string? Summary { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public RegionAndCity City { get; set; }
    }

    public class RegionAndCity
    {
        public string City { get; set; }
        public string Region { get; set; }
    }
}