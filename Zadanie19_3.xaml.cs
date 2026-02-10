using System.ComponentModel;

namespace Zadania;

public partial class Zadanie19_3 : ContentPage
{
	public Zadanie19_3()
	{
        InitializeComponent();
        _viewModel = new OrderViewModel();
        BindingContext = _viewModel;
    }
    private OrderViewModel _viewModel;

    public class OrderViewModel : INotifyPropertyChanged
    {
        private string _selectedPizza;
        public string selectedPizza
        {
            get => _selectedPizza;
            set
            {
                _selectedPizza = value;
                OnPropertyChanged(nameof(selectedPizza));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    private void onOptionChanged(object sender, EventArgs e)
    {
        int pricePerPizza = 0;
        int quantity = (int)quantityStepper.Value;
        if (_viewModel.selectedPizza == "25 cm")
        {
            pricePerPizza = 20;
        }
        else if (_viewModel.selectedPizza == "32 cm")
        {
            pricePerPizza = 28;
        }
        else if (_viewModel.selectedPizza == "45 cm")
        {
            pricePerPizza = 38;
        }
        if (ZSerem.IsChecked)
        {
            pricePerPizza += 5;
        }
        int totalPrice = pricePerPizza * quantity;
        resultLabel.Text = $"Cena: {totalPrice} zł";
    }
}