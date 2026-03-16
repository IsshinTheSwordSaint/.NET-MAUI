namespace Zadania;

public partial class Zadanie20_3 : ContentPage
{
	public Zadanie20_3()
    {
        InitializeComponent();
    }
    Image image = new Image
    {
        Source = new UriImageSource
        {
            Uri = new Uri("https://yt3.ggpht.com/2ahehHxBpt7jgSTdmTRvjo8uhplueTATwBK7Yqikgj88f4yOeGUztGtG4EGfUulwy14QP4yIf3hgL4o=s640-c-fcrop64=1,00002705ffffd8fa-rw-nd-v1"),
            CacheValidity = new TimeSpan(7, 0, 0, 0)
        }
    };
    void changeMainImgAspect(object sender, EventArgs e)
    {
        if (mainImage.Aspect == Aspect.AspectFit)
        {
            mainImage.Aspect = Aspect.AspectFill;
        }
        else if (mainImage.Aspect == Aspect.AspectFill)
        {
            mainImage.Aspect = Aspect.Fill;
        }
        else if (mainImage.Aspect == Aspect.Fill)
        {
            mainImage.Aspect = Aspect.AspectFit;
        }

        aspectLabel.Text = "Aktualny tryb wyœwietlania to " + mainImage.Aspect.ToString();
    }
}