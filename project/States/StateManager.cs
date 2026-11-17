namespace project.States;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Activates game states and forwards MonoGame updates and drawing to the active state.
/// </summary>
public class StateManager
{
    public IGameState CurrentState { get; private set; }

    /// <summary>
    /// Exits the current state and enters the replacement.
    /// </summary>
    /// <param name="newState">The replacement state, or null to deactivate the current state.</param>
    public void ChangeState(IGameState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }

    /// <summary>
    /// Updates the current state for this frame.
    /// </summary>
    /// <param name="gameTime">Timing information for the current frame.</param>
    public void Update(GameTime gameTime)
    {
        CurrentState?.Update(gameTime);
    }

    /// <summary>
    /// Draws the current state.
    /// </summary>
    /// <param name="spriteBatch">The active sprite batch.</param>
    public void Draw(SpriteBatch spriteBatch)
    {
        CurrentState?.Draw(spriteBatch);
    }
}
