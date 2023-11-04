using System.Text.Json;
using SplashKitSDK;

public static class Program
{
    public static List<Card> AllCards
    {
        get
        {
            return new List<Card> {
                new AcolyteOfPain(),
                new Anomalus(),
                new BoulderfistOgre(),
                new KnightCaptain(),
                new ManaReservoir(),
                new RavagingGhoul(),
                new Darkbomb(),
                new ExploreUngoro(),
                new TwistingNether(),
                new Wrath(),
                new RavenIdol(),
                new BloodswornMercenary(),
                new TheDarkness(),
                new MurlocTidehunter(),
                new RazorpetalLasher(),
                new RazorpetalVolley(),
                new RiskySkipper(),
                new BeamingSidekick(),
                new FelOrcSoulfiend()
            };
        }
    }

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
