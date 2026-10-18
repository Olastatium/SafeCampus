namespace SafeCampus.Views;

public partial class ZonesPage : ContentPage
{
    public ZonesPage() => InitializeComponent();

    private async void OnDetailsTapped(object? sender, TappedEventArgs e)
        => await DisplayAlert("Bloc B", "Plusieurs signalements récents ont été enregistrés dans cette zone.", "OK");
}
