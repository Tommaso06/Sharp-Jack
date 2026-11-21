namespace project.View;

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project.Localization;

public class MenuView : IViewComponent, IDisposable
{
    private readonly Texture2D _background;
    private readonly LoadLanguage _texts;
    public Button PlayButton { get; }
    public Button SettingsButton { get; }
    public Button ExitButton { get; }

    public MenuView(
        ContentManager content,
        GraphicsDevice graphicsDevice,
        LoadLanguage texts)
    {
        ArgumentNullException.ThrowIfNull(texts);
        _texts = texts;
        var font = content.Load<SpriteFont>("Fonts/Menu");
        _background = new Texture2D(graphicsDevice, 1, 1);
        _background.SetData(new[] { Color.White });

        PlayButton = new Button(
            new Rectangle(100, 200, 240, 60),
            texts.Get("menu.play"),
            _background,
            font);

        SettingsButton = new Button(
            new Rectangle(100, 280, 240, 60),
            texts.Get("menu.settings"),
            _background,
            font);

        ExitButton = new Button(
            new Rectangle(100, 360, 240, 60),
            texts.Get("menu.exit"),
            _background,
            font);

        _texts.LanguageChanged += UpdateTexts;
    }

    public void ChangeLanguage(string language)
    {
        _texts.ChangeLanguage(language);
    }

    private void UpdateTexts()
    {
        PlayButton.Text = _texts.Get("menu.play");
        SettingsButton.Text = _texts.Get("menu.settings");
        ExitButton.Text = _texts.Get("menu.exit");
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        PlayButton.Draw(spriteBatch);
        SettingsButton.Draw(spriteBatch);
        ExitButton.Draw(spriteBatch);
    }

    public void Dispose()
    {
        _texts.LanguageChanged -= UpdateTexts;
        _background.Dispose();
    }
}
