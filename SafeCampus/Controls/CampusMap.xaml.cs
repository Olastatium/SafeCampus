namespace SafeCampus.Controls;

/// <summary>Plan simplifié du campus. Variant = "zones" (Bloc B surligné) ou "position".</summary>
public partial class CampusMap : Border
{
    public static readonly BindableProperty VariantProperty =
        Bp.Make<CampusMap, string>(nameof(Variant), "zones", (c, _) => c.Apply());

    public string Variant { get => (string)GetValue(VariantProperty); set => SetValue(VariantProperty, value); }

    public CampusMap()
    {
        InitializeComponent();
        Apply();
    }

    private void Apply()
    {
        if (ZoneMarkers is null) return;
        bool position = Variant == "position";

        HeightRequest = position ? 380 : 305;
        ZoneMarkers.IsVisible = !position;
        PositionMarkers.IsVisible = position;
        PositionCard.IsVisible = position;
        BottomRoad.TranslationY = position ? 75 : 0;

        BlocB.BackgroundColor = Color.FromArgb(position ? "#F6F8F4" : "#DBEAFE");
        BlocB.Stroke = new SolidColorBrush(Color.FromArgb(position ? "#9CB09C" : "#2563EB"));
    }
}
