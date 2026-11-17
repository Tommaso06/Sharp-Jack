namespace project.Constants;

/// <summary>
/// Defines the rule values used by the classic Blackjack table.
/// </summary>
public static class BlackjackRules
{
    public const int MaximumHandValue = 21;
    public const int DealerStandThreshold = 17;
    public const int InitialCardsPerHand = 2;
    public const int LowAceValue = 1;
    public const int HighAceValue = 11; //
    public const int FaceCardValue = 10; // figure Value
    public const int StandardDeckSize = 52; //deckSize
    public const int DeckNumber = 5; // number of deck 
    public const decimal DeckPenetration = 0.70m; // % for deck reshuffle
    public const int StartingFiches = 1000; // initial fiches
}
