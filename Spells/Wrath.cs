using SplashKitSDK;

public class Wrath : Spell
{
    public Wrath() : base(2, "Wrath", "Choose One - Deal 3 damage to a minion; or 1 damage and draw a card.", Effect.ChooseOne, Target.Chosen, SplashKit.LoadBitmap("wrath", "Images/wrath.png"))
    {
        _choices = new List<Card> { new SolarWrath(), new NaturesWrath() };
    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            new Selection(Choices).GetTargets(this, game);
        }
    }

    public override void HandleEffect(List<Card> targets, Game game)
    {
        if (targets != null)
        {
            foreach (Card card in targets)
            {
                game.EventManager.OnChooseOne(card);
            }
        }
    }
}
