namespace SafeCampus.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage() => InitializeComponent();

    private async void OnLoginClicked(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//home");

    private async void OnRegisterClicked(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//register");

    private async void OnForgotTapped(object? sender, TappedEventArgs e)
        => await DisplayAlert("Mot de passe oublié", "La réinitialisation sera disponible prochainement.", "OK");
}
