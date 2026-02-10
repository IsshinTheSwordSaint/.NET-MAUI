using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Zadania;

	public partial class Zadanie18_4 : ContentPage
	{
		public Zadanie18_4()
		{
			BindingContext = new WynikiViewModel();
			InitializeComponent();
		}

    private async void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            NaOsobki.IsVisible = true;
            LiczbaOsob.IsVisible = true;
        }
        else
        {
            NaOsobki.IsVisible = false;
            LiczbaOsob.IsVisible = false;
        }
    }
    private async void Napiwek10(object sender, EventArgs e)
    {
        SliderNapiwek.Value = 10;
    }

    private async void Napiwek15(object sender, EventArgs e)
    {
        SliderNapiwek.Value = 15;
    }

    private async void Napiwek20(object sender, EventArgs e)
    {
        SliderNapiwek.Value = 20;
    }

    public class WynikiViewModel : INotifyPropertyChanged
    {
        private double _Kwota { get; set; } = 0; 
        private double _Napiwek { get; set; } = 15 ;
        private int _LiczbaOsob { get; set; } = 1;

        
        public double Kwota
        {
            get => _Kwota;
            set
            {
                _Kwota = Math.Round(value, 2);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Napiwek));
                OnPropertyChanged(nameof(NaOsobe));
                OnPropertyChanged(nameof(Suma));
                OnPropertyChanged(nameof(LiczbaOsob));
            }
        }
        public double Napiwek
        {
            get => _Napiwek;
            set
            {
                _Napiwek = Math.Round(value / 100, 2) * Kwota;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Suma));
                OnPropertyChanged(nameof(NaOsobe));
                OnPropertyChanged(nameof(LiczbaOsob));
            }
        }
        public double Suma
        {
            get
            {
                if (_Kwota <= 0) return 0;
                return Math.Round((Kwota + Napiwek), 2);
            }
        }
        public int LiczbaOsob
        {
            get => _LiczbaOsob;
            set
            {
                _LiczbaOsob = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Suma));
                OnPropertyChanged(nameof(Napiwek));
                OnPropertyChanged(nameof(NaOsobe));
            }
        }

        public double NaOsobe
        {
            get
            {
                return Math.Round((Suma / LiczbaOsob), 2);
            }
        }
     
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
    
