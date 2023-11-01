using SplashKitSDK;

public class Darkbomb : Spell
{
    public Darkbomb() : base(2, "Darkbomb", "Deal 3 damage.", Effect.Damage, Target.Chosen, SplashKit.LoadBitmap("darkbomb", "Images/darkbomb.png"))
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
                    game.EventManager.OnDamage(card, 3);
                }
            }
        }

        base.HandleEvent(_event, game);
    }
}
