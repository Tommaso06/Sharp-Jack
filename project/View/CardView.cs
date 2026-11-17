namespace project.View;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using project.Constants;
using project.Entities;
using project.Utilities;

/// <summary>
/// Draws one face-up or face-down playing card.
/// </summary>
public class CardView : IViewComponent
{
    private readonly Texture2D _texture;

    public Rectangle Bounds { get; private set; }

    /// <summary>
    /// Creates a card view using the card face or the shared card back.
    /// </summary>
    /// <param name="cardData">The card being displayed.</param>
    /// <param name="startPosition">The position in virtual table coordinates.</param>
    /// <param name="faceDown">Whether to display the card back.</param>
    public CardView(Card cardData, Vector2 startPosition, bool faceDown = false)
    {
        _texture = AssetsManager.Instance.GetAsset(faceDown ? AssetsManager.CardBackID : cardData.CardTypeID);
        SetPosition(startPosition);
    }

    /// <summary>
    /// Moves the card to a new position on the table.
    /// </summary>
    /// <param name="newPosition">The new position in virtual table coordinates.</param>
    public void SetPosition(Vector2 newPosition)
    {
        Bounds = new Rectangle((int)newPosition.X, (int)newPosition.Y, GameDimensions.Width, GameDimensions.Height);
    }

    /// <summary>
    /// Draws the card texture at its current bounds.
    /// </summary>
    /// <param name="spriteBatch">The active sprite batch.</param>
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Bounds, Color.White);
    }
}
