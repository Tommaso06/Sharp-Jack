namespace project.Entities;

using project.Constants;

/// <summary>
/// Lists the ranks in a standard deck, in ascending order starting with Ace.
/// </summary>
public enum Values
{
    Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
}

/// <summary>
/// Maps card ranks to their starting Blackjack values.
/// </summary>
public static class ValuesExtensions
{
    /// <summary>
    /// Calculates the score of a rank before any Ace adjustment.
    /// </summary>
    /// <param name="value">The rank to score.</param>
    /// <returns>The card's starting Blackjack value.</returns>
    public static int GetScore(this Values value)
    {
        return value switch
        {
            Values.Ace => BlackjackRules.HighAceValue,
            Values.Jack or Values.Queen or Values.King => BlackjackRules.FaceCardValue,
            _ => (int)value + 1
        };
    }
}
