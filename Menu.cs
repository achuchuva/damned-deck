using System;
using SplashKitSDK;

public class Menu
{
    private Dictionary<int, Button> _levelButtons;
    public Dictionary<int, Button> LevelButtons
    {
        get { return _levelButtons; }
    }

    private List<Level>? _levels;

    public Menu(List<Level> levels)
    {
        _levelButtons = new Dictionary<int, Button>();
        _levels = levels;
        if (_levels != null)
        {
            SetUp(_levels.Count);
        }
    }

    public Level GetLevel(int index)
    {
        return _levels[index];
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
}