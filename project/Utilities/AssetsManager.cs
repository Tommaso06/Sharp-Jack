namespace project.Utilities;

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project.Entities;

/// <summary>
/// Loads and caches the card textures used by the table.
/// </summary>
public class AssetsManager
{
    public const string CardBackID = "Back";
    public static AssetsManager Instance { get; } = new AssetsManager();

    private readonly Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

    /// <summary>
    /// Creates the shared texture cache.
    /// </summary>
    private AssetsManager()
    {
    }

    /// <summary>
    /// Loads the card faces and back from the current content manager.
    /// </summary>
    /// <param name="content">The game content manager.</param>
    /// <exception cref="ArgumentNullException">The content manager is null.</exception>
    /// <exception cref="ContentLoadException">A required card texture could not be loaded.</exception>
    public void Initialize(ContentManager content)
    {
        ArgumentNullException.ThrowIfNull(content);
        _textures.Clear();

        foreach (Seeds seed in Enum.GetValues<Seeds>())
        {
            foreach (Values value in Enum.GetValues<Values>())
            {
                string key = Card.GetCardTypeID(seed, value);
                _textures[key] = content.Load<Texture2D>($"Main_Cards/{key}");
            }
        }

        _textures[CardBackID] = content.Load<Texture2D>("Main_Deck/Back");
    }

    /// <summary>
    /// Retrieves a loaded card texture by its content key.
    /// </summary>
    /// <param name="assetId">The card texture key.</param>
    /// <returns>The cached texture.</returns>
    /// <exception cref="ArgumentNullException">The texture key is null.</exception>
    /// <exception cref="KeyNotFoundException">The texture has not been loaded.</exception>
    public Texture2D GetAsset(string assetId)
    {
        return _textures[assetId];
    }
}
