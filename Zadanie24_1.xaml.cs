namespace Zadania;

public partial class Zadanie24_1 : ContentPage
{
	public Zadanie24_1()
	{
		InitializeComponent();
	}
	private async void OnSaveClicked(object sender, EventArgs e)
	{
		string path = Path.Combine(FileSystem.Current.AppDataDirectory, "moj_plik.txt");
		string tresc = Tekst.Text;

		await File.WriteAllTextAsync(path, tresc);
		await DisplayAlert("Zapisano", "Notatka zosta³a zapisana", "OK");
    }
	private async void OnLoadClicked(object sender, EventArgs e)
	{
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, "moj_plik.txt");
		if (File.Exists(path))
		{
			string tresc = await File.ReadAllTextAsync(path);
			if (string.IsNullOrWhiteSpace(tresc))
			{
				await DisplayAlert("Plik", "Brak zapisanego tekstu w pliku", "OK");
			}
			else
			{
				Miejsce.Text = tresc;
			}
		}
		else
		{
			Miejsce.Text = "Brak zapisanego tekstu";
		}
    }
}