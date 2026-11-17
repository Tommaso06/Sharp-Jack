
namespace project.States;

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project.Entities;
using project.View;

/// <summary>
/// Handles input and connects the active Blackjack round to the view.
/// </summary>
public class RoundState : IGameState
{
    private readonly Table _table;
    private readonly TableView _tableView;

    private MouseState mouse;

    private Round CurrentRound => _table.CurrentRound
        ?? throw new InvalidOperationException("No active round.");

    /// <summary>
    /// Creates the playing state for an existing game session.
    /// </summary>
    public RoundState(Run run, TableView tableView)
    {
        ArgumentNullException.ThrowIfNull(run);
        ArgumentNullException.ThrowIfNull(tableView);

        _table = run.Table;
        _tableView = tableView;
    }

    /// <summary>
    /// Starts the first round when this state becomes active.
    /// </summary>
    public void Enter()
    {
        StartNextRound();
    }

    /// <summary>
    /// Processes a single player action per key press.
    /// </summary>
    public void Update(GameTime gameTime)
    {
        mouse = Mouse.GetState();

        // TODO: Handle mouse input and button interactions.
    }

    /// <summary>
    /// Restores the deck when leaving the playing state.
    /// </summary>
    public void Exit()
    {
        _table.Leave();
    }

    /// <summary>
    /// Draws the current table.
    /// </summary>
    public void Draw(SpriteBatch spriteBatch)
    {
        _tableView.Draw(spriteBatch);
    }

    /// <summary>
    /// Deals the next round and refreshes the view.
    /// </summary>
    private void StartNextRound()
    {
        _table.StartNextRound();
        UpdateView();
    }

    /// <summary>
    /// Refreshes the cards and status displayed by the table view.
    /// </summary>
    private void UpdateView()
    {
        _tableView.ShowRound(CurrentRound);
    }

}
