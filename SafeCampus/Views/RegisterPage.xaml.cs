namespace SafeCampus.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage() => InitializeComponent();

    private async void OnCreateClicked(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//home");

    private async void OnLoginTapped(object? sender, TappedEventArgs e) => await Shell.Current.GoToAsync("//login");
}
