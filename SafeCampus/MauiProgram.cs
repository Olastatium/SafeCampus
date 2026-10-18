using Microsoft.Maui.Handlers;

namespace SafeCampus;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();

        // Supprime la bordure / le soulignement natif Windows des Entry et Editor
        // afin d'obtenir les champs arrondis de la maquette.
        EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
        {
#if WINDOWS
            MakeBorderless(handler.PlatformView);
#endif
        });
        EditorHandler.Mapper.AppendToMapping("BorderlessEditor", (handler, view) =>
        {
#if WINDOWS
            MakeBorderless(handler.PlatformView);
#endif
        });

        return builder.Build();
    }

#if WINDOWS
    private static void MakeBorderless(Microsoft.UI.Xaml.Controls.TextBox tb)
    {
        var transparent = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Transparent);
        var zero = new Microsoft.UI.Xaml.Thickness(0);

        foreach (var key in new[]
        {
            "TextControlBackground", "TextControlBackgroundPointerOver", "TextControlBackgroundFocused",
            "TextControlBackgroundDisabled", "TextControlBorderBrush", "TextControlBorderBrushPointerOver",
            "TextControlBorderBrushFocused", "TextControlBorderBrushDisabled"
        })
            tb.Resources[key] = transparent;

        tb.Resources["TextControlBorderThemeThickness"] = zero;
        tb.Resources["TextControlBorderThemeThicknessFocused"] = zero;
        tb.BorderThickness = zero;
        tb.Background = transparent;
        tb.Padding = new Microsoft.UI.Xaml.Thickness(0, 6, 0, 6);
    }
#endif
}
