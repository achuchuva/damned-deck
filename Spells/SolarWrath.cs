using SplashKitSDK;

public class SolarWrath : Spell, IToken
{

    public SolarWrath() : base(0, "Solar Wrath", "Deal 3 damage to a minion", Effect.Damage, Target.Chosen, SplashKit.LoadBitmap("solarwrath", "Images/solarwrath.png"))
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
                game.EventManager.OnDamage(card, 3);
            }
        }
    }
}
