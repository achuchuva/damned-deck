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
    public Rectangle Rectangle
    {
        get { return _rectangle; }
    }
    private Bitmap _image;
    public Bitmap Image 
    {
        get { return _image; }
    }
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

    public bool IsMouseOver()
    {
        Point2D mousePos = new Point2D();
        mousePos.X = SplashKit.MouseX();
        mousePos.Y = SplashKit.MouseY();
        return SplashKit.PointInRectangle(mousePos, _rectangle);
    }
}