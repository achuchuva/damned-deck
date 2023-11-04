using SplashKitSDK;

public class Awakened : Spell, IToken
{
    public Awakened() : base(0, "Break Free", "Discover a spell.", Effect.Discover, Target.Chosen, SplashKit.LoadBitmap("awakened", "Images/awakened.png"))
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            new Selection(Program.AllCards.Where(c => c is Spell).ToList()).GetTargets(this, game);
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
