namespace Zadania;

public partial class Zadanie18_3 : ContentPage
{
	public Zadanie18_3()
	{
		InitializeComponent();
	}
	private async void alert(object sender, EventArgs e)
	{
		var wlaczoneuslugi = new List<string>();

        var PowPush = PowiadomieniaPush.IsToggled;
		var DarkMode = TrybCiemny.IsToggled;
		var Font = Math.Round(Czcionka.Value, 0);

		var DaneAnal = UdostepnianieDanych.IsChecked;
		var Reklama = Reklamy.IsChecked;

		if (PowPush)
		{
			wlaczoneuslugi.Add("Powiadomienia Push");
        }
		if (DarkMode)
        {
			wlaczoneuslugi.Add("Tryb Ciemny");
        }
		wlaczoneuslugi.Add($"Rozmiar czcionki: {Font}");
		if (DaneAnal)
        {
			wlaczoneuslugi.Add("Udostêpnianie danych analitycznych");
        }
		if (Reklama)
        {
			wlaczoneuslugi.Add("Spersonalizowane reklamy");
        }

		string wlaczoneuslugiStr = string.Join(", ", wlaczoneuslugi);
        await DisplayAlert(
			"Ustawienia zapisane",
			"Twoje ustawienia: " +
			wlaczoneuslugiStr,
			"OK");


    }
}
/*
 ************************************************************************
  nazwa funkcji: alert
  opis funkcji: Funkcja zbiera informacje o zaznaczonych ustawieniach,
  a nastêpnie wyœwietla je w oknie alertu
  parametry: object sender, EventArgs e
  
  zwracany typ i opis: void - funkcja nie zwraca ¿adnej wartoœci
  autor: Ja
 ************************************************************************
 * 
 */