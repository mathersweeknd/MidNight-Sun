using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Clima.Models;

namespace Clima.Services
{
    public class WeatherService
    {
        private readonly string _apiKey;

        public WeatherService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<Weather> GetWeatherAsync(string city)
        {
            using (var client = new HttpClient())
            {
                var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_apiKey}&lang=pt_br";
                var response = await client.GetStringAsync(url);

                var json = JObject.Parse(response);

                return new Weather
                {
                    Cidade = json["name"].ToString(),
                    Temperatura = (double)json["main"]["temp"],
                    Umidade = (int)json["main"]["humidity"],
                    Pressao = (int)json["main"]["pressure"],
                    Descricao = json["weather"][0]["description"].ToString(),
                    DataConsulta = DateTime.Now
                };
            }
        }
    }
}