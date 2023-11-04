using SplashKitSDK;

public class RavenIdol : Spell
{
    public RavenIdol() : base(1, "Raven Idol", "Choose One - Discover a minion; or Discover a spell.", Effect.ChooseOne, Target.Chosen, SplashKit.LoadBitmap("ravenidol", "Images/ravenidol.png"))
    {
        _choices = new List<Card> { new Awakened(), new BreakFree() };
    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            new Selection(Choices).GetTargets(this, game);
        }
    }

    public override void HandleEffect(List<Card> targets, Game game)
    {
        if (targets != null)
        {
            foreach (Card card in targets)
            {
                game.EventManager.OnChooseOne(card);
            }
        }
    }
}
