using Microsoft.Maui.Animations;
using Microsoft.Maui.ApplicationModel.Communication;
using System;

namespace Zadania;

public partial class Zadanie21_2 : ContentPage
{
	public Zadanie21_2()
	{
		InitializeComponent();
	}
    private void checkIfLogged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(emailEntry.Text) && !string.IsNullOrEmpty(passwordEntry.Text))
        {
            loginButton.IsVisible = true;
        }
        else
        {
            loginButton.IsVisible = false;
        }

    }
    private void onSend(object? sender, EventArgs e)
    {
        if (true)
        {
            DisplayAlert("Logowanie", "Zalogowa³eœ siê", "OK");
        }
    }
}

/*  nazwa funkcji: checkIfLogged
 * opis funkcji: sprawdza czy email i has³o jest wype³nione i pokazuje lub ukrywa przycisk logowania
 * parametry: sender - obiekt, który wywo³a³ funkcjê, e - argumenty zdarzenia
 * zwracany typ i opis: brak
 *
 * nawa funkcji: onSend
 * opis funkcji : wyœwietla alert z info o zalogowaniu
 * parametry: sender - obiekt, który wywo³a³ funkcjê, e - argumenty zdarzenia
 * zwracany typ i opis: brak
 */