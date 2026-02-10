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

/*
 ************************************************************************
  nazwa funkcji: Switch_Toggled
  opis funkcji: zbiera informacje czy switch jest wlaczony i jesli tak to 
    ujawnia wybrane elementy
  parametry: object sender, EventArgs e
  
  zwracany typ i opis: void - funkcja nie zwraca ¿adnej wartoœci
  autor: Ja
 ************************************************************************
 *  
 *  ************************************************************************
  nazwa funkcji: Napiwek10
  opis funkcji: Ustawia wartoœæ suwaka napiwku na 10%
  parametry: object sender, EventArgs e
  zwracany typ i opis: void - funkcja nie zwraca ¿adnej wartoœci
  autor: Ja
 ************************************************************************
 
  ************************************************************************
  nazwa funkcji: Napiwek15
  opis funkcji: Ustawia wartoœæ suwaka napiwku na 15%
  parametry: object sender, EventArgs e
  zwracany typ i opis: void - funkcja nie zwraca ¿adnej wartoœci
  autor: Ja
 ************************************************************************
 *
 *************************************************************************
  nazwa funkcji: Napiwek20
  opis funkcji: Ustawia wartoœæ suwaka napiwku na 20%
  parametry: object sender, EventArgs e
  zwracany typ i opis: void - funkcja nie zwraca ¿adnej wartoœci
  autor: Ja
 ************************************************************************
 
 */

/*
 ************************************************************************
  nazwa funkcji: Kwota
  opis funkcji: W³aœciwoœæ przechowuj¹ca kwotê rachunku (w z³). Setter zaokr¹gla wartoœæ do 2 miejsc
               i powiadamia widok o zmianach powi¹zanych w³aœciwoœci.
  parametry: double value - nowa wartoœæ kwoty
  zwracany typ i opis: double - aktualna wartoœæ kwoty
  autor: Ja
 ************************************************************************
 */

/*
 ************************************************************************
  nazwa funkcji: Napiwek
  opis funkcji: W³aœciwoœæ reprezentuj¹ca napiwek. Setter oczekuje wartoœci procentowej (np. 15 dla 15%)
               i oblicza kwotê napiwku wzglêdem aktualnej `Kwota`, zaokr¹glaj¹c wynik.
  parametry: double value - procent napiwku
  zwracany typ i opis: double - obliczona kwota napiwku (w z³)
  autor: Ja
 ************************************************************************
 */

/*
 ************************************************************************
  nazwa funkcji: Suma
  opis funkcji: W³aœciwoœæ tylko do odczytu zwracaj¹ca ca³kowit¹ sumê do zap³aty (Kwota + Napiwek).
               Zwraca 0, gdy Kwota jest mniejsza lub równa 0.
  parametry: brak
  zwracany typ i opis: double - obliczona suma (w z³)
  autor: Ja
 ************************************************************************
 */

/*
 ************************************************************************
  nazwa funkcji: LiczbaOsob
  opis funkcji: W³aœciwoœæ okreœlaj¹ca liczbê osób, na które dzielony jest rachunek.
               Setter powiadamia widok o zmianach zale¿nych w³aœciwoœci.
  parametry: int value - liczba osób
  zwracany typ i opis: int - aktualna liczba osób
  autor: Ja
 ************************************************************************
 */

/*
 ************************************************************************
  nazwa funkcji: NaOsobe
  opis funkcji: W³aœciwoœæ tylko do odczytu zwracaj¹ca kwotê przypadaj¹c¹ na jedn¹ osobê
               (Suma / LiczbaOsob), zaokr¹glon¹ do 2 miejsc.
  parametry: brak
  zwracany typ i opis: double - kwota na osobê (w z³)
  autor: Ja
 ************************************************************************
 */