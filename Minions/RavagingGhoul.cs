using SplashKitSDK;

public class RavagingGhoul : Minion
{
    public RavagingGhoul() : base(3, "Ravaging Ghoul", "Battlecry: Deal 1 damage to all other minions.", Effect.Damage, Target.AllButSelf, Trigger.OnPlay, SplashKit.LoadBitmap("ravagingghoul", "Images/ravagingghoul.png"), 3)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        List<Card> targets = new Selection(game.Board.CurrentCards).GetTargets(this);
        if (TargetType == Target.Chosen)
        {
            targets = game.Targets;
        }

        if (playEvent.PlayedCard == this)
        {
            if (targets != null)
            {
                foreach (Card card in targets)
                {
                    game.EventManager.OnDamage(card, 1);
                }
            }
        }

        base.HandleEvent(_event, game);
    }
}
