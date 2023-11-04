using SplashKitSDK;

public class FelOrcSoulfiend : Minion
{
    public FelOrcSoulfiend() : base(1, "Fel Orc Soulfiend", "After you play a card, take 1 damage.", Effect.Damage, Target.Self, Trigger.OnPlay, SplashKit.LoadBitmap("FelOrcSoulfiend", "Images/FelOrcSoulfiend.png"), 9)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;
            
        new Selection(game.Board.CurrentCards).GetTargets(this, game);
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

