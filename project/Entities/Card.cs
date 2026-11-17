namespace project.Entities;

/// <summary>
/// Represents one playing card with a suit and rank.
/// </summary>
public class Card
{
    /// <summary>
    /// Gets the texture key shared with the MonoGame card content.
    /// </summary>
    public string CardTypeID => GetCardTypeID(Seed, Value);

    public Seeds Seed { get; }
    public Values Value { get; }

    /// <summary>
    /// Gets the starting Blackjack value, counting an Ace as eleven.
    /// </summary>
    public int Score => Value.GetScore();

    /// <summary>
    /// Creates a card of the specified suit and rank.
    /// </summary>
    /// <param name="seed">The card's suit.</param>
    /// <param name="value">The card's rank.</param>
    public Card(Seeds seed, Values value)
    {
        Seed = seed;
        Value = value;
    }

    /// <summary>
    /// Builds the texture key for a suit and rank.
    /// </summary>
    /// <param name="seed">The card's suit.</param>
    /// <param name="value">The card's rank.</param>
    /// <returns>The rank followed by the suit, matching the content file name.</returns>
    internal static string GetCardTypeID(Seeds seed, Values value)
    {
        return $"{value}_{seed}";
    }

    /// <summary>
    /// Formats the card's rank, suit, and starting value.
    /// </summary>
    /// <returns>A display string for the card.</returns>
    public override string ToString()
    {
        return $"{Value} of {Seed} (Points: {Score})";
    }
}
