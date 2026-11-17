namespace project.Entities;

using System;
using System.Collections.Generic;
using project.Constants;

/// <summary>
/// Represents a standard deck drawn from the end of its card list.
/// </summary>
public class Deck
{
    private readonly List<Card> _cards;

    public int Count => _cards.Count;

    /// <summary>
    /// Creates the requested number of standard 52-card decks in one stack.
    /// </summary>
    public Deck(int deckNumber = 1)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(deckNumber);
        _cards = new List<Card>(checked(deckNumber * BlackjackRules.StandardDeckSize));

        for (int deck = 0; deck < deckNumber; deck++)
        {
            foreach (Seeds seed in Enum.GetValues<Seeds>())
            {
                foreach (Values value in Enum.GetValues<Values>())
                {
                    _cards.Add(new Card(seed, value));
                }
            }
        }
    }

    /// <summary>
    /// Shuffles the remaining cards using the Fisher-Yates algorithm.
    /// </summary>
    public void Shuffle()
    {
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int swapIndex = Random.Shared.Next(i + 1);
            (_cards[i], _cards[swapIndex]) = (_cards[swapIndex], _cards[i]);
        }
    }

    /// <summary>
    /// Removes and returns the top card.
    /// </summary>
    /// <returns>The card at the top of the deck.</returns>
    /// <exception cref="InvalidOperationException">The deck is empty.</exception>
    public Card DrawCard()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Deck is empty.");
        }

        Card card = _cards[Count - 1];
        _cards.RemoveAt(Count - 1);
        return card;
    }

    /// <summary>
    /// Returns cards to the top of the deck before shuffling.
    /// </summary>
    /// <param name="cards">The cards to return, in bottom-to-top order.</param>
    /// <exception cref="ArgumentNullException">The collection is null.</exception>
    public void ReturnCardsToDeck(IEnumerable<Card> cards)
    {
        _cards.AddRange(cards);
    }
}
