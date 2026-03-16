using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace Zadania;

public partial class Zadanie20_4 : ContentPage
{
	public Zadanie20_4()
	{
		InitializeComponent();
		BindingContext = new GalleryViewModel();
	}

	// Handler dla TapGestureRecognizer — wyœwietla alert z URL klikniêtego obrazu
	private async void Image_Tapped(object? sender, TappedEventArgs e)
	{
		if (sender is Image img && img.BindingContext is string src)
		{
			await DisplayAlert("Klikniêto obraz", $"Klikniêto obraz: {src}", "OK");
		}
	}
}

public class GalleryViewModel : INotifyPropertyChanged
{
	public ObservableCollection<string> Images { get; } = new();

	public GalleryViewModel()
	{
		Images.Add("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRV2X77BDsDnkdtrBrYJBPOEyiNnAFEtDNIsw&s");
		Images.Add("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRjbwuiqrnz7rMiskjsFNfm-gA0fbECrrBYVA&s");
		Images.Add("https://i0.wp.com/www.wodkanawesela.pl/wp-content/uploads/2020/10/balas-07-kwadratObszar-roboczy-1-100.jpg?fit=1200%2C1200&ssl=1");
		Images.Add("https://sklep.spolemkielce.pl/wp-content/uploads/2020/04/perla_perla-export_piwo-56-procent-butelka-bzw_500ml.png");
        Images.Add("https://delikatesyuchlopcow.pl/userdata/public/gfx/1639/Piwo-Perla-Chmielowa-pusz.-0.5l.png");
        Images.Add("https://spirits.com.pl/wp-content/uploads/2022/12/Bialy-Bocian-Panna-Cotta-z-Malina-1-scaled.jpg");
    }

	public event PropertyChangedEventHandler? PropertyChanged;
	protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}