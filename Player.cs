using System;
using SplashKitSDK;

public enum PlayerSelection
{
    Menu,
    Card,
    Target
}

interface PlayerSelectionState
{
    void Update(Player context);
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
    private bool _isLeft;

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

        foreach (Card card in level.Game.Board.CurrentCards)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && card.IsMouseOver())
            {
                Selection selection = new Selection(level.Game.Board.CurrentCards);
                if (selection.GetTargets(card).Count == 0 && card.TriggerType == TriggerType.OnAbility)
                {
                    _selection = PlayerSelection.Target;
                    level.Game.TargetingCard = card;
                    level.Game.SetTarget(level.Game.Board.CurrentCards);
                    level.Game.CurrentTrigger = TriggerType.OnAbility;
                }
                else
                {
                    level.Game.UseAbility(card);
                }
                break;
            }
        }

        foreach (Card card in level.Game.Hand.CurrentCards)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && card.IsMouseOver())
            {
                card.IsBeingDragged = !card.IsBeingDragged;
                if (SplashKit.MouseY() <= 450)
                {
                    _isLeft = SplashKit.MouseX() <= 600;
                    Selection selection = new Selection(level.Game.Board.CurrentCards);
                    if (selection.GetTargets(card).Count == 0 && card.TriggerType == TriggerType.OnPlay)
                    {
                        _selection = PlayerSelection.Target;
                        level.Game.TargetingCard = card;
                        level.Game.SetTarget(level.Game.Board.CurrentCards);
                        level.Game.CurrentTrigger = TriggerType.OnPlay;
                    }
                    else
                    {
                        level.Game.PlayCard(card, _isLeft);
                    }
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

    public void TargetUpdate(Level level)
    {
        foreach (Card card in level.Game.Targets)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && card.IsMouseOver())
            {
                level.Game.SetTarget(new List<Card> { card });
                level.Game.SelectTarget(_isLeft);
                _selection = PlayerSelection.Card;
                break;
            }
        }
    }
}