using SplashKitSDK;

public class ExploreUngoro : Spell
{
    public ExploreUngoro() : base(0, "Explore Un'Goro", "Discover a card.", Effect.Discover, Target.Chosen, SplashKit.LoadBitmap("exploreungoro", "Images/exploreungoro.png"))
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            new Selection(Program.AllCards).GetTargets(this, game);
        }
    }

    public override void HandleEffect(List<Card> targets, Game game)
    {
        if (targets != null)
        {
            foreach (Card card in targets)
            {
                game.EventManager.OnDiscover(card);
            }
        }
    }
}
