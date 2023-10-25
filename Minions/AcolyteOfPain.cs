using SplashKitSDK;

public class AcolyteOfPain : Minion
{
    public AcolyteOfPain() : base(3, "Acolyte of Pain", "Whenever this minion takes damage, draw a card.", SplashKit.LoadBitmap("acolyteofpain", "Images/acolyteofpain.png"), 3)
    {
        
    }

    public override void HandleEvent(Event _event)
    {
        if (!(_event is DamageEvent))
            return;

        DamageEvent damageEvent = (DamageEvent)_event;

        if (damageEvent.DamagedCard == this)
        {
            Game.GetInstance().Deck.DrawCard(1);
            EventManager.GetInstance().OnDraw(1);
        }
    }
}
