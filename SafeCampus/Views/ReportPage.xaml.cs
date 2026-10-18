namespace SafeCampus.Views;

public partial class ReportPage : ContentPage
{
    private readonly Border[] _types;
    private readonly Border[] _severities;

    public ReportPage()
    {
        InitializeComponent();
        _types = new[] { TypeVol, TypeAccident, TypeViolence, TypeAutre };
        _severities = new[] { SevFaible, SevModere, SevEleve, SevCritique };

        // Valeurs sélectionnées par défaut (comme sur la maquette)
        Select(_types, TypeVol);
        Select(_severities, SevModere);
    }

    private void OnTypeTapped(object? sender, TappedEventArgs e)
    {
        if (sender is Border b) Select(_types, b);
    }

    private void OnSeverityTapped(object? sender, TappedEventArgs e)
    {
        if (sender is Border b) Select(_severities, b);
    }

    private static void Select(Border[] group, Border selected)
    {
        foreach (var chip in group)
        {
            bool on = chip == selected;
            chip.BackgroundColor = on ? Color.FromArgb("#2563EB") : Colors.White;
            chip.Stroke = new SolidColorBrush(Color.FromArgb(on ? "#2563EB" : "#E2E8F0"));
            if (chip.Content is Label l)
                l.TextColor = on ? Colors.White : Color.FromArgb("#0F172A");
        }
    }

    private async void OnPhotoTapped(object? sender, TappedEventArgs e)
        => await DisplayAlert("Photo", "La sélection de photo sera branchée avec la partie logique.", "OK");

    private async void OnSendClicked(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//tracking");
}
