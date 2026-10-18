namespace SafeCampus.Views;

public partial class AlertConfirmationPage : ContentPage
{
    public AlertConfirmationPage() => InitializeComponent();

    private async void OnSendClicked(object? sender, EventArgs e)
    {
        await DisplayAlert("Alerte envoyée", "Le service de sécurité a été notifié de votre position.", "OK");
        await Shell.Current.GoToAsync("//tracking");
    }

    private async void OnCancelClicked(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//home");
}
