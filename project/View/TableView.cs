
namespace project.View;

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using project.Constants;
using project.Entities;

/// <summary>
/// Renders the Blackjack table, cards, and round status.
/// </summary>
public class TableView : IViewComponent
{
    private readonly DeckView _deck;
    private readonly GameWindow _window;
    private readonly List<CardView> _cards = new();

    /// <summary>
    /// Creates the table view with its deck and game window.
    /// </summary>
    public TableView(DeckView deck, GameWindow window)
    {
        ArgumentNullException.ThrowIfNull(deck);
        ArgumentNullException.ThrowIfNull(window);

        _deck = deck;
        _window = window;
    }

    /// <summary>
    /// Updates the displayed cards and round status.
    /// </summary>
    public void ShowRound(Round round)
    {
        ArgumentNullException.ThrowIfNull(round);

        _cards.Clear();

        AddHand(
            round.Dealer.Hand,
            GameDimensions.DealerHandPosition,
            !round.IsFinished);

        AddHand(
            round.Player.Hand,
            GameDimensions.PlayerHandPosition);

        UpdateTitle(round);
    }

    /// <summary>
    /// Draws the deck and all visible cards.
    /// </summary>
    public void Draw(SpriteBatch spriteBatch)
    {
        _deck.Draw(spriteBatch);

        foreach (CardView card in _cards)
        {
            card.Draw(spriteBatch);
        }
    }

    /// <summary>
    /// Updates the window title with scores and round outcome.
    /// </summary>
    private void UpdateTitle(Round round)
    {
        string playerValue = round.Player.HasBlackjack
            ? "Blackjack"
            : round.Player.GetHandValue().ToString();

        string dealerValue = round.IsFinished
            ? round.Dealer.HasBlackjack
                ? "Blackjack"
                : round.Dealer.GetHandValue().ToString()
            : round.Dealer.Hand[0].Score.ToString();

        string status = round.Outcome switch
        {
            RoundOutcome.Win => "You win",
            RoundOutcome.Loss => "Dealer wins",
            RoundOutcome.Push => "Push",
            _ => "Your turn"
        };

        _window.Title =
            $"Sharp Jack | Player: {playerValue} | Dealer: {dealerValue} | {status}";
    }

    /// <summary>
    /// Creates and positions the card views for a hand.
    /// </summary>
    private void AddHand(
        IReadOnlyList<Card> hand,
        Vector2 position,
        bool hideHoleCard = false)
    {
        for (int i = 0; i < hand.Count; i++)
        {
            _cards.Add(new CardView(hand[i], position, hideHoleCard && i == 1));
            position.X += GameDimensions.HandCardSpacing;
        }
    }
}
