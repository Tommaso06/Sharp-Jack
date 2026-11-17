namespace project.Entities;

/// <summary>
/// Represents the human participant at the table.
/// </summary>
public class Player : Character
{
    /// <summary>
    /// Creates a player with an empty hand.
    /// </summary>
    /// <param name="name">The player's display name.</param>
    public Player(string name = "Player") : base(name)
    {
    }
}
