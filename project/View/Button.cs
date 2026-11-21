namespace project.View;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Button
{
    private readonly Texture2D _background;
    private readonly SpriteFont _font;
    private bool _isHovered;

    public Rectangle Bounds { get; }
    public string Text { get; set; }

    public Button(
        Rectangle bounds,
        string text,
        Texture2D background,
        SpriteFont font)
    {
        Bounds = bounds;
        Text = text;
        _background = background;
        _font = font;
    }

    public bool Update(
        Vector2 mousePosition,
        MouseState mouse,
        MouseState previousMouse)
    {
        _isHovered = Bounds.Contains(
            (int)mousePosition.X,
            (int)mousePosition.Y);

        return _isHovered
            && mouse.LeftButton == ButtonState.Pressed
            && previousMouse.LeftButton == ButtonState.Released;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Color backgroundColor = _isHovered
            ? Color.DarkGoldenrod
            : Color.DarkSlateGray;

        spriteBatch.Draw(_background, Bounds, backgroundColor);

        Vector2 textSize = _font.MeasureString(Text);
        Vector2 textPosition = new Vector2(
            Bounds.X + (Bounds.Width - textSize.X) / 2,
            Bounds.Y + (Bounds.Height - textSize.Y) / 2);

        spriteBatch.DrawString(_font, Text, textPosition, Color.White);
    }
}