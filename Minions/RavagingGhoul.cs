public class RavagingGhoul : Minion
{
    public RavagingGhoul() : base(3, "Ravaging Ghoul", "Battlecry: Deal 1 damage to all other minions.", 3)
    {

    }

    public override void HandleEvent(Event _event)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            Dictionary<Card, int> damagedCards = new Dictionary<Card, int>();
            foreach (Card card in EventManager.GetInstance().Game.Board.CurrentCards)
            {
                damagedCards.Add(card, 1);
            }
            
            EventManager.GetInstance().OnDamage(damagedCards);
        }
    }
}