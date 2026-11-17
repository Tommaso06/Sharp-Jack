using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_project;

using project.Constants;
using project.States;
using project.Utilities;
using project.View;

/// <summary>
/// Hosts the Blackjack table in the MonoGame update and rendering loop.
/// </summary>
public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly StateManager _stateManager = new StateManager();
    private SpriteBatch _spriteBatch;
    private Matrix _scaleMatrix;

    /// <summary>
    /// Sets up graphics and the MonoGame content directory.
    /// </summary>
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        Exiting += (_, _) => _stateManager.CurrentState?.Exit();
    }

    /// <summary>
    /// Sets the window size and calculates the virtual table scale.
    /// </summary>
    protected override void Initialize()
    {
        DisplayMode display = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
        _graphics.PreferredBackBufferWidth = display.Width;
        _graphics.PreferredBackBufferHeight = display.Height;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();

        IsMouseVisible = true;
        CalculateScaleMatrix();
        base.Initialize();
    }

    /// <summary>
    /// Loads the playing cards and activates the table state.
    /// </summary>
    protected override void LoadContent()
    {
        AssetsManager assets = AssetsManager.Instance;
        assets.Initialize(Content);
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        var deckView = new DeckView(assets.GetAsset(AssetsManager.CardBackID));
        _stateManager.ChangeState(new RoundState(Window, new TableView(deckView)));
    }

    /// <summary>
    /// Handles the exit key and updates the active state.
    /// </summary>
    /// <param name="gameTime">Timing information for the current frame.</param>
    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
            return;
        }

        _stateManager.Update(gameTime);
        base.Update(gameTime);
    }

    /// <summary>
    /// Clears the screen and draws the active state in virtual table coordinates.
    /// </summary>
    /// <param name="gameTime">Timing information for the current frame.</param>
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin(transformMatrix: _scaleMatrix);
        _stateManager.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    /// <summary>
    /// Maps the virtual table dimensions to the current viewport.
    /// </summary>
    private void CalculateScaleMatrix()
    {
        float scaleX = (float)GraphicsDevice.Viewport.Width / GameDimensions.VirtualWidth;
        float scaleY = (float)GraphicsDevice.Viewport.Height / GameDimensions.VirtualHeight;
        _scaleMatrix = Matrix.CreateScale(scaleX, scaleY, 1.0f);
    }
}
