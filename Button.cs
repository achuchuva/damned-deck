using SplashKitSDK;

public enum ButtonType
{
    Menu,
    Restart,
    Start
}

public class Button
{
    private Rectangle _rectangle;
    private Bitmap _image;
    private ButtonType _type;
    public ButtonType Type
    {
        get { return _type ;}
    }

    public Button(Rectangle rectangle, Bitmap image, ButtonType type)
    {
        _rectangle = rectangle;
        _image = image;
        _type = type;
    }

    public void Draw(string text = "")
    {
        SplashKit.DrawBitmap(_image, _rectangle.X, _rectangle.Y);
        SplashKit.DrawText(text, Color.Black, "Fonts/aptos-black.ttf", 75, _rectangle.X + 25, _rectangle.Y + 5);
    }

    public bool IsMouseOver()
    {
        Point2D mousePos = new Point2D();
        mousePos.X = SplashKit.MouseX();
        mousePos.Y = SplashKit.MouseY();
        return SplashKit.PointInRectangle(mousePos, _rectangle);
    }
}