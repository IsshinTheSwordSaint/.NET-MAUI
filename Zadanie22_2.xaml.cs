namespace Zadania;

public partial class Zadanie22_2 : ContentPage
{
	public Zadanie22_2()
	{
		InitializeComponent();
	}
    private void OnEmailTextChanged(object sender, TextChangedEventArgs e)
    {
        var email = EmailEntry.Text;
        if (!string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains("."))
        {
            EmailErrorLabel.IsVisible = false;
        }
        else
        {
            EmailErrorLabel.IsVisible = true;
        }
    }

    private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
    {
        var password = PasswordEntry.Text;
        if (!string.IsNullOrWhiteSpace(password) && password.Length >= 6)
        {
            PasswordErrorLabel.IsVisible = false;
        }
        else
        {
            PasswordErrorLabel.IsVisible = true;
        }
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        if (!EmailErrorLabel.IsVisible && !PasswordErrorLabel.IsVisible)
        {
            DisplayAlert("Login Successful", "You have logged in successfully!", "OK");
        }
        else
        {
            DisplayAlert("Login Failed", "Please correct the errors before logging in.", "OK");
        }
    }
}
