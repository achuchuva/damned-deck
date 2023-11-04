using SplashKitSDK;

public class RiskySkipper : Minion
{
    public RiskySkipper() : base(1, "Risky Skipper", "After you play a minion, deal 1 damage to all minions.", Effect.Damage, Target.All, Trigger.OnPlay, SplashKit.LoadBitmap("riskyskipper", "Images/riskyskipper.png"), 5)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard != this)
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
                game.EventManager.OnDamage(card, 1);
            }
        }
    }
}
