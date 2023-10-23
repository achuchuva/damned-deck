public class AcolyteOfPain : Minion
{
    public AcolyteOfPain() : base(3, "Acolyte of Pain", "Whenever this minion takes damage, draw a card.", 3)
    {
        
    }

    public override void HandleEvent(Event _event)
    {
        if (!(_event is DamageEvent))
            return;

        DamageEvent damageEvent = (DamageEvent)_event;

        if (damageEvent.DamagedCards.ContainsKey(this))
        {
            Console.WriteLine("Woooo! Draw a card");
        }
    }
}
