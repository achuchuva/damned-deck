using SplashKitSDK;

public class Anomalus : Minion
{
    public Anomalus() : base(8, "Anomalus", "Deathrattle: Deal 8 damage to all minions.", SplashKit.LoadBitmap("anomalus", "Images/anomalus.png"), 2)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is DeathEvent))
            return;

        DeathEvent deathEvent = (DeathEvent)_event;

        if (deathEvent.DestroyedCard == this)
        {
            foreach (Card card in game.Board.CurrentCards)
            {
                if (card != this)
                {
                    game.EventManager.OnDamage(card, 8);
                }
            }
        }

        base.HandleEvent(_event, game);
    }
}
