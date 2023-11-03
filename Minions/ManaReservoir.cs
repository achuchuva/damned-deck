// 0 Mana: Ability, take 1 damage and gain 2 mana, 2 health
using SplashKitSDK;

public class ManaReservoir : Minion
{
    public ManaReservoir() : base(0, "Mana Reservoir", "Ability: Take 1 damage and gain 2 mana.", Effect.Mana, Target.Self, Trigger.OnAbility, SplashKit.LoadBitmap("manareservoir", "Images/manareservoir.png"), 2)
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
                game.EventManager.OnManaChange(2);
            }
        }
    }
}
