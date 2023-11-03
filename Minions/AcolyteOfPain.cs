using SplashKitSDK;

public class AcolyteOfPain : Minion
{
    public AcolyteOfPain() : base(3, "Acolyte of Pain", "Whenever this minion takes damage, draw a card.", Effect.Draw, Target.Self, Trigger.OnDamage, SplashKit.LoadBitmap("acolyteofpain", "Images/acolyteofpain.png"), 3)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is DamageEvent))
            return;

        DamageEvent damageEvent = (DamageEvent)_event;

        if (damageEvent.DamagedCard == this)
        {
            new Selection(game.Board.CurrentCards).GetTargets(this, game);
        }
    }

    public override void HandleEffect(List<Card> targets, Game game)
    {
        game.EventManager.OnDraw(1);
    }
}
