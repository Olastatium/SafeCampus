namespace SafeCampus.Views;

public partial class HomePage : ContentPage
{
    public HomePage() => InitializeComponent();

    private async void OnNavigate(object? sender, TappedEventArgs e)
    {
        if (e.Parameter is string route)
            await Shell.Current.GoToAsync(route);
    }
}
