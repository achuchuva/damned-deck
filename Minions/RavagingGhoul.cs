using SplashKitSDK;

public class RavagingGhoul : Minion
{
    public RavagingGhoul() : base(3, "Ravaging Ghoul", "Battlecry: Deal 1 damage to all other minions.", SplashKit.LoadBitmap("ravagingghoul", "Images/ravagingghoul.png"), 3)
    {

    }

    public override void HandleEvent(Event _event)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            foreach (Card card in Game.GetInstance().Board.CurrentCards)
            {
                if (card != this)
                {
                    card.TakeDamage(1);
                    EventManager.GetInstance().OnDamage(card, 1);
                }
            }
        }

        base.HandleEvent(_event);
    }
}
