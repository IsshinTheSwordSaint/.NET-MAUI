using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zadania.Constants;
using Zadania.Models;

namespace Zadania.Services
{
    public class WeatherService
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public WeatherService()
        {
            _client = new HttpClient();
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<WeatherResponse> GetWeatherAsync(double latitude, double longitude)
        {

            string url = $"{AppConstants.WeatherBaseUrl}" +
                         $"?latitude={latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}" +
                         $"&longitude={longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}" +
                         $"&current={AppConstants.WeatherCurrentParams}";

            Uri uri = new Uri(url);

            try
            {

                HttpResponseMessage response = await _client.GetAsync(uri);


                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();


                    return JsonSerializer.Deserialize<WeatherResponse>(content, _options);
                }
                else
                {
                    Debug.WriteLine($"Open-Meteo błąd HTTP: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {

                Debug.WriteLine($"Błąd sieci (WeatherService): {ex.Message}");
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Nieznany błąd (WeatherService): {ex.Message}");
            }

            return null;
        }
    }
}
