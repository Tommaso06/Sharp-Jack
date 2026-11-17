
namespace project.Entities;

using System;
using project.Constants;

/// <summary>
/// Manages a single Blackjack round between the player and dealer.
/// </summary>
public class Round
{
    private readonly Deck _deck;

    public Player Player { get; }
    public Dealer Dealer { get; }
    public RoundOutcome Outcome { get; private set; }
    public bool IsFinished => Outcome != RoundOutcome.InProgress;

    /// <summary>
    /// Creates a round, deals the initial cards, and checks for Blackjack.
    /// </summary>
    /// <param name="player">The player participating in the round.</param>
    /// <param name="deck">The deck used to draw cards.</param>
    public Round(Player player, Dealer dealer , Deck deck)
    {
        ArgumentNullException.ThrowIfNull(player);
        ArgumentNullException.ThrowIfNull(deck);

        if (player.Hand.Count != 0) // check if the playher hand is != 0
        {
            throw new ArgumentException(
                "The player must have an empty hand.",
                nameof(player));
        }

        if (deck.Count < BlackjackRules.InitialCardsPerHand * 2) // check the init cards
        {
            throw new ArgumentException(
                "Not enough cards to start the round.",
                nameof(deck));
        }

        Player = player;
        Dealer = dealer;
        _deck = deck; 
        Outcome = RoundOutcome.InProgress;

        DealInitialCards();
        CheckInitialBlackjack();
    }

    /// <summary>
    /// Deals the initial cards to both participants.
    /// </summary>
    private void DealInitialCards()
    {
        for (int i = 0; i < BlackjackRules.InitialCardsPerHand; i++)
        {
            Player.DrawCard(_deck);
            Dealer.DrawCard(_deck); // the second card'll be reverse
        }
    }

    /// <summary>
    /// Resolves any Blackjack obtained during the initial deal.
    /// </summary>
    private void CheckInitialBlackjack()
    {
        if (!Player.HasBlackjack && !Dealer.HasBlackjack)
        {
            return;
        }

        if (Player.HasBlackjack && Dealer.HasBlackjack)
        {
            Outcome = RoundOutcome.Push;
        }
        else
        {
            Outcome = Player.HasBlackjack
                ? RoundOutcome.Win
                : RoundOutcome.Loss;
        }
    }

    /// <summary>
    /// Draws a card for the player and checks the resulting hand.
    /// </summary>
    public void Hit()
    {
        if (IsFinished)
        {
            return;
        }

        Player.DrawCard(_deck);

        if (Player.IsBusted)
        {
            Outcome = RoundOutcome.Loss;
        }
        else if (Player.GetHandValue() == BlackjackRules.MaximumHandValue)
        {
            Stand();
        }
    }

    /// <summary>
    /// Ends the player's turn, plays the dealer's turn,
    /// and determines the round outcome.
    /// </summary>
    public void Stand()
    {
        if (IsFinished)
        {
            return;
        }

        Dealer.PlayTurn(_deck);

        int playerTotal = Player.GetHandValue();
        int dealerTotal = Dealer.GetHandValue();

        if (Dealer.IsBusted || playerTotal > dealerTotal)
        {
            Outcome = RoundOutcome.Win;
        }
        else if (playerTotal == dealerTotal)
        {
            Outcome = RoundOutcome.Push;
        }
        else
        {
            Outcome = RoundOutcome.Loss;
        }
    }
}
