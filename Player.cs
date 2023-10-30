using System;
using SplashKitSDK;

public enum PlayerSelection
{
    Menu,
    Card,
    Target
}

public class Player
{
    private PlayerSelection _selection;
    public PlayerSelection Selection
    {
        get { return _selection; }
    }

    private int _levelIndex;
    public int LevelIndex
    {
        get { return _levelIndex; }
    }

    private List<Level> _levels;

    public Player(List<Level> levels)
    {
        _selection = PlayerSelection.Menu;
        _levels = levels;
    }

    public void MenuUpdate(Menu menu)
    {
        foreach (KeyValuePair<int, Button> button in menu.LevelButtons)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && button.Value.IsMouseOver())
            {
                _selection = PlayerSelection.Card;
                _levelIndex = button.Key;
                _levels[_levelIndex].SetUp();
            }
        }
    }

    public void LevelUpdate(Level level)
    {
        if (level.Game.LevelComplete)
        {
            level.SetUp();
            _selection = PlayerSelection.Menu;
        }

        foreach (Card card in level.Game.Hand.CurrentCards)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && card.IsMouseOver())
            {
                card.IsBeingDragged = !card.IsBeingDragged;
                if (SplashKit.MouseY() <= 450)
                {
                    bool isLeft = SplashKit.MouseX() <= 600;
                    level.Game.PlayCard(card, isLeft);
                    break;
                }
            }
        }

        foreach (Button button in level.Buttons)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && button.IsMouseOver())
            {
                switch (button.Type)
                {
                    case ButtonType.Menu:
                        level.SetUp();
                        _selection = PlayerSelection.Menu;
                        break;
                    case ButtonType.Restart:
                        level.SetUp();
                        break;
                }
            }
        }
    }

    public void UseAbility()
    {

    }
}