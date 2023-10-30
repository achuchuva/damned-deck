using System;
using SplashKitSDK;

public class Menu
{
    private Dictionary<int, Button> _levelButtons;
    public Dictionary<int, Button> LevelButtons
    {
        get { return _levelButtons; }
    }

    public Menu()
    {
        _levelButtons = new Dictionary<int, Button>();
    }

    public void SetUp(int levelCount)
    {
        int startX = 100;
        for (int i = 0; i < levelCount; i++)
        {
            Rectangle rect = new Rectangle();
            rect.X = startX;
            rect.Y = 550;
            rect.Height = 100;
            rect.Width = 100;
            _levelButtons.Add(i, new Button(rect, SplashKit.LoadBitmap("button", "Images/button.png"), ButtonType.Start));
            startX += 150;
        }
    }

    public void Draw()
    {
        Bitmap menuImage = SplashKit.LoadBitmap("menu", "Images/menu.png");
        SplashKit.DrawBitmap(menuImage, 0, 0);
        SplashKit.FreeBitmap(menuImage);

        for (int i = 0; i < _levelButtons.Count; i++)
        {
            _levelButtons[i].Draw((i + 1).ToString());
        }

    }
}