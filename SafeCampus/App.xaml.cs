namespace SafeCampus;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        UserAppTheme = AppTheme.Light;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Fenêtre au format "téléphone" pour reproduire la maquette mobile.
        return new Window(new AppShell())
        {
            Title = "SafeCampus",
            Width = 410,
            Height = 830,
            MinimumWidth = 360,
            MinimumHeight = 600,
            X = 120,
            Y = 10
        };
    }
}
