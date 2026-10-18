namespace SafeCampus.Views;

public partial class PositionPage : ContentPage
{
    public PositionPage() => InitializeComponent();

    private async void OnRecenterTapped(object? sender, TappedEventArgs e)
        => await DisplayAlert("Ma position", "Carte recentrée sur votre position : Bloc B - Campus principal.", "OK");

    private async void OnReportsTapped(object? sender, TappedEventArgs e)
        => await Shell.Current.GoToAsync("//tracking");
}
