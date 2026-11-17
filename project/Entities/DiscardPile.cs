namespace project.Entities;

using System;
using System.Collections.Generic;
using project.Constants;

/// <summary>
/// Collects used cards before they are returned to the deck.
/// </summary>
public class DiscardPile
{
    private readonly List<Card> _cards = new List<Card>(BlackjackRules.StandardDeckSize);

    /// <summary>
    /// Adds a completed participant hand to the pile.
    /// </summary>
    /// <param name="cards">The used cards to discard.</param>
    /// <exception cref="ArgumentNullException">The collection is null.</exception>
    public void AddRange(IEnumerable<Card> cards)
    {
        _cards.AddRange(cards);
    }

    /// <summary>
    /// Removes all discarded cards for reuse.
    /// </summary>
    /// <returns>The cards removed from the pile.</returns>
    public List<Card> DumpAndClear()
    {
        var dumpedCards = new List<Card>(_cards);
        _cards.Clear();
        return dumpedCards;
    }
}
