namespace project.View;

using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Defines a drawable table component.
/// </summary>
public interface IViewComponent
{
    /// <summary>
    /// Draws the component.
    /// </summary>
    /// <param name="spriteBatch">The active sprite batch.</param>
    void Draw(SpriteBatch spriteBatch);
}
