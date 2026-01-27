namespace Zadania;

public partial class Zadanie17_4 : ContentPage
{
    private int imageCount;
    public Zadanie17_4()
	{
        InitializeComponent();
        int imageCount = photosWrap.Children.OfType<Grid>().SelectMany(g => g.Children.OfType<Image>()).Count();
        photoCountLabel.Text = $"Obecna iloœæ zdjêæ: {imageCount}";

    }
    private async void alert(object sender, EventArgs e)
    {
        var thumbnai = sender as Image;

        if (thumbnai != null)
        {
            await DisplayAlert(
                "Miniatura",
                "Kliknieto w miniature w galerii",
                "OK");
        }
    }
}