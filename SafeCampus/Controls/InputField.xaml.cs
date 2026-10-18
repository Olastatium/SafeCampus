namespace SafeCampus.Controls;

/// <summary>Libellé + champ arrondi (+ icône "œil" pour les mots de passe).</summary>
public partial class InputField : ContentView
{
    public static readonly BindableProperty CaptionProperty =
        Bp.Make<InputField, string>(nameof(Caption), "", (c, v) => c.CaptionLabel.Text = v);
    public static readonly BindableProperty TextProperty =
        Bp.Make<InputField, string>(nameof(Text), "", (c, v) => { if (c.Field.Text != v) c.Field.Text = v; }, BindingMode.TwoWay);
    public static readonly BindableProperty PlaceholderProperty =
        Bp.Make<InputField, string>(nameof(Placeholder), "", (c, v) => c.Field.Placeholder = v);
    public static readonly BindableProperty IsPasswordProperty =
        Bp.Make<InputField, bool>(nameof(IsPassword), false, (c, v) => { c.Field.IsPassword = v; c.EyeIcon.IsVisible = v; });
    public static readonly BindableProperty KeyboardProperty =
        Bp.Make<InputField, Keyboard>(nameof(Keyboard), Keyboard.Default, (c, v) => c.Field.Keyboard = v);

    public string Caption { get => (string)GetValue(CaptionProperty); set => SetValue(CaptionProperty, value); }
    public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }
    public string Placeholder { get => (string)GetValue(PlaceholderProperty); set => SetValue(PlaceholderProperty, value); }
    public bool IsPassword { get => (bool)GetValue(IsPasswordProperty); set => SetValue(IsPasswordProperty, value); }
    public Keyboard Keyboard { get => (Keyboard)GetValue(KeyboardProperty); set => SetValue(KeyboardProperty, value); }

    public InputField()
    {
        InitializeComponent();
        Field.TextChanged += (_, e) => SetValue(TextProperty, e.NewTextValue ?? "");
    }

    private void OnEyeTapped(object? sender, TappedEventArgs e)
    {
        Field.IsPassword = !Field.IsPassword;
        EyeIcon.Kind = Field.IsPassword ? "eye" : "eye-off";
    }
}
