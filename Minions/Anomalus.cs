using SplashKitSDK;

public class Anomalus : Minion
{
    public Anomalus() : base(8, "Anomalus", "Deathrattle: Deal 8 damage to all minions.", Effect.Damage, Target.AllButSelf, Trigger.OnDeath, SplashKit.LoadBitmap("anomalus", "Images/anomalus.png"), 2)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is DeathEvent))
            return;

        DeathEvent deathEvent = (DeathEvent)_event;

        List<Card> targets = new Selection(game.Board.CurrentCards).GetTargets(this);
        if (TargetType == Target.Chosen)
        {
            targets = game.Targets;
        }

        if (deathEvent.DestroyedCard == this)
        {
            if (targets != null)
            {
                foreach (Card card in targets)
                {
                    game.EventManager.OnDamage(card, 8);
                }
            }
        }

        base.HandleEvent(_event, game);
    }
}
