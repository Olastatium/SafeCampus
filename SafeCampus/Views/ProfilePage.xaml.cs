namespace SafeCampus.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage() => InitializeComponent();

    private async void OnLogoutTapped(object? sender, TappedEventArgs e) => await Shell.Current.GoToAsync("//login");
}
