using SplashKitSDK;

public class TwistingNether : Spell
{
    public TwistingNether() : base(8, "Twisting Nether", "Destroy all minions.", EffectType.Destroy, TargetType.All, SplashKit.LoadBitmap("twistingnether", "Images/twistingnether.png"))
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        List<Card> targets = new Selection(game.Board.CurrentCards).GetTargets(this);
        if (TargetType == TargetType.Chosen)
        {
            targets = game.Targets;
        }

        if (playEvent.PlayedCard == this)
        {
            if (targets != null)
            {
                foreach (Card card in targets)
                {
                    game.EventManager.OnDeath(card);
                }
            }
        }

        base.HandleEvent(_event, game);
    }
}
