namespace project.States;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Defines the lifecycle of a game state.
/// </summary>
public interface IGameState
{
    /// <summary>
    /// Initializes the state when it becomes active.
    /// </summary>
    void Enter();

    /// <summary>
    /// Updates the active state for the current frame.
    /// </summary>
    /// <param name="gameTime">Timing information for the current frame.</param>
    void Update(GameTime gameTime);

    /// <summary>
    /// Ends the state's active lifecycle.
    /// </summary>
    void Exit();

    /// <summary>
    /// Draws the active state.
    /// </summary>
    /// <param name="spriteBatch">The active sprite batch.</param>
    void Draw(SpriteBatch spriteBatch);
}
