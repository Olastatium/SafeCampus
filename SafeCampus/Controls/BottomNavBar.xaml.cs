namespace SafeCampus.Controls;

/// <summary>Barre de navigation inférieure (Accueil, Carte, Signalements, Contacts, Profil).</summary>
public partial class BottomNavBar : ContentView
{
    public static readonly BindableProperty ActiveProperty =
        Bp.Make<BottomNavBar, string>(nameof(Active), "home", (c, _) => c.Refresh());

    /// <summary>home | map | tracking | contacts | profile</summary>
    public string Active { get => (string)GetValue(ActiveProperty); set => SetValue(ActiveProperty, value); }

    public BottomNavBar()
    {
        InitializeComponent();
        Refresh();
    }

    private void Refresh()
    {
        var blue = Color.FromArgb("#2563EB");
        var slate = Color.FromArgb("#64748B");

        void Set(string key, BoxView bar, IconView icon, Label label)
        {
            bool on = Active == key;
            var color = on ? blue : slate;
            bar.Color = on ? blue : Colors.Transparent;
            icon.IconColor = color;
            label.TextColor = color;
        }

        Set("home", BarHome, IcoHome, LblHome);
        Set("map", BarMap, IcoMap, LblMap);
        Set("tracking", BarTracking, IcoTracking, LblTracking);
        Set("contacts", BarContacts, IcoContacts, LblContacts);
        Set("profile", BarProfile, IcoProfile, LblProfile);
    }

    private async void OnTabTapped(object? sender, TappedEventArgs e)
    {
        if (sender is VisualElement { ClassId: { Length: > 0 } route })
            await Shell.Current.GoToAsync($"//{route}");
    }
}
