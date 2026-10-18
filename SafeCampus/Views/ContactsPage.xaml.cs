namespace SafeCampus.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage() => InitializeComponent();

    private async void OnCallTapped(object? sender, TappedEventArgs e)
    {
        var service = e.Parameter as string ?? "ce service";
        await DisplayAlert("Appel", $"Appel vers « {service} » (démonstration front-end).", "OK");
    }
}
