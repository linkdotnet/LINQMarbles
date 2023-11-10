using MudBlazor;

namespace LinqMarbles;

public record MarbleModel(int Number)
{
    public Color Color { get; } = GetRandomColor();

    private static Color GetRandomColor()
    {
        Span<Color> colors = [Color.Primary, Color.Secondary, Color.Info, Color.Success, Color.Warning, Color.Error, Color.Dark, Color.Surface];
        var randomIndex = Random.Shared.Next(colors.Length);
        return colors[randomIndex];
    }
}