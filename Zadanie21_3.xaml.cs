namespace Zadania;

public partial class Zadanie21_3 : ContentPage
{
	public Zadanie21_3()
	{
		InitializeComponent();
	}
    private void isCheckBoxChecked(object? sender, EventArgs e)
    {
        if (AcceptCheckBox.IsChecked)
        {
            RegisterButton.IsVisible = true;
        }
        else
        {
            RegisterButton.IsVisible = false;
        }
    }
    private void register(object? sender, EventArgs e)
    {
        DisplayAlert("Rejestracja", "Zarejestrowa³eœ siê", "OK");
    }
}

/*
 * 
 * nazwa funckji: ischeckBoxChecked
 * opis funkcji: sprawdza czy checkbox jest zaznaczony, jeœli tak - pokazuje przycisk rejestracji, jeœli nie - ukrywa
 * parametry: sender - obiekt, który wywo³a³ funkcjê, e - argumenty zdarzenia
 * zwracany typ i opis: brak
 * 
 * nazwa funkcji: register
 * opis funkcji: wyœwietla alert z info o rejestracji
 * parametry: sender - obiekt, który wywo³a³ funkcjê, e - argumenty zdarzenia
 * zwracany typ i opis: brak
 * 
 * 
 */