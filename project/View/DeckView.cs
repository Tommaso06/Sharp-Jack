namespace project.View;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using project.Constants;

/// <summary>
/// Draws the deck as a stack of face-down cards.
/// </summary>
public class DeckView : IViewComponent
{
    private readonly Texture2D _texture;

    public Rectangle Bounds { get; private set; }

    /// <summary>
    /// Creates the deck view at its default table position.
    /// </summary>
    /// <param name="texture">The shared card back texture.</param>
    public DeckView(Texture2D texture)
    {
        _texture = texture;
        SetPosition(GameDimensions.DeckDefaultPosition);
    }

    /// <summary>
    /// Moves the deck to a new position on the table.
    /// </summary>
    /// <param name="newPosition">The new position in virtual table coordinates.</param>
    public void SetPosition(Vector2 newPosition)
    {
        Bounds = new Rectangle((int)newPosition.X, (int)newPosition.Y, GameDimensions.Width, GameDimensions.Height);
    }

    /// <summary>
    /// Draws the card back at the deck's current bounds.
    /// </summary>
    /// <param name="spriteBatch">The active sprite batch.</param>
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Bounds, Color.White);
    }
}
