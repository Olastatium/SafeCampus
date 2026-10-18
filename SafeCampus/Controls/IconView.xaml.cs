using Microsoft.Maui.Controls.Shapes;

namespace SafeCampus.Controls;

/// <summary>Icône vectorielle (style "outline") dessinée avec un Path : aucune image requise.</summary>
public partial class IconView : ContentView
{
    private static readonly Dictionary<string, string> Paths = new()
    {
        ["shield"]        = "M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z",
        ["shield-check"]  = "M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z M9 12l2 2 4-4",
        ["eye"]           = "M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z M12 9a3 3 0 1 0 0 6 3 3 0 0 0 0-6z",
        ["eye-off"]       = "M17.94 17.94A10.07 10.07 0 0 1 12 20c-7 0-11-8-11-8a18.45 18.45 0 0 1 5.06-5.94 M9.9 4.24A9.12 9.12 0 0 1 12 4c7 0 11 8 11 8a18.5 18.5 0 0 1-2.16 3.19 M14.12 14.12a3 3 0 1 1-4.24-4.24 M1 1l22 22",
        ["bell"]          = "M18 8A6 6 0 0 0 6 8c0 7-3 9-3 9h18s-3-2-3-9 M13.73 21a2 2 0 0 1-3.46 0",
        ["home"]          = "M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z M9 22V12h6v10",
        ["map"]           = "M1 6v16l7-4 8 4 7-4V2l-7 4-8-4-7 4z M8 2v16 M16 6v16",
        ["alert"]         = "M12 4v11 M12 20v.01",
        ["phone"]         = "M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z",
        ["user"]          = "M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2 M12 3a4 4 0 1 0 0 8 4 4 0 0 0 0-8z",
        ["pin"]           = "M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 0 1 18 0z M12 7a3 3 0 1 0 0 6 3 3 0 0 0 0-6z",
        ["info"]          = "M12 2a10 10 0 1 0 0 20 10 10 0 0 0 0-20z M12 16v-4 M12 8h.01",
        ["clock"]         = "M12 2a10 10 0 1 0 0 20 10 10 0 0 0 0-20z M12 6v6l4 2",
        ["check"]         = "M20 6L9 17l-5-5",
        ["chevron-right"] = "M9 18l6-6-6-6",
        ["arrow-left"]    = "M19 12H5 M12 19l-7-7 7-7",
        ["camera"]        = "M23 19a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2V8a2 2 0 0 1 2-2h4l2-3h6l2 3h4a2 2 0 0 1 2 2z M12 10a4 4 0 1 0 0 8 4 4 0 0 0 0-8z",
        ["logout"]        = "M9 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h4 M16 17l5-5-5-5 M21 12H9",
        ["mail"]          = "M4 4h16a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H4a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2z M22 6l-10 7L2 6",
    };

    public static readonly BindableProperty KindProperty =
        Bp.Make<IconView, string>(nameof(Kind), "", (c, _) => c.Refresh());
    public static readonly BindableProperty IconColorProperty =
        Bp.Make<IconView, Color>(nameof(IconColor), Colors.Black, (c, _) => c.Refresh());
    public static readonly BindableProperty SizeProperty =
        Bp.Make<IconView, double>(nameof(Size), 24d, (c, _) => c.Refresh());

    public string Kind { get => (string)GetValue(KindProperty); set => SetValue(KindProperty, value); }
    public Color IconColor { get => (Color)GetValue(IconColorProperty); set => SetValue(IconColorProperty, value); }
    public double Size { get => (double)GetValue(SizeProperty); set => SetValue(SizeProperty, value); }

    public IconView()
    {
        InitializeComponent();
        Refresh();
    }

    private void Refresh()
    {
        if (Glyph is null) return;

        if (Paths.TryGetValue(Kind ?? "", out var data))
            Glyph.Data = (Geometry?)new PathGeometryConverter().ConvertFromInvariantString(data);

        Glyph.Stroke = new SolidColorBrush(IconColor);
        Glyph.WidthRequest = Size;
        Glyph.HeightRequest = Size;
    }
}
