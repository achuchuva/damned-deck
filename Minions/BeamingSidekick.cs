// 1 Mana: Ability give a minion +2 health, 5 health
using SplashKitSDK;

public class BeamingSidekick : Minion
{
    public BeamingSidekick() : base(1, "Beaming Sidekick", "Ability: Give a minion +2 health.", Effect.GainHealth, Target.Chosen, Trigger.OnAbility, SplashKit.LoadBitmap("beamingsidekick", "Images/beamingsidekick.png"), 5)
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
                game.EventManager.OnGainHealth(card, 2);
            }
        }
    }
}
