using SplashKitSDK;

public class AcolyteOfPain : Minion
{
    public AcolyteOfPain() : base(3, "Acolyte of Pain", "Whenever this minion takes damage, draw a card.", EffectType.Draw, TargetType.Self, TriggerType.OnDamage, SplashKit.LoadBitmap("acolyteofpain", "Images/acolyteofpain.png"), 3)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is DamageEvent))
            return;

        DamageEvent damageEvent = (DamageEvent)_event;

        List<Card> targets = new Selection(game.Board.CurrentCards).GetTargets(this);
        if (TargetType == TargetType.Chosen)
        {
            targets = game.Targets;
        }

        if (damageEvent.DamagedCard == this)
        {
            game.EventManager.OnDraw(1);
        }
    }
}
