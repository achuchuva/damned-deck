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

        if (playEvent.PlayedCard == this)
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
