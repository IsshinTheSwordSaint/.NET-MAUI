namespace Zadania;

public partial class SettingsPage : ContentPage

{

    public SettingsPage()

    {

        InitializeComponent();

    }



    private void OnThemeToggled(object sender, ToggledEventArgs e)

    {

        // e.Value = true oznacza ciemny motyw 

        (Application.Current as App)?.ChangeTheme(e.Value);

    }

}