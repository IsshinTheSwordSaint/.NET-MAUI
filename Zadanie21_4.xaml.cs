namespace Zadania;

public partial class Zadanie21_4 : ContentPage
{
	public Zadanie21_4()
	{
		InitializeComponent();
	}
    private void setPriorityPicker(object sender, System.EventArgs e)
    {
        PriorityPicker.IsEnabled = true;
        if (subjectPicker.SelectedIndex == 0)
        {
            PriorityPicker.ItemsSource = new List<string> { "Niski", "Œredni", "Wysoki" };
        }
        else if (subjectPicker.SelectedIndex == 2)
        {
            PriorityPicker.ItemsSource = new List<string> { "Niski", "Œredni" };
        }
        else
        {
            PriorityPicker.IsEnabled = false;
        }
    }
    private void checkIfCorrectAndSend(object sender, System.EventArgs e)
    {

        if (!string.IsNullOrEmpty(NameEntry.Text) && !string.IsNullOrEmpty(EmailEntry.Text) && subjectPicker.SelectedIndex >= 0 && !string.IsNullOrEmpty(MessageEditor.Text))
        {
            if (PriorityPicker.SelectedIndex == 0 && PriorityPicker.SelectedIndex == 2)
            {

                DisplayAlert("Wysy³anie wiadomoœci", $"Wiadomoœæ zosta³a Imiê: {NameEntry.Text}, Email: {EmailEntry.Text}, Wybrany temat: {subjectPicker.Items[subjectPicker.SelectedIndex]},Priorytet: {PriorityPicker.Items[PriorityPicker.SelectedIndex]}, Wiadomoœæ: {MessageEditor.Text} ", "OK");
            }
            else
            {
                DisplayAlert("Wysy³anie wiadomoœci", $"Wiadomoœæ zosta³a Imiê: {NameEntry.Text}, Email: {EmailEntry.Text}, Wybrany temat: {subjectPicker.Items[subjectPicker.SelectedIndex]}, Wiadomoœæ: {MessageEditor.Text} ", "OK");

            }
        }
        else
        {
            DisplayAlert("B³¹d", "Proszê wype³niæ wszystkie pola", "OK");
        }
    }
}

/*
 * Nazwa funkcji: setPriorityPicker
 * opis funkcji: sprawdza jaki jest wybrany temat i ustala dostêpne priorytety do wyboru
 * parametry: sender - obiekt który wywo³a³ funkcjê, e - argumenty zdarzenia
 * zwracany typ i opis: brak
 * 
 * nazwa funkcji: checkIfCorrectAndSend
 * opis funckji: sprawdza czy pola s¹ wype³nione i wypisuje je w alercie, jeœli priorytet jest dostêpny - równie¿ go wypisuje
 *  parametry: sender - obiekt, który wywo³a³ funkcjê, e - argumenty zdarzenia
 *  zwracany typ i opis: brak
 * 
 * 
 */