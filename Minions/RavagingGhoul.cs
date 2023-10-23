public class RavagingGhoul : Minion
{
    public RavagingGhoul()
    {
        _name = "Ravaging Ghoul";
        _description = "Battlecry: Deal 1 damage to all other minions.";
        _manaCost = 3;
        _health = 3;
    }

    public override void HandleEvent(Event _event)
    {
        if (_event.GetType() != PlayEvent)
            return;

        PlayEvent playEvent = (PlayeEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            Dictionary<Card, int> damagedCards = new Dictionary<Card, int>();
            foreach (Card card in playEvent.State.Board)
            {
                damagedCards.Add(card, 1);
            }
            
            _manager.OnDamage(damagedCards);
        }
    }
}
