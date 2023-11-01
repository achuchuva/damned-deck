// 3 Mana: Ability, deal 3 damage, 3 health
using SplashKitSDK;

public class KnightCaptain : Minion
{
    public KnightCaptain() : base(3, "Knight-Captain", "Ability: Deal 3 damage.", EffectType.Damage, TargetType.Chosen, TriggerType.OnAbility, SplashKit.LoadBitmap("knightcaptain", "Images/knightcaptain.png"), 3)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is AbilityEvent))
            return;

        AbilityEvent abilityEvent = (AbilityEvent)_event;

        List<Card> targets = new Selection(game.Board.CurrentCards).GetTargets(this);
        if (TargetType == TargetType.Chosen)
        {
            targets = game.Targets;
        }

        if (abilityEvent.AbilityCard == this)
        {
            if (targets != null)
            {
                foreach (Card card in targets)
                {
                    game.EventManager.OnDamage(card, 3);
                }
            }
        }

        base.HandleEvent(_event, game);
    }
}
