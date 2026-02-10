using System.ComponentModel;

namespace Zadania;

public partial class Zadanie19_2 : ContentPage
{
    public Zadanie19_2()
    {
        InitializeComponent();
        MyDatePicker.MaximumDate = DateTime.Today.AddDays(30);
    }
    private void OnButtonClicked(object sender, EventArgs e)
    {

        if (itemPicker.SelectedIndex >= 0)
        {
            string selectedItem = itemPicker.SelectedItem.ToString();
            var selectedDate = MyDatePicker.Date;
            var selectedTime = MyTimePicker.Time;

            ResultLabel.Text = $"Wizyta u {selectedItem} dnia {selectedDate:dd.MM.yyyy} o godzinie {selectedTime}";
        }
        else
        {
            ResultLabel.Text = "Nie uzupełniono formularza, proszę uzupełnić";
        }
    }
}
