using SplashKitSDK;

public class TwistingNether : Spell
{
    public TwistingNether() : base(8, "Twisting Nether", "Destroy all minions.", Effect.Destroy, Target.All, SplashKit.LoadBitmap("twistingnether", "Images/twistingnether.png"))
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            new Selection(game.Board.CurrentCards).GetTargets(this, game);
        }
    }

    public override void HandleEffect(List<Card> targets, Game game)
    {
        if (targets != null)
        {
            foreach (Card card in targets)
            {
                game.EventManager.OnDeath(card);
            }
        }
    }
}
