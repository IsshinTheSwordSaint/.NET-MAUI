using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Zadania;

public class PasswordStrengthBehavior : Behavior<Entry>
{
    public static readonly BindableProperty StrengthLabelProperty =
            BindableProperty.Create(
                nameof(StrengthLabel),
                typeof(Label),
                typeof(PasswordStrengthBehavior),
                null);

    public Label StrengthLabel
    {
        get => (Label)GetValue(StrengthLabelProperty);
        set => SetValue(StrengthLabelProperty, value);
    }

    protected override void OnAttachedTo(Entry entry)
    {
        entry.TextChanged += OnEntryTextChanged;
        base.OnAttachedTo(entry);
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        entry.TextChanged -= OnEntryTextChanged;
        base.OnDetachingFrom(entry);
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string password = e.NewTextValue ?? string.Empty;
        string strength = EvaluatePasswordStrength(password);

        if (StrengthLabel != null)
        {
            StrengthLabel.Text = strength;

            if (strength == "S³abe")
                StrengthLabel.TextColor = Colors.Red;
            else if (strength == "Œrednie")
                StrengthLabel.TextColor = Colors.Orange;
            else if (strength == "Silne")
                StrengthLabel.TextColor = Colors.Green;
        }
    }

    private string EvaluatePasswordStrength(string password)
    {
        if (string.IsNullOrEmpty(password))
            return string.Empty;

        bool hasDigit = password.Any(c => char.IsDigit(c));
        bool hasUpperCase = password.Any(c => char.IsUpper(c));

        if (password.Length < 8)
            return "S³abe";
        else if (hasDigit && hasUpperCase)
            return "Silne";
        else if (hasDigit)
            return "Œrednie";
        else
            return "S³abe";
    }
}
