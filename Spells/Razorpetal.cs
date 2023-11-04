using SplashKitSDK;

public class RazorPetal : Spell, IToken
{

    public RazorPetal() : base(1, "Razor Petal", "Deal 1 damage.", Effect.Damage, Target.Chosen, SplashKit.LoadBitmap("RazorPetal", "Images/RazorPetal.png"))
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
                game.EventManager.OnDamage(card, 1);
            }
        }
    }
}
