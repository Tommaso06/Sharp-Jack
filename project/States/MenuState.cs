namespace project.States;

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project.Entities;
using project.Utilities;
using project.View;

public class MenuState : IGameState
{
    private readonly MenuView _menuView;
    private readonly Game _game;
    private readonly StateManager _stateManager;
    private readonly Func<Vector2, Vector2> _toUiPosition;

    private MouseState _previousMouse;

    public MenuState(
        MenuView menuView,
        Game game,
        StateManager stateManager,
        Func<Vector2, Vector2> toUiPosition)
    {
        _menuView = menuView;
        _game = game;
        _stateManager = stateManager;
        _toUiPosition = toUiPosition;
    }

    public void Enter()
    {
        _previousMouse = Mouse.GetState();
    }

    public void Update(GameTime gameTime)
    {
        MouseState mouse = Mouse.GetState();

        Vector2 mousePosition = _toUiPosition(
            new Vector2(mouse.X, mouse.Y));

        bool playClicked = _menuView.PlayButton.Update(
            mousePosition, mouse, _previousMouse);

        bool settingsClicked = _menuView.SettingsButton.Update(
            mousePosition, mouse, _previousMouse);

        bool exitClicked = _menuView.ExitButton.Update(
            mousePosition, mouse, _previousMouse);

        _previousMouse = mouse;

        if (playClicked)
        {
            Play();
        }
        else if (settingsClicked)
        {
            OpenSettings();
        }
        else if (exitClicked)
        {
            ExitGame();
        }
    }

    public void Exit()
    {
    }

    private void Play()
    {
        var deckView = new DeckView(
            AssetsManager.Instance.GetAsset(AssetsManager.CardBackID));
        var tableView = new TableView(deckView, _game.Window);
        var run = new Run(new Player());

        _stateManager.ChangeState(new RoundState(run, tableView));
    }

    private void OpenSettings()
    {
        // TODO: Activate the settings state when it is available.
    }

    private void ExitGame()
    {
        _game.Exit();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _menuView.Draw(spriteBatch);
    }
}
