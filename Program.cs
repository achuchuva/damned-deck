using System.Text.Json;
using SplashKitSDK;

public static class Program
{
    public static List<Card> AllCards
    {
        get
        {
            return new List<Card> {
                new Minion(3, "Acolyte of Pain", "Whenever this minion takes damage, draw a card.", Effect.Draw, Target.Self, Target.Self, EventType.Damage, new List<Event> { new Event(EventType.Draw, null, 1)}, SplashKit.LoadBitmap("acolyteofpain", "Images/acolyteofpain.png"), 3, false),
                new Minion(8, "Anomalus", "Deathrattle: Deal 10 damage to all minions.", Effect.Damage, Target.AllButSelf, Target.Self, EventType.Death, new List<Event> { new Event(EventType.Damage, null, 10)}, SplashKit.LoadBitmap("anomalus", "Images/anomalus.png"), 4, false),
                new Minion(6, "Boulderfist Ogre", "", Effect.None, Target.None, Target.None, EventType.None, new List<Event>(), SplashKit.LoadBitmap("boulderfistogre", "Images/boulderfistogre.png"), 7, false),
                new Minion(3, "Knight-Captain", "Ability: Deal 3 damage.", Effect.Damage, Target.Chosen, Target.Self, EventType.Ability, new List<Event> { new Event(EventType.Damage, null, 3)}, SplashKit.LoadBitmap("knightcaptain", "Images/knightcaptain.png"), 3, false),
                new Minion(0, "Mana Reservoir", "Ability: Take 1 damage and gain 2 mana.", Effect.Mana, Target.Self, Target.Self, EventType.Ability, new List<Event> { new Event(EventType.Damage, null, 1), new Event(EventType.Mana, null, 2)}, SplashKit.LoadBitmap("manareservoir", "Images/manareservoir.png"), 2, false),
                new Minion(3, "Ravaging Ghoul", "Ability: Deal 1 damage to all other minions.", Effect.Damage, Target.AllButSelf, Target.Self, EventType.Ability, new List<Event> { new Event(EventType.Damage, null, 1)}, SplashKit.LoadBitmap("ravagingghoul", "Images/ravagingghoul.png"), 3, false),
                new Minion(1, "Murloc Scout", "", Effect.None, Target.None, Target.None, EventType.None, new List<Event>(), SplashKit.LoadBitmap("murlocscout", "Images/murlocscout.png"), 1, true),
                new Spell(2, "Darkbomb", "Deal 3 damage.", Effect.Damage, Target.Chosen, new List<Event> { new Event(EventType.Damage, null, 3)}, SplashKit.LoadBitmap("darkbomb", "Images/darkbomb.png"), false),
                new Spell(0, "Explore Un'Goro", "Discover a card.", Effect.Discover, Target.Chosen, new List<Event> { new Event(EventType.Discover, null)}, SplashKit.LoadBitmap("exploreungoro", "Images/exploreungoro.png"), false),
                new Spell(8, "Twisting Nether", "Destroy all minions.", Effect.Destroy, Target.All, new List<Event> { new Event(EventType.Death, null)}, SplashKit.LoadBitmap("twistingnether", "Images/twistingnether.png"), false),
                new Spell(2, "Wrath", "Choose One - Deal 3 damage to a minion; or 1 damage and draw a card.", Effect.ChooseOneWrath, Target.Chosen, new List<Event> { new Event(EventType.ChooseOne, null)}, SplashKit.LoadBitmap("wrath", "Images/wrath.png"), false),
                new Spell(1, "Raven Idol", "Choose One - Discover a minion; or Discover a spell.", Effect.ChooseOneRavenIdol, Target.Chosen, new List<Event> { new Event(EventType.ChooseOne, null)}, SplashKit.LoadBitmap("ravenidol", "Images/ravenidol.png"), false),
                new Minion(1, "Bloodsworn Mercenary", "Ability: Choose a minion. Summon a copy of it.", Effect.SummonCopy, Target.Chosen, Target.Self, EventType.Ability, new List<Event> { new Event(EventType.Summon, null)}, SplashKit.LoadBitmap("BloodswornMercenary", "Images/BloodswornMercenary.png"), 5, false),
                new Minion(0, "The Darkness", "", Effect.None, Target.None, Target.None, EventType.None, new List<Event>(), SplashKit.LoadBitmap("thedarkness", "Images/thedarkness.png"), 60, false),
                new Minion(2, "Murloc Tidehunter", "Battlecry: Summon a Murloc Scout.", Effect.Summon, Target.All, Target.Self, EventType.Play, new List<Event> { new Event(EventType.Summon, null)}, SplashKit.LoadBitmap("murloctidehunter", "Images/murloctidehunter.png"), 1, false),
                new Minion(1, "Razorpetal Lasher", "Battlecry: Add 3 Razorpetals to your hand that deal 1 damage.", Effect.Hand, Target.All, Target.Self, EventType.Play, new List<Event> { new Event(EventType.Hand, null)}, SplashKit.LoadBitmap("razorpetallasher", "Images/razorpetallasher.png"), 2, false),
                new Spell(1, "Razorpetal Volley", "Add 2 Razorpetals to your hand that deal 1 damage.", Effect.Hand, Target.All, new List<Event> { new Event(EventType.Hand, null)}, SplashKit.LoadBitmap("razorpetalvolley", "Images/razorpetalvolley.png"), false),
                new Minion(1, "Risky Skipper", "Whenever you play a minion, deal 1 damage to all minions.", Effect.Damage, Target.All, Target.AllMinions, EventType.Play, new List<Event> { new Event(EventType.Damage, null, 1)}, SplashKit.LoadBitmap("riskyskipper", "Images/riskyskipper.png"), 5, false),
                new Minion(1, "Beaming Sidekick", "Ability: Give a minion +2 health.", Effect.GainHealth, Target.Chosen, Target.Self, EventType.Ability, new List<Event> { new Event(EventType.Health, null, 2)}, SplashKit.LoadBitmap("beamingsidekick", "Images/beamingsidekick.png"), 5, false),
                new Minion(1, "Fel Orc Soulfiend", "After you play a card, take 1 damage.", Effect.Damage, Target.Self, Target.All, EventType.Play, new List<Event> { new Event(EventType.Damage, null, 2)}, SplashKit.LoadBitmap("FelOrcSoulfiend", "Images/FelOrcSoulfiend.png"), 9, false),
                new Spell(0, "Awakened", "Discover a spell.", Effect.Discover, Target.Chosen, new List<Event> { new Event(EventType.Discover, null)}, SplashKit.LoadBitmap("awakened", "Images/awakened.png"), true),
                new Spell(0, "Break Free", "Discover a minion.", Effect.Discover, Target.Chosen, new List<Event> { new Event(EventType.Discover, null)}, SplashKit.LoadBitmap("breakfree", "Images/breakfree.png"), true),
                new Spell(0, "Solar Wrath", "Deal 3 damage to a minion", Effect.Damage, Target.Chosen, new List<Event> { new Event(EventType.Damage, null, 3)}, SplashKit.LoadBitmap("solarwrath", "Images/solarwrath.png"), true),
                new Spell(0, "Nature's Wrath", "Deal 1 damage to a minion. Draw a card", Effect.Damage, Target.Chosen, new List<Event> { new Event(EventType.Damage, null, 1), new Event(EventType.Draw, null, 1)}, SplashKit.LoadBitmap("natureswrath", "Images/natureswrath.png"), true)
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

    public static Card GetCard(string name, bool isToken = false)
    {
        return AllCards.First(card => card.Name == name && card.Token == isToken);
    }
}
