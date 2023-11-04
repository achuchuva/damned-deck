using SplashKitSDK;

public class BreakFree : Spell, IToken
{
    public BreakFree() : base(0, "Break Free", "Discover a minion.", Effect.Discover, Target.Chosen, SplashKit.LoadBitmap("breakfree", "Images/breakfree.png"))
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            new Selection(Program.AllCards.Where(c => c is Minion).ToList()).GetTargets(this, game);
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
