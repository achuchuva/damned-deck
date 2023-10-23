public class AcolyteOfPain : Minion
{
    public AcolyteOfPain()
    {
        _name = "Acolyte of Pain";
        _description = "Whenever this minion takes damange, draw a card.";
        _manaCost = 3;
        _health = 3;
    }

    public override void HandleEvent(Event _event)
    {
        if (_event.GetType() != DamageEvent)
            return;

        DamageEvent damageEvent = (DamageEvent)_event;

        if (damageEvent.DamagedCards.ContainsKey(this))
        {
            Console.WriteLine("Woooo! Draw a card");
        }
    }
}
