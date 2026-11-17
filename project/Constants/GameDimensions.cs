namespace project.Constants;

using Microsoft.Xna.Framework;

/// <summary>
/// Defines card dimensions and positions in the virtual table layout.
/// </summary>
public static class GameDimensions
{
    public const int VirtualWidth = 1920;
    public const int VirtualHeight = 1080;
    public const int Width = 100;
    public const int Height = 140;
    public const int HandCardSpacing = 110;

    public static readonly Vector2 DeckDefaultPosition = new Vector2(100f, 800f);
    public static readonly Vector2 DealerHandPosition = new Vector2(300f, 220f);
    public static readonly Vector2 PlayerHandPosition = new Vector2(300f, 640f);
}
