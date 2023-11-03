using System.Text.Json;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        List<Level>? levels = LoadLevels();
        Menu menu = new Menu(levels);
        Player player = new Player();
        View view = new View();

        Window window = new Window("Damned Deck", 1200, 900);
        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            player.Update(player.CurrentLevel, menu);
            if (player.CurrentLevel == null)
            {
                view.DrawMenu(menu);
            }
            else
            {
                view.DrawLevel(player.CurrentLevel);
                player.CurrentLevel.Update();
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
