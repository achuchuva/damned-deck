// 1 Mana: Ability, duplicate a machine part, 5 health
using SplashKitSDK;
using System;

public class BloodswornMercenary : Minion
{
    public BloodswornMercenary() : base(1, "Bloodsworn Mercenary", "Ability: Choose a minion. Summon a copy of it.", Effect.Summon, Target.Chosen, Trigger.OnAbility, SplashKit.LoadBitmap("BloodswornMercenary", "Images/BloodswornMercenary.png"), 5)
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
                game.EventManager.OnSummon(card.Clone(), game.Board.CurrentCards.IndexOf(this) + 1);
            }
        }
    }
}
