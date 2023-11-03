using SplashKitSDK;

public class KnightCaptain : Minion
{
    public KnightCaptain() : base(3, "Knight-Captain", "Ability: Deal 3 damage.", Effect.Damage, Target.Chosen, Trigger.OnAbility, SplashKit.LoadBitmap("knightcaptain", "Images/knightcaptain.png"), 3)
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
                game.EventManager.OnDamage(card, 3);
            }
        }
    }
}
