
namespace project.Entities;

using System;
using project.Constants;

/// <summary>
/// Owns the deck, discard pile, and successive Blackjack rounds.
/// </summary>
public class Table
{
    private readonly DiscardPile _discardPile = new();

    public Player Player { get; }
    public Deck Deck { get; }
    public Dealer Dealer { get; }
    public Round? CurrentRound { get; private set; }

    /// <summary>
    /// Creates a table for the session's player.
    /// </summary>
    public Table(Player player)
    {

        Player = player;
        Dealer = new Dealer();
        Deck = new Deck(BlackjackRules.DeckNumber);
        Deck.Shuffle();
    }

    /// <summary>
    /// Collects the previous hand and deals the next round.
    /// </summary>
    public void StartNextRound()
    {
        if (CurrentRound is not null && !CurrentRound.IsFinished)
        {
            throw new InvalidOperationException(
                "The current round is still in progress.");
        }

        if (CurrentRound is not null)
        {
            Player.ClearHand(_discardPile);
            CurrentRound.Dealer.ClearHand(_discardPile);
            CurrentRound = null;
        }

        // Reshuffle the discarded cards before the shoe gets too low.
        decimal reshuffleThreshold =
        BlackjackRules.DeckNumber
        * BlackjackRules.StandardDeckSize
        * (1 - BlackjackRules.DeckPenetration);

        if (Deck.Count <= reshuffleThreshold)
        {
            Deck.ReturnCardsToDeck(_discardPile.DumpAndClear());
            Deck.Shuffle();
        }

        CurrentRound = new Round(Player, Dealer, Deck);
    }

    /// <summary>
    /// Returns all cards to the deck and resets the table.
    /// </summary>
    public void Leave()
    {
        if (CurrentRound is not null)
        {
            Player.ClearHand(_discardPile);
            Dealer.ClearHand(_discardPile);
            CurrentRound = null;
        }

        Deck.ReturnCardsToDeck(_discardPile.DumpAndClear());
        Deck.Shuffle();
    }
}
