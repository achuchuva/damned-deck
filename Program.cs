using System.Text.Json;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        List<Level>? levels = LoadLevels();
        Player player = new Player(levels);
        Menu menu = new Menu();
        if (levels != null)
        {
            menu.SetUp(levels.Count);
        }

        Arrow targetArrow = new Arrow();

        Window window = new Window("Damned Deck", 1200, 900);
        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            switch (player.Selection)
            {
                case PlayerSelection.Menu:
                    menu.Draw();
                    player.MenuUpdate(menu);
                    break;
                case PlayerSelection.Card:
                    if (levels != null)
                    {
                        levels[player.LevelIndex].Draw();
                        levels[player.LevelIndex].Update();
                        player.LevelUpdate(levels[player.LevelIndex]);
                    }
                    break;
                case PlayerSelection.Target:
                    if (levels != null)
                    {
                        Level level = levels[player.LevelIndex];
                        level.Draw();
                        level.Update();
                        player.TargetUpdate(level);
                        targetArrow.Draw(
                            level.Game.TargetingCard.X,
                            level.Game.TargetingCard.Y,
                            level.Game.TargetingCard.Width / 2,
                            level.Game.TargetingCard.Height / 2);
                    }
                    break;
            }

            SplashKit.RefreshScreen();
        } while (!window.CloseRequested);
    }

    public static List<Level>? LoadLevels()
    {
        string jsonString = File.ReadAllText("Resources/json/levels.json");
        return JsonSerializer.Deserialize<List<Level>>(jsonString);
    }
}
