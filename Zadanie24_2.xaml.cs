namespace Zadania;

public partial class Zadanie24_2 : ContentPage
{
	public Zadanie24_2()
	{
		InitializeComponent();
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
        if (File.Exists(path))
        {
            DziennikLabel.Text = File.ReadAllText(path);
        }
    }

	private async void AddLineClicked(object sender, EventArgs e)
    {
		string path = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
		string tresc = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + Pole.Text + "\n";
        DziennikLabel.Text += tresc;
        await File.WriteAllTextAsync(path, DziennikLabel.Text);
        
    }
    private async void DelLineClicked(object sender, EventArgs e)
    {
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
        File.Delete(path);
        DziennikLabel.Text = string.Empty;
    }

}