namespace project.Entities;

using System;
using project.Constants;

/// <summary>
/// Represents the dealer, who stands on all totals of seventeen or higher.
/// </summary>
public class Dealer : Character
{
    /// <summary>
    /// Creates a dealer with an empty hand.
    /// </summary>
    /// <param name="name">The dealer's display name.</param>
    public Dealer(string name = "Dealer") : base(name)
    {
    }

    /// <summary>
    /// Draws below seventeen and stands on hard or soft seventeen.
    /// </summary>
    /// <param name="deck">The deck to draw from.</param>
    /// <exception cref="ArgumentNullException">The deck is null.</exception>
    /// <exception cref="InvalidOperationException">The deck runs out of cards.</exception>
    internal void PlayTurn(Deck deck)
    {
        ArgumentNullException.ThrowIfNull(deck);
        while (GetHandValue() < BlackjackRules.DealerStandThreshold)
        {
            DrawCard(deck);
        }
    }
}
