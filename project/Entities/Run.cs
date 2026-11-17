
namespace project.Entities;

using System;
using project.Constants;

/// <summary>
/// Represents a Blackjack game session and the player's balance.
/// </summary>
public class Run
{
    public Player Player { get; }
    public Table Table { get; }
    public int Fiches { get; private set; }

    /// <summary>
    /// Creates a session with its player and table.
    /// </summary>
    public Run(Player player)
    {
        ArgumentNullException.ThrowIfNull(player);

        Player = player;
        Fiches = BlackjackRules.StartingFiches;
        Table = new Table(player);
    }
}
