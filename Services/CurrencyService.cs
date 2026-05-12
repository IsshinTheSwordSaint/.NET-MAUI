using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zadania.Constants;
using static Zadania.Models.CurrencyModels;

namespace Zadania.Services
{
    public class CurrencyService
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public CurrencyService()
        {
            _client = new HttpClient();
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<NbpRateResponse> GetExchangeRateAsync(string currencyCode)
        {
            Uri uri = new Uri(string.Format(AppConstants.NbpRateUrl, currencyCode.ToLower()));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<NbpRateResponse>(content, _options);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Debug.WriteLine($"NBP: waluta '{currencyCode}' nie znaleziona (404).");
                }
                else
                {
                    Debug.WriteLine($"NBP błąd HTTP: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Błąd sieci (CurrencyService): {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Nieznany błąd (CurrencyService): {ex.Message}");
            }

            return null;
        }
        public async Task<double> GetRateAsync(string currencyCode)
        {
            NbpRateResponse result = await GetExchangeRateAsync(currencyCode);
            return result?.Rates?[0]?.Mid ?? 0;
        }
        public async Task<Dictionary<string, double>> GetMultipleRatesAsync(List<string> codes)
        {
            var results = new Dictionary<string, double>();

            foreach (string code in codes)
            {
                double rate = await GetRateAsync(code);
                results[code.ToUpper()] = rate;
            }
            return results;
        }
    }
}
