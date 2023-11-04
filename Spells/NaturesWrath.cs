using SplashKitSDK;

public class NaturesWrath : Spell, IToken
{
    public NaturesWrath() : base(0, "Nature's Wrath", "Deal 1 damage to a minion. Draw a card", Effect.Damage, Target.Chosen, SplashKit.LoadBitmap("natureswrath", "Images/natureswrath.png"))
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
                game.EventManager.OnDraw(1);
            }
        }
    }
}
