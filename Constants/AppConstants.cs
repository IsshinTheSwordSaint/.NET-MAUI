using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania.Constants;
public static class AppConstants
{
    public const string NbpRateUrl =
        "https://api.nbp.pl/api/exchangerates/rates/a/{0}/?format=json";
    public static readonly string WeatherCurrentParams =
         "temperature_2m,wind_speed_10m";
    public static readonly string WeatherBaseUrl =
    "https://api.open-meteo.com/v1/forecast";
}
