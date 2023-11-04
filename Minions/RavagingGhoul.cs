using SplashKitSDK;

public class RavagingGhoul : Minion
{
    public RavagingGhoul() : base(3, "Ravaging Ghoul", "Ability: Deal 1 damage to all other minions.", Effect.Damage, Target.AllButSelf, Trigger.OnAbility, SplashKit.LoadBitmap("ravagingghoul", "Images/ravagingghoul.png"), 3)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is AbilityEvent))
            return;

        AbilityEvent abilityEvent = (AbilityEvent)_event;

        if (abilityEvent.AbilityCard == this)
        {
            new Selection(game.Board.CurrentCards).GetTargets(this, game);
        }
    }

    public override void HandleEffect(List<Card> targets, Game game)
    {
        if (targets != null)
        {
            foreach (Card card in targets)
            {
                game.EventManager.OnDamage(card, 1);
            }
        }
    }
}
