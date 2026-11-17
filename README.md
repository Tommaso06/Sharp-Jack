# Sharp Jack

Sharp Jack is a single-player classic Blackjack game written in C# with MonoGame. The goal is to beat the dealer's hand without going over 21.

## Rules and controls

- The table uses five standard 52-card decks shuffled together. Used cards go into the discard pile between hands. Once at least 70% of the cards have been drawn, the remaining cards are shuffled once before the next hand. Discards return to the deck when the player leaves the table.
- The player and dealer each receive two cards. The dealer's second card stays face down during the player's turn and is revealed when the hand resolves.
- Number cards count at face value. Jacks, queens, and kings count as 10. Aces count as 11 when possible and are reduced to 1 as needed to avoid busting.
- An opening two-card 21 is a natural Blackjack. If either participant has a natural, the hand resolves immediately. Two naturals push.
- Press **H** to hit or **S** to stand. Hitting to 21 ends the player's turn. Going over 21 loses the hand immediately.
- The dealer hits below 17 and stands on every 17 or higher, including soft 17. A dealer bust gives the player a win if the player has already completed their turn without busting. Otherwise the higher total wins, and equal totals push.
- The window title shows the visible totals, the result, and the available controls. After a result, press **Enter** to deal again or **R** to leave and rejoin with a full deck. If the remaining cards cannot cover a full hand, use **R** to continue. Press **Esc** to exit the game.

## Architecture

- **Entities** contains the rendering-independent cards, deck, discard pile, participants, and hand resolution.
- **Constants** keeps Blackjack rules and table layout values in separate files.
- **States** connects the MonoGame loop and keyboard input to the active hand and table view.
- **View** draws the deck and both hands using the existing card art. **Utilities** loads and caches textures built from the MonoGame **Content** project.


