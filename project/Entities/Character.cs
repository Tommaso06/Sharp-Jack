namespace project.Entities;

using System;
using System.Collections.Generic;
using project.Constants;

/// <summary>
/// Represents a Blackjack participant and their current hand.
/// </summary>
public class Character
{
    private readonly List<Card> _hand = new List<Card>();

    public string Name { get; }

    /// <summary>
    /// Gets a read-only view of the cards in deal order.
    /// </summary>
    public IReadOnlyList<Card> Hand { get; }

    public bool IsBusted => GetHandValue() > BlackjackRules.MaximumHandValue;

    /// <summary>
    /// Gets whether the hand is an opening two-card twenty-one.
    /// </summary>
    public bool HasBlackjack => Hand.Count == BlackjackRules.InitialCardsPerHand
        && GetHandValue() == BlackjackRules.MaximumHandValue;

    /// <summary>
    /// Creates a participant with an empty hand.
    /// </summary>
    /// <param name="name">The participant's display name.</param>
    public Character(string name)
    {
        Name = name;
        Hand = _hand.AsReadOnly();
    }

    /// <summary>
    /// Draws the top card into the participant's hand.
    /// </summary>
    /// <param name="deck">The deck to draw from.</param>
    /// <exception cref="ArgumentNullException">The deck is null.</exception>
    /// <exception cref="InvalidOperationException">The deck is empty.</exception>
    public void DrawCard(Deck deck)
    {
        ArgumentNullException.ThrowIfNull(deck);
        _hand.Add(deck.DrawCard());
    }

    /// <summary>
    /// Moves the entire hand into the discard pile.
    /// </summary>
    /// <param name="discardPile">The pile receiving the cards.</param>
    /// <exception cref="ArgumentNullException">The discard pile is null.</exception>
    public void ClearHand(DiscardPile discardPile)
    {
        ArgumentNullException.ThrowIfNull(discardPile);
        discardPile.AddRange(_hand);
        _hand.Clear();
    }

    /// <summary>
    /// Calculates the best total, reducing Aces from eleven to one as needed.
    /// </summary>
    /// <returns>The best total, or the lowest total if the hand busts.</returns>
    public int GetHandValue()
    {
        int total = 0;
        int aceCount = 0;

        foreach (Card card in Hand)
        {
            total += card.Score;
            if (card.Value == Values.Ace)
            {
                aceCount++;
            }
        }

        while (total > BlackjackRules.MaximumHandValue && aceCount > 0)
        {
            total -= BlackjackRules.HighAceValue - BlackjackRules.LowAceValue;
            aceCount--;
        }

        return total;
    }

    /// <summary>
    /// Formats the participant's name and cards.
    /// </summary>
    /// <returns>A display string for the participant.</returns>
    public override string ToString()
    {
        string handText = Hand.Count > 0 ? string.Join(", ", Hand) : "Empty";
        return $"Name: {Name}, Hand: {handText}";
    }
}
