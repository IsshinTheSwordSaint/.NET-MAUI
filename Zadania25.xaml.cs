using Zadania.Constants;
using Zadania.Models;
using Zadania.Services;
using System.Diagnostics;
using static Zadania.Models.CurrencyModels;

namespace Zadania;

public partial class Zadania25 : ContentPage
{
    private readonly WeatherService _weatherService;
    private readonly CurrencyService _currencyService;
    public Zadania25()
    {
        InitializeComponent();
        _weatherService = new WeatherService();
        _currencyService = new CurrencyService();
    }
    private async void OnGetWeatherClicked(object sender, EventArgs e)
    {
        try
        {

            WeatherResponse pogoda = await _weatherService.GetWeatherAsync(52.23, 21.01);

            if (pogoda?.Current != null)
            {

                LabelTemperature.Text = $"{pogoda.Current.Temperature:F1} °C";
                LabelWind.Text = $"{pogoda.Current.WindSpeed:F1} km/h";
                LabelWeatherTime.Text = pogoda.Current.Time ?? "—";

                LabelWeatherError.IsVisible = false;

                Debug.WriteLine($"Pogoda OK: {pogoda.Current.Temperature}°C, {pogoda.Current.WindSpeed} km/h");
            }
            else
            {
                ShowWeatherError("Nie udało się pobrać danych pogodowych.\nSprawdź połączenie z internetem.");
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine($"OnGetWeatherClicked wyjątek: {ex.Message}");
        }

    }

    private async void OnGetCurrencyClicked(object sender, EventArgs e)
    {
        try
        {

            var codes = new List<string> { "usd", "eur", "gbp", "chf" };

            var tasks = codes.Select(code => _currencyService.GetExchangeRateAsync(code)).ToList();

            await Task.WhenAll(tasks);


            NbpRateResponse usd = tasks[0].Result;
            NbpRateResponse eur = tasks[1].Result;
            NbpRateResponse gbp = tasks[2].Result;
            NbpRateResponse chf = tasks[3].Result;

            UpdateCurrencyLabel(LabelUSD, LabelUSDDate, usd);
            UpdateCurrencyLabel(LabelEUR, LabelEURDate, eur);
            UpdateCurrencyLabel(LabelGBP, LabelGBPDate, gbp);
            UpdateCurrencyLabel(LabelCHF, LabelCHFDate, chf);

            LabelCurrencyError.IsVisible = false;

            Debug.WriteLine($"Waluty OK: USD={usd?.Rates?[0]?.Mid}, EUR={eur?.Rates?[0]?.Mid}");
        }
        catch (Exception ex)
        {
            ShowCurrencyError($"Błąd: {ex.Message}");
            Debug.WriteLine($"OnGetCurrencyClicked wyjątek: {ex.Message}");
        }
        finally
        {

        }
    }
    private void UpdateCurrencyLabel(Label valueLabel, Label dateLabel, NbpRateResponse rate)
    {
        if (rate?.Rates?.Count > 0)
        {
            valueLabel.Text = $"{rate.Rates[0].Mid:F4} PLN";
            dateLabel.Text = rate.Rates[0].EffectiveDate;
        }
        else
        {
            valueLabel.Text = "brak danych";
            dateLabel.Text = "—";
        }
    }
    private void ShowCurrencyError(string message)
    {
        LabelCurrencyError.Text = message;
        LabelCurrencyError.IsVisible = true;
    }
    private void ShowWeatherError(string message)
    {
        LabelWeatherError.Text = message;
        LabelWeatherError.IsVisible = true;
    }
}
