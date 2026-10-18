namespace SafeCampus.Controls;

/// <summary>En-tête blanc des écrans : titre, sous-titre, étiquette, cloche et flèche retour.</summary>
public partial class PageHeader : ContentView
{
    public static readonly BindableProperty TitleProperty =
        Bp.Make<PageHeader, string>(nameof(Title), "", (c, v) => c.TitleLabel.Text = v);
    public static readonly BindableProperty SubtitleProperty =
        Bp.Make<PageHeader, string>(nameof(Subtitle), "", (c, v) =>
        { c.SubtitleLabel.Text = v; c.SubtitleLabel.IsVisible = !string.IsNullOrEmpty(v); });
    public static readonly BindableProperty TagProperty =
        Bp.Make<PageHeader, string>(nameof(Tag), "", (c, v) =>
        { c.TagLabel.Text = v?.ToUpperInvariant(); c.TagLabel.IsVisible = !string.IsNullOrEmpty(v); });
    public static readonly BindableProperty ShowBackProperty =
        Bp.Make<PageHeader, bool>(nameof(ShowBack), false, (c, v) => c.BackIcon.IsVisible = v);
    public static readonly BindableProperty ShowBellProperty =
        Bp.Make<PageHeader, bool>(nameof(ShowBell), true, (c, v) => c.Bell.IsVisible = v);
    public static readonly BindableProperty BackRouteProperty =
        Bp.Make<PageHeader, string>(nameof(BackRoute), "//home", (_, _) => { });

    public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
    public string Subtitle { get => (string)GetValue(SubtitleProperty); set => SetValue(SubtitleProperty, value); }
    public string Tag { get => (string)GetValue(TagProperty); set => SetValue(TagProperty, value); }
    public bool ShowBack { get => (bool)GetValue(ShowBackProperty); set => SetValue(ShowBackProperty, value); }
    public bool ShowBell { get => (bool)GetValue(ShowBellProperty); set => SetValue(ShowBellProperty, value); }
    public string BackRoute { get => (string)GetValue(BackRouteProperty); set => SetValue(BackRouteProperty, value); }

    public PageHeader() => InitializeComponent();

    private async void OnBackTapped(object? sender, TappedEventArgs e)
        => await Shell.Current.GoToAsync(BackRoute);
}
