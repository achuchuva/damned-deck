using SplashKitSDK;

public interface IPlayerSelectionState
{
    public void Update(Menu menu, Level level, Player player);
}

public class MenuSelectionState : IPlayerSelectionState
{
    public void Update(Menu menu, Level level, Player player)
    {
        foreach (KeyValuePair<int, Button> button in menu.LevelButtons)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && button.Value.IsMouseOver())
            {
                player.CurrentLevel = menu.GetLevel(button.Key);
                player.CurrentLevel.SetUp(player);
                player.SetSelectionState(new CardSelectionState());
            }
        }
    }
}

public class CardSelectionState : IPlayerSelectionState
{
    public void Update(Menu menu, Level level, Player player)
    {
        if (level.Game.LevelComplete)
        {
            SplashKit.Delay(3000);
            level.SetUp(player);
            player.CurrentLevel = null;
            player.SetSelectionState(new MenuSelectionState());
        }

        foreach (Card card in level.Game.Board.CurrentCards)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && card.IsMouseOver())
            {
                level.Game.UseAbility(card);
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
                    level.Game.PlayCard(card, SplashKit.MouseX() <= 600);
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
                        level.SetUp(player);
                        player.CurrentLevel = null;
                        player.SetSelectionState(new MenuSelectionState());
                        break;
                    case ButtonType.Restart:
                        level.SetUp(player);
                        break;
                }
            }
        }
    }
}

public class TargetSelectionState : IPlayerSelectionState
{
    public void Update(Menu menu, Level level, Player player)
    {
        foreach (Card card in level.Game.Targets)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && card.IsMouseOver())
            {
                player.SetSelectionState(new CardSelectionState());
                level.Game.TargetingCard.HandleEffect(new List<Card> { card }, level.Game);
                level.Game.Cleanup();
                break;
            }
        }

        if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            level.Game.CancelCard();
            player.SetSelectionState(new CardSelectionState());
        }
    }
}

public class DiscoverSelectionState : IPlayerSelectionState
{
    public void Update(Menu menu, Level level, Player player)
    {
        foreach (Card card in level.Game.Targets)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && card.IsMouseOver())
            {
                player.SetSelectionState(new CardSelectionState());
                level.Game.TargetingCard.HandleEffect(new List<Card> { card }, level.Game);
                level.Game.Cleanup();
                break;
            }
        }
    }
}