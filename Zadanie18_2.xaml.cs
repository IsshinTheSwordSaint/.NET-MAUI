namespace Zadania;

public partial class Zadanie18_2 : ContentPage
{
	public Zadanie18_2()
	{
		InitializeComponent();
	}
    private async void alert(object sender, EventArgs e)
    {
        bool imienaz = false;
        bool email = false;
        bool temat = false;
        bool wiadomosc = false;

        if (!string.IsNullOrWhiteSpace(ImieNaz.Text))
        {
            imienaz = true;
        }
        if (!string.IsNullOrWhiteSpace(Email.Text))
        {
            email = true; 
        }
        if (!string.IsNullOrWhiteSpace(Temat.Text))
        {
            temat = true;
        }
        if (!string.IsNullOrWhiteSpace(Wiad.Text))
        {
            wiadomosc = true;
        }

   

        if ( imienaz == true && email == true && temat == true && wiadomosc == true)
        {
            await DisplayAlert(
                "Sukces",
                "Wys³ano wiadomoœæ",
                "OK");
        }
        else
        {
            await DisplayAlert(
                "B³¹d",
                "Uzupe³nij wszystkie pola",
                "OK");
        }
    }
}
/*
     ********************************************************************** 
     nazwa funkcji: alert
     opis funkcji: Funkcja sprawdza czy wszystkie pola formularza zosta³y wype³nione,
     a nastepnie wyswietla komunikat
     parametry: object sender, EventArgs e   

     zwracany typ i opis: void - funkcja nie zwraca ¿adnej wartoœci
     autor: Ja    
     ********************************************************************** 
 */

