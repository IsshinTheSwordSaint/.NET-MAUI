using System;
using Microsoft.Maui.Controls;

namespace Zadania;

public partial class Zadanie20_2 : ContentPage
{
	public Zadanie20_2()
	{
		InitializeComponent();
		var layout = new VerticalStackLayout();

		var localImage = new Image
		{
			Aspect = Aspect.AspectFit,
			HorizontalOptions = LayoutOptions.Center,
			Source = "dotnet_bot.png",
			HeightRequest = 200
		};
		layout.Children.Add(localImage);

		var remoteImage = new Image
		{
			Aspect = Aspect.AspectFit,
			HorizontalOptions = LayoutOptions.Center,
			HeightRequest = 300,
			Source = new UriImageSource
			{
				Uri = new Uri("https://yt3.ggpht.com/VckpbT6m8z08D39Ejx1grwr6M3l81pGA0twcLCkn9gKGEl-zEvv_5C4FP_-RoJDUERTprx3Fc_Ub=s640-c-fcrop64=1,000029eaffffd615-rw-nd-v1"),
				CachingEnabled = true,
				CacheValidity = TimeSpan.FromDays(7)
			}
		};
		layout.Children.Add(remoteImage);
		Content = layout;
	}
}