
using System.Collections.ObjectModel;

namespace Zadania;

public partial class Zadanie24_3 : ContentPage
{
    int fileCount = 0;
    
        public ObservableCollection<string> MojePliki { get; set; } = new();

	public Zadanie24_3()
	{
		InitializeComponent();
        Przegladarka.ItemsSource = MojePliki;
        BindingContext = new Binding();
        LoadFiles();

    }

	private async void LoadFiles()
	{
        try
        {
            MojePliki.Clear();
            string katalog = FileSystem.Current.AppDataDirectory;
            string[] pliki = Directory.GetFiles(katalog);
            foreach (string plik in pliki)
            {
                string name = Path.GetFileName(plik);
                long rozmiar = new FileInfo(plik).Length;
                string rozmiarTekst = rozmiar < 1024
                            ? $"{rozmiar} B"
                            : $"{rozmiar / 1024.0:F1} KB";
                MojePliki.Add(Path.GetFileName($" {plik} {rozmiarTekst}"));
                fileCount ++;
                
            }
        } 
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
	async void OnClickedFile(object sender, EventArgs e)
	{
        try 
        {
                string sciezka = FileSystem.Current.AppDataDirectory;
                using var czytnik = new StreamReader(sciezka);
                string tresc = await czytnik.ReadToEndAsync();
                await DisplayAlert("Zawartosc", tresc, "OK");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}