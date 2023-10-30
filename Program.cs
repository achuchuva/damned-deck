using System.Text.Json;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {

        List<Level>? levels = GetLevels();
        Player player = new Player(levels);
        Menu menu = new Menu();
        if (levels != null)
        {
            menu.SetUp(levels.Count);
        }

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
                    break;
            }

            SplashKit.RefreshScreen();
        } while (!window.CloseRequested);
    }

    public static List<Level>? GetLevels()
    {
        string jsonString = Json.ToJsonString(SplashKit.JsonFromFile("levels.json"));
        return JsonSerializer.Deserialize<List<Level>>(jsonString);
    }
}
