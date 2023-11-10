using MudBlazor;

namespace LinqMarbles;

public record MarbleMultiModel(int Number, string Content)
{
    public Color Color { get; init; } = GetRandomColor();

    private static Color GetRandomColor()
    {
        Span<Color> colors = [Color.Primary, Color.Secondary, Color.Info, Color.Success, Color.Warning, Color.Error, Color.Dark, Color.Surface];
        var randomIndex = Random.Shared.Next(colors.Length);
        return colors[randomIndex];
    }
}