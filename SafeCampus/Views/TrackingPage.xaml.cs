namespace SafeCampus.Views;

public partial class TrackingPage : ContentPage
{
    public TrackingPage() => InitializeComponent();

    private async void OnDetailsTapped(object? sender, TappedEventArgs e)
        => await DisplayAlert("SIG-2026-00124", "Vol - Bloc administratif - 05 octobre 2026\nStatut : en cours de traitement.", "OK");

    private async void OnContactTapped(object? sender, TappedEventArgs e)
        => await Shell.Current.GoToAsync("//contacts");
}
