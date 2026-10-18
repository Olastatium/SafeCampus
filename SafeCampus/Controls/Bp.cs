namespace SafeCampus.Controls;

/// <summary>Petit utilitaire pour déclarer des BindableProperty sans répétition.</summary>
internal static class Bp
{
    public static BindableProperty Make<TOwner, T>(string name, T defaultValue, Action<TOwner, T> apply,
        BindingMode mode = BindingMode.OneWay) where TOwner : BindableObject
        => BindableProperty.Create(name, typeof(T), typeof(TOwner), defaultValue, mode,
            propertyChanged: (b, _, n) => apply((TOwner)b, (T)n!));
}
