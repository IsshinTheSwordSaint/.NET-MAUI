using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Zadania.Models;
    public class WeatherResponse
    {

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public CurrentWeather Current { get; set; }
    }

    public class CurrentWeather
    {

        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }


        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed { get; set; }
        public string Time { get; set; }
    }